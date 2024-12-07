using AnhTran.RedactingSensitiveData.Taxonomy;

namespace AnhTran.RedactingSensitiveData.Models
{
    public class User
    {
        public int Id { get; set; }        
        public string? FullName { get; set; }
        [PersonalData]
        public string? Adddress { get; set; }
        [PersonalData]
        public string? Email { get; set; }
        [PersonalData]
        public DateTime DateOfBirth { get; set; }
        public string? FavouritSport { get; set; } // Unclassified

        [SensitiveData]
        public string? Religious { get; set; }
        [SensitiveData]
        public string? Ethnic { get; set; }

        [FinancialData]
        public string? CreditCardNumbers { get; set; }
        [FinancialData]
        public double Salary { get; set; }

        public DateTime JoinDate { get; set; } // Unclassified
    }
}
