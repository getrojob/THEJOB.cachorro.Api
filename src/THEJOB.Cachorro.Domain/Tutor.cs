using System.Diagnostics.CodeAnalysis;

namespace THEJOB.Cachorro.Domain
{
    [ExcludeFromCodeCoverage]
    public class Tutor : BaseEntity<long>
    {
        public long CPF { get; set; }
    }
}