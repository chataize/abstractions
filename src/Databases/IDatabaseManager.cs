namespace ChatAIze.Abstractions.Databases;

public interface IDatabaseManager
{
    #region Databases

    public Task CreateDatabaseAsync(string title, string? description = null);

    public Task<IReadOnlyList<IDatabase>> GetAllDatabasesAsync();

    public Task<IDatabase?> FindDatabaseAsync(Guid id);

    public Task<IDatabase?> FindDatabaseAsync(string title);

    public Task SetTitleAsync(IDatabase database, string title);

    public Task SetDescriptionAsync(IDatabase database, string? description);

    public Task DeleteAsync(IDatabase database);

    #endregion

    #region Items

    public Task AddAsync(IDatabase database, IDatabaseItem item);

    public Task<IReadOnlyList<IDatabaseItem>> FindItemsAsync(IDatabase database, string? search = null, int count = 10, IDatabaseSorting? sorting = null, params IEnumerable<IDatabaseFilter> filters);

    public Task<IDatabaseItem> FindFirstItemAsync(IDatabase database, string? search = null, params IEnumerable<IDatabaseFilter> filters);

    public Task SetTitleAsync(IDatabaseItem item, string title);

    public Task SetDescriptionAsync(IDatabaseItem item, string? description);

    public Task SetPropertyAsync(IDatabaseItem item, string property, string? value);

    public Task SetPropertiesAsync(IDatabaseItem item, IReadOnlyDictionary<string, string?> properties);

    public Task DeleteAsync(IDatabaseItem item);

    #endregion
}
