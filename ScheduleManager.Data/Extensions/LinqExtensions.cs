namespace ScheduleManager.Data.Extensions;

public static class LinqExtensions
{
    public static IQueryable<T> Page<T>(this IQueryable<T> data, int pageNumber, int pageSize) 
        => data.Skip((pageNumber - 1) * pageSize).Take(pageSize);
}