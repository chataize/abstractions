namespace ChatAIze.Abstractions.Databases;

/// <summary>
/// Provides operations for managing databases and their items, including creation, querying, and property manipulation.
/// </summary>
public interface IDatabaseManager
{
    #region Databases

    /// <summary>
    /// Creates a new database with the specified title and optional description.
    /// </summary>
    public Task<IDatabase> CreateDatabaseAsync(string title, string? description = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns an asynchronous stream of all databases.
    /// </summary>
    public IAsyncEnumerable<IDatabase> GetAllDatabasesAsync();

    /// <summary>
    /// Finds a database by its unique identifier.
    /// </summary>
    public Task<IDatabase?> FindDatabaseByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Finds a database by its title.
    /// </summary>
    public Task<IDatabase?> FindDatabaseByTitleAsync(string title, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the title of the specified database.
    /// </summary>
    public Task SetTitleAsync(IDatabase database, string title, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the description of the specified database.
    /// </summary>
    public Task SetDescriptionAsync(IDatabase database, string? description, CancellationToken cancellationToken = default);

    /// <summary>
    /// Marks the specified database as deleted.
    /// </summary>
    public Task DeleteAsync(IDatabase database, CancellationToken cancellationToken = default);

    #endregion

    #region Items

    /// <summary>
    /// Creates a new item in the specified database with the given title, optional description, and properties.
    /// </summary>
    public Task<IDatabaseItem> CreateItemAsync(IDatabase database, string title, string? description = null, CancellationToken cancellationToken = default, params IEnumerable<KeyValuePair<string, string?>> properties);

    /// <summary>
    /// Returns an asynchronous stream of items from the database, supporting optional filtering, sorting, and paging.
    /// </summary>
    public IAsyncEnumerable<IDatabaseItem> QueryItemsAsync(IDatabase database, int skip = 0, int count = 10, IDatabaseSorting? sorting = null, params IEnumerable<IDatabaseFilter> filters);

    /// <summary>
    /// Returns the first item that matches the provided filters and optional sorting.
    /// </summary>
    public Task<IDatabaseItem?> GetFirstItemAsync(IDatabase database, IDatabaseSorting? sorting = null, CancellationToken cancellationToken = default, params IEnumerable<IDatabaseFilter> filters);

    /// <summary>
    /// Finds an item by its unique identifier.
    /// </summary>
    public Task<IDatabaseItem?> FindItemByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Finds an item in the given database by its title.
    /// </summary>
    public Task<IDatabaseItem?> FindItemByTitleAsync(IDatabase database, string title, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the title of the specified item.
    /// </summary>
    public Task SetTitleAsync(IDatabaseItem item, string title, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the description of the specified item.
    /// </summary>
    public Task SetDescriptionAsync(IDatabaseItem item, string? description, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds a new property to the specified item.
    /// </summary>
    public Task AddPropertyAsync(IDatabaseItem item, string title, string? value, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the value of an existing property on the item.
    /// </summary>
    public Task SetPropertyAsync(IDatabaseItem item, string title, string? value, CancellationToken cancellationToken = default);

    /// <summary>
    /// Replaces all properties on the item with the provided set.
    /// </summary>
    public Task SetPropertiesAsync(IDatabaseItem item, IEnumerable<KeyValuePair<string, string?>> properties, CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes a property from the specified item.
    /// </summary>
    public Task RemovePropertyAsync(IDatabaseItem item, string title, CancellationToken cancellationToken = default);

    /// <summary>
    /// Marks the specified item as deleted.
    /// </summary>
    public Task DeleteAsync(IDatabaseItem item, CancellationToken cancellationToken = default);

    #endregion
}
