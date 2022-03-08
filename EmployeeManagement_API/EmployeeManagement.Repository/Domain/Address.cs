namespace EmployeeManagement.Repository.Domain
{
    public class Address
    {
        public Guid AddressId { get; set; }
        public Guid? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public string StreetAddress { get; set; }
        public string? SecondLine { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
