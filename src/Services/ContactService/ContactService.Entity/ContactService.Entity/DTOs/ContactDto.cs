namespace ContactService.Entity.DTOs
{
    public class ContactDto
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Guid UserId { get; set; }
    }
}
