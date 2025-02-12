namespace ChatAIze.Abstractions.Databases;

public interface IDatabaseManager
{
    #region Databases

    public Task<IDatabase> CreateDatabaseAsync(string title, string? description = null, CancellationToken cancellationToken = default);

    public IAsyncEnumerable<IDatabase> GetAllDatabasesAsync();

    public Task<IDatabase?> FindDatabaseByIdAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<IDatabase?> FindDatabaseByTitleAsync(string title, CancellationToken cancellationToken = default);

    public Task SetTitleAsync(IDatabase database, string title, CancellationToken cancellationToken = default);

    public Task SetDescriptionAsync(IDatabase database, string? description, CancellationToken cancellationToken = default);

    public Task DeleteAsync(IDatabase database, CancellationToken cancellationToken = default);

    #endregion

    #region Items

    public Task<IDatabaseItem> CreateItemAsync(IDatabase database, string title, string? description = null, CancellationToken cancellationToken = default, params IEnumerable<KeyValuePair<string, string?>> properties);

    public IAsyncEnumerable<IDatabaseItem> QueryItemsAsync(IDatabase database, int skip = 0, int count = 10, IDatabaseSorting? sorting = null, params IEnumerable<IDatabaseFilter> filters);

    public Task<IDatabaseItem?> GetFirstItemAsync(IDatabase database, IDatabaseSorting? sorting = null, CancellationToken cancellationToken = default, params IEnumerable<IDatabaseFilter> filters);

    public Task<IDatabaseItem?> FindItemByIdAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<IDatabaseItem?> FindItemByTitleAsync(IDatabase database, string title, CancellationToken cancellationToken = default);

    public Task SetTitleAsync(IDatabaseItem item, string title, CancellationToken cancellationToken = default);

    public Task SetDescriptionAsync(IDatabaseItem item, string? description, CancellationToken cancellationToken = default);

    public Task AddPropertyAsync(IDatabaseItem item, string title, string? value, CancellationToken cancellationToken = default);

    public Task SetPropertyAsync(IDatabaseItem item, string title, string? value, CancellationToken cancellationToken = default);

    public Task SetPropertiesAsync(IDatabaseItem item, IEnumerable<KeyValuePair<string, string?>> properties, CancellationToken cancellationToken = default);

    public Task RemovePropertyAsync(IDatabaseItem item, string title, CancellationToken cancellationToken = default);

    public Task DeleteAsync(IDatabaseItem item, CancellationToken cancellationToken = default);

    #endregion
}
