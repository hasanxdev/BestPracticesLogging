namespace BestPracticesLogging;

public struct LargeStruct
{
    public string Name { get; set; }
    public int Age { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }
    public double Salary { get; set; }
    public decimal Balance { get; set; }
    public Guid UniqueId { get; set; }
    public string Email { get; set; }
    public AddressDto Address { get; set; }
    public ContactInfoDto ContactInfo { get; set; }
    public CompanyDetails Company { get; set; }
    public PreferencesDto Preferences { get; set; }
    public List<string> Tags { get; set; }
    public Dictionary<string, int> Score { get; set; }
    public int[] Marks { get; set; }
    public string Description { get; set; }
    public float Temperature { get; set; }
    public DateTime LastUpdated { get; set; }
    public bool IsVerified { get; set; }

    public LargeStruct()
    {
        Name = "Default Name";
        Age = 30;
        IsActive = true;
        CreatedDate = DateTime.Now;
        Salary = 5000.0;
        Balance = 1000.50m;
        UniqueId = Guid.NewGuid();
        Email = "example@example.com";
        Address = new AddressDto();
        ContactInfo = new ContactInfoDto();
        Company = new CompanyDetails();
        Preferences = new PreferencesDto();
        Tags = new List<string> { "tag1", "tag2", "tag3" };
        Score = new Dictionary<string, int>
        {
            { "Math", 85 },
            { "Science", 90 },
            { "History", 88 }
        };
        Marks = new int[] { 10, 20, 30, 40, 50 };
        Description = "This is a large struct for demonstration.";
        Temperature = 25.0f;
        LastUpdated = DateTime.Now;
        IsVerified = false;
    }

    public struct AddressDto
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public AddressDto()
        {
            Street = "Default Street";
            City = "Default City";
            PostalCode = "12345";
            Country = "Default Country";
        }
    }

    public struct ContactInfoDto
    {
        public string PhoneNumber { get; set; }
        public string EmergencyContact { get; set; }
        public string Skype { get; set; }

        public ContactInfoDto()
        {
            PhoneNumber = "+1 123-456-7890";
            EmergencyContact = "+1 987-654-3210";
            Skype = "example.skype";
        }
    }

    public struct CompanyDetails
    {
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public string OfficeLocation { get; set; }

        public CompanyDetails()
        {
            CompanyName = "Default Company";
            Position = "Employee";
            Salary = 3000.0m;
            OfficeLocation = "Default Office";
        }
    }

    public struct PreferencesDto
    {
        public bool ReceiveNewsletters { get; set; }
        public bool DarkMode { get; set; }
        public string PreferredLanguage { get; set; }

        public PreferencesDto()
        {
            ReceiveNewsletters = true;
            DarkMode = false;
            PreferredLanguage = "English";
        }
    }
}
