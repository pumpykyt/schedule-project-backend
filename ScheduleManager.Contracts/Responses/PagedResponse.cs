using ScheduleManager.Contracts.Requests;

namespace ScheduleManager.Contracts.Responses;

public class PagedResponse<T> 
{
    public List<T> Data { get; set; }
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public int? TotalDataCount { get; set; }

    public PagedResponse(List<T> data, int? pageNumber, int? pageSize, int? totalCount)
    {
        Data = data;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalDataCount = totalCount;
    }
}