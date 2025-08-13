namespace FortressAuth.Application.DTOs.User
{
    public class GetUserDTO
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime? InclusionDateTimeGreaterThan { get; set; }
        public DateTime? InclusionDateTimeLessThan { get; set; }
        public DateTime? ChangeDateTimeGreaterThan { get; set; }
        public DateTime? ChangeDateTimeLessThan { get; set; }
    }
}
