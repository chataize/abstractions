namespace ChatAIze.Abstractions.Settings;

public interface IListSetting : IPluginSetting
{
    public int MaxItems { get; }

    public int MaxItemLength { get; }
}
