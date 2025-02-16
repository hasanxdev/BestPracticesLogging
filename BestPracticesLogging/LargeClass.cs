namespace BestPracticesLogging;

public class LargeClass
{
    public string Name { get; set; } = "Default Name";
    public int Age { get; set; } = 30;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public double Salary { get; set; } = 5000.0;
    public decimal Balance { get; set; } = 1000.50m;
    public Guid UniqueId { get; set; } = Guid.NewGuid();
    public string Email { get; set; } = "example@example.com";
    public AddressDto Address { get; set; } = new AddressDto();
    public ContactInfoDto ContactInfo { get; set; } = new ContactInfoDto();
    public CompanyDetails Company { get; set; } = new CompanyDetails();
    public PreferencesDto Preferences { get; set; } = new PreferencesDto();
    public List<string> Tags { get; set; } = new List<string> { "tag1", "tag2", "tag3" };
    public Dictionary<string, int> Score { get; set; } = new Dictionary<string, int>
    {
        { "Math", 85 },
        { "Science", 90 },
        { "History", 88 }
    };
    public int[] Marks { get; set; } = { 10, 20, 30, 40, 50 };
    public string Description { get; set; } = "This is a large class for demonstration.";
    public float Temperature { get; set; } = 25.0f;
    public DateTime LastUpdated { get; set; } = DateTime.Now;
    public bool IsVerified { get; set; } = false;

    // Nested properties
    public class AddressDto
    {
        public string Street { get; set; } = "Default Street";
        public string City { get; set; } = "Default City";
        public string PostalCode { get; set; } = "12345";
        public string Country { get; set; } = "Default Country";
    }

    public class ContactInfoDto
    {
        public string PhoneNumber { get; set; } = "+1 123-456-7890";
        public string EmergencyContact { get; set; } = "+1 987-654-3210";
        public string Skype { get; set; } = "example.skype";
    }

    public class CompanyDetails
    {
        public string CompanyName { get; set; } = "Default Company";
        public string Position { get; set; } = "Employee";
        public decimal Salary { get; set; } = 3000.0m;
        public string OfficeLocation { get; set; } = "Default Office";
    }

    public class PreferencesDto
    {
        public bool ReceiveNewsletters { get; set; } = true;
        public bool DarkMode { get; set; } = false;
        public string PreferredLanguage { get; set; } = "English";
    }
}
