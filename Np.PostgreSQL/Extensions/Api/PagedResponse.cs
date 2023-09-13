namespace Np.PostgreSQL.Extensions.Api;

/// <summary>
/// Generic paged response model
/// </summary>
public class PagedResponse<T>
{
    /// <summary>
    /// Page's items
    /// </summary>
    public T[] Items { get; set; }

    /// <summary>
    /// Current page
    /// </summary>
    public int CurrentPage { get; set; }

    /// <summary>
    /// Page size
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// Total pages
    /// </summary>
    public int TotalPages { get; set; }

    /// <summary>
    /// Total count
    /// </summary>
    public int TotalCount { get; set; }

    /// <summary>
    /// Has previous
    /// </summary>
    public bool HasPrevious => CurrentPage > 1;

    /// <summary>
    /// Has next
    /// </summary>
    public bool HasNext => CurrentPage < TotalPages;
}