namespace Readify.KnockKnock.Api.Models
{
    public class PackageSearchCriteriaRequest
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string Council { get; set; }
        public string State { get; set; }
        public string CompanyId { get; set; }
        public string ActingFor { get; set; }
    }
}