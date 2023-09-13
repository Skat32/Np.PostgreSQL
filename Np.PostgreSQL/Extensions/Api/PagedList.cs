namespace Np.PostgreSQL.Extensions.Api;

/// <summary>
/// Paged list
/// </summary>
/// <typeparam name="T"></typeparam>
public class PagedList<T> : List<T>
{
    /// <summary>
    /// Current page
    /// </summary>
    public int CurrentPage { get; private set; }

    /// <summary>
    /// Total pages
    /// </summary>
    public int TotalPages { get; private set; }

    /// <summary>
    /// Page size
    /// </summary>
    public int PageSize { get; private set; }

    /// <summary>
    /// Total count
    /// </summary>
    public int TotalCount { get; private set; }

    /// <param name="items"></param>
    /// <param name="totalCount"></param>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    public PagedList(
        IEnumerable<T> items,
        int totalCount,
        int pageNumber,
        int pageSize)
    {
        TotalCount = totalCount;
        CurrentPage = pageNumber;
        PageSize = pageSize;
        TotalPages = (int) Math.Ceiling(totalCount / (double) pageSize);

        AddRange(items);
    }
}