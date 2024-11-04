namespace ChatAIze.Abstractions.Settings;

public interface ISelectionChoice<T>
{
    public string Label { get; }

    public T Value { get; }
}
