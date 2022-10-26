namespace ContactService.Entity.DTOs
{
    public class UserDto
    {
        public UserDto()
        {
            ContactDtos = new List<ContactDto>();
        }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CompanyName { get; set; }
        public ICollection<ContactDto> ContactDtos { get; set; }
    }
}
