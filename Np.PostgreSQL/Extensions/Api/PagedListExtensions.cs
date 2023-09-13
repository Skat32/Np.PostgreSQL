namespace Np.PostgreSQL.Extensions.Api;

/// <summary>
/// Расширение для преобразования коллекции объектов в пагинированный список
/// </summary>
public static class PagedListExtensions
{
    /// <summary>
    /// преобразование коллекции объектов в пагинированный список
    /// </summary>
    public static PagedResponse<TTarget> ToPagedResponse<TSource, TTarget>(
        this PagedList<TSource> pagedList,
        Func<TSource, TTarget> map) =>
        new()
        {
            CurrentPage = pagedList.CurrentPage,
            PageSize = pagedList.PageSize,
            TotalCount = pagedList.TotalCount,
            TotalPages = pagedList.TotalPages,
            Items = pagedList.Select(map).ToArray()
        };

    /// <summary>
    /// преобразование коллекции объектов в пагинированный список
    /// </summary>
    public static PagedResponse<TSource> ToPagedResponse<TSource>(this PagedList<TSource> pagedList) =>
        pagedList.ToPagedResponse(source => source);
}