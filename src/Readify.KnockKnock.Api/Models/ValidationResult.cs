using System;

namespace Readify.KnockKnock.Api.Models
{
    public class ValidationResult
    {
        public AggregateException Exception { get; set; }
        public bool IsValid { get; set; }
    }
}
