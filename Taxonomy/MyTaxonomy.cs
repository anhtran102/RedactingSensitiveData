using Microsoft.Extensions.Compliance.Classification;

namespace AnhTran.RedactingSensitiveData.Taxonomy
{
    public static class MyTaxonomy
    {
        public static string TaxonomyName => typeof(MyTaxonomy).FullName!;        

        public static DataClassification PersonalData => new(TaxonomyName, nameof(PersonalData));
        public static DataClassification SensitiveData => new(TaxonomyName, nameof(SensitiveData));
        public static DataClassification FinancialData => new(TaxonomyName, nameof(FinancialData));
    }
}
