namespace Readify.KnockKnock.Api.Models
{
    public class PackageRequest
    {
        public string Name { get; set; }
        public string CompanyId { get; set; }
        public string Council { get; set; }
        public string ActingFor { get; set; }
        public string State { get; set; }
        public PackageCertificate[] Certificates { get; set; }
    }
}
