using Microsoft.Extensions.Compliance.Classification;

namespace AnhTran.RedactingSensitiveData.Taxonomy
{
    public class PersonalDataAttribute : DataClassificationAttribute
    {
        public PersonalDataAttribute() : base(MyTaxonomy.PersonalData) { }
    }
}
