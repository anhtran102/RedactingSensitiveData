using Microsoft.Extensions.Compliance.Classification;

namespace AnhTran.RedactingSensitiveData.Taxonomy
{
    public class SensitiveDataAttribute : DataClassificationAttribute
    {
        public SensitiveDataAttribute() : base(MyTaxonomy.SensitiveData) { }
    }
}
