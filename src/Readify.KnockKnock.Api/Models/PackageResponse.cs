using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Readify.KnockKnock.Api.Models
{
    public class PackageResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CompanyId { get; set; }
        public string Council { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ActingFor ActingFor { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public State State { get; set; }
        public PackageCertificate[] Certificates { get; set; }
    }
}