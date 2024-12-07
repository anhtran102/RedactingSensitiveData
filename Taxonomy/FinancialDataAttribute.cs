using Microsoft.Extensions.Compliance.Classification;

namespace AnhTran.RedactingSensitiveData.Taxonomy
{
    public class FinancialDataAttribute : DataClassificationAttribute
    {
        public FinancialDataAttribute() : base(MyTaxonomy.FinancialData) { }
    }
}
