namespace ChatAIze.Abstractions.Databases;

/// <summary>
/// Provides CRUD access to host-managed custom databases and their items.
/// </summary>
/// <remarks>
/// This abstraction is used by ChatAIze.Chatbot and plugins to manage lightweight structured data.
/// Implementations typically:
/// <list type="bullet">
/// <item><description>normalize titles/keys for lookups (see <see cref="IDatabase.NormalizedTitle"/>),</description></item>
/// <item><description>store item properties as strings,</description></item>
/// <item><description>apply filters/sorting during queries,</description></item>
/// <item><description>support soft delete depending on host configuration.</description></item>
/// </list>
/// </remarks>
public interface IDatabaseManager
{
    #region Databases

    /// <summary>
    /// Creates a new database.
    /// </summary>
    /// <param name="title">Display title.</param>
    /// <param name="description">Optional description.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <exception cref="ChatAIze.Abstractions.Databases.Exceptions.DuplicateTitleException">A database with the same (normalized) title already exists.</exception>
    /// <returns>The created database.</returns>
    public Task<IDatabase> CreateDatabaseAsync(string title, string? description = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns an asynchronous stream of databases visible to the caller.
    /// </summary>
    /// <remarks>
    /// Whether deleted databases are included is host-defined.
    /// </remarks>
    public IAsyncEnumerable<IDatabase> GetAllDatabasesAsync();

    /// <summary>
    /// Finds a database by id.
    /// </summary>
    public Task<IDatabase?> FindDatabaseByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Finds a database by title.
    /// </summary>
    /// <remarks>
    /// Hosts commonly normalize <paramref name="title"/> when searching.
    /// </remarks>
    public Task<IDatabase?> FindDatabaseByTitleAsync(string title, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates a database title.
    /// </summary>
    public Task SetTitleAsync(IDatabase database, string title, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates a database description.
    /// </summary>
    public Task SetDescriptionAsync(IDatabase database, string? description, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a database.
    /// </summary>
    /// <remarks>
    /// Deletion semantics (soft vs. hard) are host-defined.
    /// </remarks>
    public Task DeleteAsync(IDatabase database, CancellationToken cancellationToken = default);

    #endregion

    #region Items

    /// <summary>
    /// Creates a new item/record in a database.
    /// </summary>
    /// <param name="database">Target database.</param>
    /// <param name="title">Item title (display value).</param>
    /// <param name="description">Optional item description.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <param name="properties">Initial property values (property title/name -&gt; value).</param>
    /// <returns>The created item.</returns>
    public Task<IDatabaseItem> CreateItemAsync(IDatabase database, string title, string? description = null, CancellationToken cancellationToken = default, params IEnumerable<KeyValuePair<string, string?>> properties);

    /// <summary>
    /// Queries items from a database.
    /// </summary>
    /// <param name="database">Target database.</param>
    /// <param name="skip">Number of items to skip (paging).</param>
    /// <param name="count">Maximum number of items to return.</param>
    /// <param name="sorting">Optional sorting rule.</param>
    /// <param name="filters">Optional filters to apply.</param>
    /// <returns>An async stream of matching items.</returns>
    /// <remarks>
    /// Sorting and filtering behavior is host-defined. In ChatAIze.Chatbot, <see cref="IDatabaseSorting.Property"/> is expected to be the
    /// normalized property key (snake_case) used in <see cref="IDatabaseItem.Properties"/>.
    /// </remarks>
    public IAsyncEnumerable<IDatabaseItem> QueryItemsAsync(IDatabase database, int skip = 0, int count = 10, IDatabaseSorting? sorting = null, params IEnumerable<IDatabaseFilter> filters);

    /// <summary>
    /// Returns the first matching item for a query.
    /// </summary>
    public Task<IDatabaseItem?> GetFirstItemAsync(IDatabase database, IDatabaseSorting? sorting = null, CancellationToken cancellationToken = default, params IEnumerable<IDatabaseFilter> filters);

    /// <summary>
    /// Finds an item by id.
    /// </summary>
    public Task<IDatabaseItem?> FindItemByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Finds an item in a database by title.
    /// </summary>
    /// <remarks>
    /// Hosts commonly normalize <paramref name="title"/> when searching.
    /// </remarks>
    public Task<IDatabaseItem?> FindItemByTitleAsync(IDatabase database, string title, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an item's title.
    /// </summary>
    public Task SetTitleAsync(IDatabaseItem item, string title, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an item's description.
    /// </summary>
    public Task SetDescriptionAsync(IDatabaseItem item, string? description, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds a new property to an item.
    /// </summary>
    /// <remarks>
    /// Hosts may normalize property titles and may treat existing properties as an error or as an update.
    /// </remarks>
    public Task AddPropertyAsync(IDatabaseItem item, string title, string? value, CancellationToken cancellationToken = default);

    /// <summary>
    /// Sets a property value on an item (create-or-update).
    /// </summary>
    public Task SetPropertyAsync(IDatabaseItem item, string title, string? value, CancellationToken cancellationToken = default);

    /// <summary>
    /// Replaces all properties on an item.
    /// </summary>
    public Task SetPropertiesAsync(IDatabaseItem item, IEnumerable<KeyValuePair<string, string?>> properties, CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes a property from an item.
    /// </summary>
    public Task RemovePropertyAsync(IDatabaseItem item, string title, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes an item.
    /// </summary>
    /// <remarks>
    /// Deletion semantics (soft vs. hard) are host-defined.
    /// </remarks>
    public Task DeleteAsync(IDatabaseItem item, CancellationToken cancellationToken = default);

    #endregion
}
