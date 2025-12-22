# ChatAIze.Abstractions
Contracts shared across the ChatAIze ecosystem. This package is intentionally implementation-free: it defines interfaces, enums, and
conventions that let hosts, plugins, and tooling interoperate without taking direct dependencies on each other.

It is used in:
- `ChatAIze.Chatbot` (the host)
- `ChatAIze.GenerativeCS` (LLM/tool schema + execution)
- `ChatAIze.PluginApi` (concrete implementations for plugin authors)
- first-party plugins such as `law-firm-plugin`

If you are building a ChatAIze host, plugin, or integration, this is the set of contracts you implement and/or consume.

## Install
```bash
dotnet add package ChatAIze.Abstractions
```

Target framework: `net10.0`. If your project targets an earlier runtime, reference the project directly or multi-target accordingly.

## Concepts at a glance
- Chat transcripts: `IChat`, `IChatMessage`, `IFunctionCall`, `IFunctionResult`, `ChatRole`, `PinLocation`
- Runtime context: `IChatbotContext`, `IChatContext`, `IUserContext`, `IFunctionContext`, `IActionContext`, `IConditionContext`
- Plugins and loaders: `IChatbotPlugin`, `IPluginLoader`, `IAsyncPluginLoader`, `IPluginSettings`
- Settings UI: `ISetting` and specific setting types plus `UI` enums for style
- Databases: `IDatabaseManager`, `IDatabase`, `IDatabaseItem`, filtering/sorting + exceptions
- Retrieval: `IRetrievalItem`, `IRetrievalResult`
- Localization + security: `TranslationLanguage`, `SecurityRole`

## Chat transcripts and tool calls
The chat interfaces model a provider-agnostic transcript with support for tool calls.

- `IChat<TMessage, TFunctionCall, TFunctionResult>` defines the collection plus `FromXxxAsync` helpers to construct messages.
  In `ChatAIze.Chatbot`, these methods *create* messages but do not persist them, so callers still add them to storage.
- `IChatMessage<TFunctionCall, TFunctionResult>` represents a single turn. A message can hold text, tool calls, or a tool result.
- `ChatRole` mirrors common LLM roles: system, user, assistant, tool.
- `PinLocation` hints how a host should keep messages when trimming context for token budgets.

Tips:
- Do not put PII in `IChat.UserTrackingId`. In `ChatAIze.Chatbot` it is forwarded to providers for abuse monitoring.
- Use `PinLocation.Begin` for long-lived system rules and `PinLocation.End` for "latest state" that should stay near the end.
- If you attach `ImageUrls`, make sure they are accessible to the provider and do not contain secrets.

## Context interfaces
Contexts are the "ambient services" a host provides to plugins and workflow callbacks.

- `IChatbotContext`: host services outside a specific chat (settings + databases + logging).
- `IChatContext`: adds chat-specific fields such as `ChatId`, `User`, `IsPreview`, `IsDebugModeOn`,
  and `IsCommunicationSandboxed`. Use these flags to guard side effects.
- `IUserContext`: identity, locale, and per-user storage (`GetPropertyAsync` / `SetPropertyAsync`).
- `IFunctionContext`: adds prompt/quick replies, knowledge search, status/progress, and UI prompts.
- `IActionContext`: extends `IFunctionContext` with action execution state, placeholders, and early-exit control.
- `IConditionContext`: intentionally adds no extra APIs; use it only for checks.

Warnings and limitations:
- Some `IFunctionContext` APIs are best-effort and may be no-ops or throw. In `ChatAIze.Chatbot`, `SetIntelligenceLevel`
  currently throws `NotImplementedException`.
- `ShowCaptchaAsync`, `ShowFeedbackAsync`, and `VerifyEmailAsync` are host features; always handle failures gracefully.
- Values returned by `ShowFormAsync` are JSON and must be treated as untrusted input.

## Plugins and loading
Plugins implement `IChatbotPlugin` and are discovered via loader interfaces.

Discovery order in `ChatAIze.Chatbot` (actual host behavior):
1. `IAsyncPluginLoader.LoadAsync`
2. `IPluginLoader.Load`
3. First concrete `IChatbotPlugin` in the assembly (via `Activator.CreateInstance`)

Important behavior in `ChatAIze.Chatbot`:
- Plugin types and loaders must have a public parameterless constructor (no DI at creation time).
- Plugins are loaded in an isolated `AssemblyLoadContext`; only a set of shared assemblies are loaded from the default context
  (including `ChatAIze.Abstractions`, `ChatAIze.PluginApi`, `ChatAIze.GenerativeCS`, `ChatAIze.Utilities`, and
  `Microsoft.Extensions.*`). Other dependencies are private to the plugin.
