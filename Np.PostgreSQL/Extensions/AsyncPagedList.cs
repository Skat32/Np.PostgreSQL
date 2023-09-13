using Microsoft.EntityFrameworkCore;
using Np.PostgreSQL.Extensions.Api;

namespace Np.PostgreSQL.Extensions;

/// <summary>
/// Paged list
/// </summary>
/// <typeparam name="T"></typeparam>
public class AsyncPagedList<T> : PagedList<T>
{
    /// <param name="source"></param>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    public static Task<AsyncPagedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
    {
        if (pageNumber <= 0) throw new ArgumentException("Page number must be greater than zero.");
        if (pageSize <= 0) throw new ArgumentException("Page size must be greater than zero.");

        return CreateInnerAsync(source, pageNumber, pageSize);
    }

    private static async Task<AsyncPagedList<T>> CreateInnerAsync(IQueryable<T> source, int pageNumber, int pageSize)
    {
        var totalCount = await source.CountAsync();
        var skipCount = (pageNumber - 1) * pageSize;
        if (totalCount == 0 || skipCount >= totalCount)
            return new AsyncPagedList<T>(Enumerable.Empty<T>(), totalCount, pageNumber, pageSize);

        var items = await source.Skip(skipCount).Take(pageSize).ToArrayAsync();

        return new AsyncPagedList<T>(items, totalCount, pageNumber, pageSize);
    }

    /// <inheritdoc />
    public AsyncPagedList(IEnumerable<T> items, int totalCount, int pageNumber,
        int pageSize) : base(items, totalCount, pageNumber, pageSize) { }
}
    
/// <summary>
/// Sync Paged list
/// </summary>
/// <typeparam name="T"></typeparam>
public class SyncPagedList<T> : PagedList<T>
{
    /// <param name="source"></param>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    public static AsyncPagedList<T> Create(ICollection<T> source, int pageNumber, int pageSize)
    {
        if (pageNumber <= 0) throw new ArgumentException("Page number must be greater than zero.");
        if (pageSize <= 0) throw new ArgumentException("Page size must be greater than zero.");

        return CreateInnerAsync(source, pageNumber, pageSize);
    }

    private static AsyncPagedList<T> CreateInnerAsync(ICollection<T> source, int pageNumber, int pageSize)
    {
        var totalCount = source.Count;
        var skipCount = (pageNumber - 1) * pageSize;
        if (totalCount == 0 || skipCount >= totalCount)
            return new AsyncPagedList<T>(Enumerable.Empty<T>(), totalCount, pageNumber, pageSize);

        var items = source.Skip(skipCount).Take(pageSize).ToArray();

        return new AsyncPagedList<T>(items, totalCount, pageNumber, pageSize);
    }

    /// <inheritdoc />
    public SyncPagedList(IEnumerable<T> items, int totalCount, int pageNumber,
        int pageSize) : base(items, totalCount, pageNumber, pageSize) { }
}