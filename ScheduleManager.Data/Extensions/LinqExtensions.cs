namespace ScheduleManager.Data.Extensions;

public static class LinqExtensions
{
    public static IQueryable<T> Page<T>(this IQueryable<T> data, int pageNumber, int pageSize) 
        => data.Skip(pageNumber * pageSize).Take(pageSize);
}