- Plugin DLLs are copied to a temporary folder to enable hot reload/unload. Implement `IDisposable`/`IAsyncDisposable`
  and avoid static event handlers to keep the load context unloadable.

### Plugin authoring example (using ChatAIze.PluginApi)
```csharp
using ChatAIze.Abstractions.Chat;
using ChatAIze.Abstractions.Plugins;
using ChatAIze.PluginApi;
using ChatAIze.PluginApi.Settings;

public sealed class Loader : IPluginLoader
{
    public IChatbotPlugin Load()
    {
        var plugin = new ChatbotPlugin
        {
            Id = "acme:orders",
            Title = "Orders",
            Version = new Version(1, 0, 0),
        };

        plugin.AddFunction(new ChatFunction("get_order_status")
        {
            Description = "Returns the status of an order by id.",
            Callback = GetOrderStatusAsync
        });

        var action = new FunctionAction(
            id: "acme:actions.create_order",
            title: "Create Order",
            callback: CreateOrderAsync);

        action.AddStringSetting(id: "customer_email", title: "Customer Email");
        action.AddStringSetting(id: "sku", title: "SKU");
        plugin.AddAction(action);

        return plugin;
    }

    private static Task<string> GetOrderStatusAsync(IFunctionContext ctx, string orderId, CancellationToken ct)
        => Task.FromResult($"Order {orderId}: shipped");

    private static async Task CreateOrderAsync(IActionContext ctx, string customerEmail, string sku, CancellationToken ct)
    {
        if (ctx.IsPreview || ctx.IsCommunicationSandboxed)
        {
            ctx.SetActionResult(isSuccess: true, "Simulated order creation.");
            return;
        }

        // Real side effect here.
        ctx.SetActionResult(isSuccess: true, "Order created.");
        ctx.SetPlaceholder("order_id", "1234");
    }
}
```

## Functions, actions, and conditions
### `IChatFunction` (LLM tools)
Functions are surfaced to the model through `ChatAIze.GenerativeCS` and can also power workflows.

Key behaviors (from the contracts and host usage):
- Names are normalized to snake_case when sent to providers.
- If `Parameters` is `null`, hosts often infer a schema from `Callback` via reflection.
- `RequiresDoubleCheck` is a safety flag; `ChatAIze.GenerativeCS` implements it by forcing a double tool call.

Tips:
- Keep function names globally unique across plugins to avoid ambiguity.
- Avoid lambdas if you rely on auto-naming; compiler-generated method names can be unstable.
- Prefer simple parameter types; complex graphs do not map cleanly to provider schemas.

### `IFunctionAction` (workflow steps)
Actions are used in the ChatAIze dashboard function builder to compose workflows. The host binds action settings
into the callback parameters.

Binding rules in the default host (`ChatAIze.Utilities.Extensions.DelegateExtensions`):
- `IActionContext` and `CancellationToken` parameters are injected by type.
- Other parameters are bound by exact name or snake_case.
- Missing/invalid values mark the action as failed.

Tips:
- For action/condition settings IDs, use identifier-like keys (`customer_email`, `timeout_seconds`). Avoid `:` or `-`
  because they cannot map to C# parameter names.
- Keep `SettingsCallback` deterministic and fast; it is called frequently by the dashboard.
- Use `PlaceholdersCallback` to declare outputs. In `ChatAIze.Chatbot` placeholder ids are normalized to snake_case and
  duplicates are suffixed (`order_id`, `order_id_2`, ...).

### `IFunctionCondition` (guards)
Conditions are evaluated before running a workflow. The callback may return:
- `true` to allow execution
- `false` to deny without a message
- a string/object to deny with a reason (host may surface it to admins)

## Settings and UI abstractions
Settings shape the dashboard UI and provide config values to plugins and workflows.

Core types:
- `ISetting`: stable `Id` used for persistence and value binding.
- Containers: `ISettingsSection`, `ISettingsGroup`, `ISettingsContainer`.
- Inputs: `IStringSetting`, `IBooleanSetting`, `IIntegerSetting`, `IDecimalSetting`, `ISelectionSetting`,
  `IListSetting`, `IMapSetting`, `IDateTimeSetting`.
- UI hints: `TextFieldType`, `SelectionSettingStyle`, `IntegerSettingStyle`, `BooleanSettingStyle`, `DateTimeSettingStyle`.

Conventions used in `ChatAIze.Chatbot`:
- Settings values are stored as JSON under the setting `Id`.
- `IDefaultValueObject.DefaultValueObject` is used to fill missing values in action/condition placements.
- Styles are best-effort; hosts may ignore or downgrade them.

