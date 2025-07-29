namespace itransition_task4_server.Helpers
{
    public sealed record PagedResponse<T>(
        IEnumerable<T> Items,
        int TotalCount,
        int Page,
        int PageSize
        );
}
