namespace EmployeeManagement.Repository.Domain
{
    public class Phone
    {
        public Guid PhoneId { get; set; }
        public Guid? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public string PhoneNumber { get; set; }
        public PhoneTypeEnums PhoneType { get; set; }

    }
}