Tips:
- Use namespacing for plugin-level settings (`myplugin:api_key`) to avoid collisions.
- Changing a setting `Id` is a breaking change for persisted data.
- Use `IsDisabled` to gray out settings, but do not rely on it for security.
- `ISettingsButton.Callback` runs on the server; keep it idempotent and respect cancellation tokens.

## Databases
ChatAIze includes a lightweight, host-managed database abstraction for structured records.

Key contracts:
- `IDatabaseManager` provides CRUD, querying, and filtering.
- `IDatabase` and `IDatabaseItem` are the records.
- `IDatabaseFilter` + `IDatabaseSorting` provide query shaping.
- Exceptions (for host validation): `DuplicateTitleException`, `InvalidTitleException`, `PropertyException`.

Actual behavior in `ChatAIze.Chatbot` (important for plugin authors):
- Titles and property names are normalized to snake_case for comparisons (`ToSnakeLower`).
- Properties are stored as strings; numeric/date comparisons parse from string values.
- `FilterOptions.IgnoreCase` and `FilterOptions.IgnoreDiacritics` are supported.
- Sorting expects the property to exist; missing properties can throw.
- Delete semantics can be soft or hard depending on host settings (`EnableTrash`).

Example query:
```csharp
var db = await context.Databases.FindDatabaseByTitleAsync("Contacts", ct);
if (db is null) return;

var filter = new DatabaseFilter("email", FilterType.Equal, "user@example.com", FilterOptions.IgnoreCase);
var contact = await context.Databases.GetFirstItemAsync(db, sorting: null, cancellationToken: ct, filters: filter);
```

Warnings:
- Do not construct your own `IDatabase` or `IDatabaseItem` implementations and pass them into a host manager. In
  `ChatAIze.Chatbot`, the manager expects its own `CustomDatabase` and `DatabaseItem` types and will throw otherwise.
- When using numeric comparisons (`GreaterThan`, `LessThan`, ...), ensure values are parseable as numbers or dates.

## Retrieval and knowledge search
`IRetrievalResult` and `IRetrievalItem` model semantic search hits.

In `ChatAIze.Chatbot`, `IFunctionContext.SearchKnowledgeAsync` returns both:
- `Items`: displayable snippets (title, description, content, optional source URL).
- `ChunkIds`: internal identifiers for the exact chunks used. Pass them back as `ignoredChunkIds` to avoid repeats.

Tips:
- `IRetrievalItem.Content` is often truncated. Call `GetDocumentContentAsync` for the full content.
- Use `TranslationLanguage` to scope search results by language.

## Localization and security
- `TranslationLanguage` is a ChatAIze-specific enum (not BCP-47). Hosts typically provide mapping from locale codes.
  `ChatAIze.Chatbot` uses a dedicated converter to map `en-US`, `fr-CA`, etc. to enum values.
- `SecurityRole` controls dashboard access levels and can be used in conditions/actions to gate admin-only operations.

## Tips, warnings, and limitations (real-world notes)
- **Side effects**: Always honor `IChatContext.IsPreview` and `IsCommunicationSandboxed` when doing external IO
  (emails, HTTP calls, payments). Return simulated results in preview mode.
- **Schema binding**: Action and function parameters are bound by name, usually in snake_case. Mismatched names lead to
  missing-parameter errors. Keep parameter names aligned with setting `Id`s.
- **Plugin isolation**: Plugins are loaded in an isolated `AssemblyLoadContext`. Sharing types across host and plugin
  requires a shared assembly (such as `ChatAIze.Abstractions` or `ChatAIze.PluginApi`).
- **Thread safety**: Plugins are effectively singletons; callbacks may execute concurrently for multiple chats.
  Store per-chat state in the provided context objects, not on the plugin instance.
- **Not all hosts implement everything**: The abstractions expose optional capabilities. Expect no-ops or exceptions for
  features like CAPTCHA, feedback UI, and intelligence level switching.
- **Untrusted input**: Settings values, form submissions, and user properties are JSON persisted data.
  Validate and sanitize before use.

## Related projects
- `ChatAIze.Chatbot`: reference host implementation of these interfaces.
- `ChatAIze.PluginApi`: convenient concrete implementations for plugin authors.
- `ChatAIze.GenerativeCS`: tool schema generation and provider integration.
- `ChatAIze.Utilities`: argument binding helpers (`DelegateExtensions`) used by the host.

## Links
- GitHub: https://github.com/chataize/abstractions
- Chataize organization: https://github.com/chataize
- Website: https://www.chataize.com

## License
GPL-3.0-or-later. See `LICENSE` for details.
