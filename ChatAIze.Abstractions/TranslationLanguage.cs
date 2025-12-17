namespace ChatAIze.Abstractions;

/// <summary>
/// Represents a language used for translation, localization, and content filtering in ChatAIze.
/// </summary>
/// <remarks>
/// This enum is used throughout ChatAIze.Chatbot for:
/// <list type="bullet">
/// <item><description>user language preference (<c>IUserContext.Language</c>),</description></item>
/// <item><description>document/prompt language selection and filtering,</description></item>
/// <item><description>UI language pickers.</description></item>
/// </list>
/// <para>
/// It is not an ISO/BCP-47 code list. Hosts typically provide mapping utilities from system/browser locale codes to these values.
/// </para>
/// </remarks>
public enum TranslationLanguage
{
    /// <summary>
    /// No specific language selected.
    /// </summary>
    Unspecified,

    /// <summary>
    /// Arabic language.
    /// </summary>
    Arabic,

    /// <summary>
    /// Catalan language.
    /// </summary>
    Catalan,

    /// <summary>
    /// Traditional Chinese as used in Hong Kong.
    /// </summary>
    ChineseHongKongTraditional,

    /// <summary>
    /// Simplified Chinese.
    /// </summary>
    ChineseSimplified,

    /// <summary>
    /// Traditional Chinese.
    /// </summary>
    ChineseTraditional,

    /// <summary>
    /// Croatian language.
    /// </summary>
    Croatian,

    /// <summary>
    /// Czech language.
    /// </summary>
    Czech,

    /// <summary>
    /// Danish language.
    /// </summary>
    Danish,

    /// <summary>
    /// Dutch language.
    /// </summary>
    Dutch,

    /// <summary>
    /// English language (general).
    /// </summary>
    English,

    /// <summary>
    /// Canadian English.
    /// </summary>
    EnglishCanada,

    /// <summary>
    /// Australian English.
    /// </summary>
    EnglishAustralia,

    /// <summary>
    /// Indian English.
    /// </summary>
    EnglishIndia,

    /// <summary>
    /// British English.
    /// </summary>
    EnglishUK,

    /// <summary>
    /// American English.
    /// </summary>
    EnglishUS,

    /// <summary>
    /// Finnish language.
    /// </summary>
    Finnish,

    /// <summary>
    /// French language.
    /// </summary>
    French,

    /// <summary>
    /// Canadian French.
    /// </summary>
    FrenchCanada,

    /// <summary>
    /// German language.
    /// </summary>
    German,

    /// <summary>
    /// Greek language.
    /// </summary>
    Greek,

    /// <summary>
    /// Hebrew language.
    /// </summary>
    Hebrew,

    /// <summary>
    /// Hindi language.
    /// </summary>
    Hindi,

    /// <summary>
    /// Hungarian language.
    /// </summary>
    Hungarian,

    /// <summary>
    /// Indonesian language.
    /// </summary>
    Indonesian,

    /// <summary>
    /// Italian language.
    /// </summary>
    Italian,

    /// <summary>
    /// Japanese language.
    /// </summary>
    Japanese,

    /// <summary>
    /// Korean language.
    /// </summary>
    Korean,

    /// <summary>
    /// Malay language.
    /// </summary>
    Malay,

    /// <summary>
    /// Norwegian Bokmål.
    /// </summary>
    NorwegianBokmal,

    /// <summary>
    /// Polish language.
    /// </summary>
    Polish,

    /// <summary>
    /// Brazilian Portuguese.
    /// </summary>
    PortugueseBrazil,

    /// <summary>
    /// European Portuguese.
    /// </summary>
    PortuguesePortugal,

    /// <summary>
    /// Romanian language.
    /// </summary>
    Romanian,

    /// <summary>
    /// Russian language.
    /// </summary>
    Russian,

    /// <summary>
    /// Slovak language.
    /// </summary>
    Slovak,

    /// <summary>
    /// Spanish language.
    /// </summary>
    Spanish,

    /// <summary>
    /// Mexican Spanish.
    /// </summary>
    SpanishMexico,

    /// <summary>
    /// Swedish language.
    /// </summary>
    Swedish,

    /// <summary>
    /// Thai language.
    /// </summary>
    Thai,

    /// <summary>
    /// Turkish language.
    /// </summary>
    Turkish,

    /// <summary>
    /// Ukrainian language.
    /// </summary>
    Ukrainian,

    /// <summary>
    /// Vietnamese language.
    /// </summary>
    Vietnamese
}
