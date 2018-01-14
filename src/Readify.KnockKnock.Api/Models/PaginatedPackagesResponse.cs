namespace Readify.KnockKnock.Api.Models
{
    public class PaginatedPackagesResponse
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public PackageResponse[] Packages { get; set; }
    }
}