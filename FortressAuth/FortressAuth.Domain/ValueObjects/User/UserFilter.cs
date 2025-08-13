namespace FortressAuth.Domain.ValueObjects.User
{
    public class UserFilter
    {
        public UserFilter(
            Guid? id, 
            string? name, 
            string? email,
            DateTime? dhInclusionGreaterThan, 
            DateTime? dhInclusionLessThan, 
            DateTime? dhChangeGreaterThan, 
            DateTime? dhChangeLessThan)
        {
            Id = id;
            Name = name;
            Email = email;
            DhInclusionGreaterThan = dhInclusionGreaterThan;
            DhInclusionLessThan = dhInclusionLessThan;
            DhChangeGreaterThan = dhChangeGreaterThan;
            DhChangeLessThan = dhChangeLessThan;
        }

        public Guid? Id { get; private set; }
        public string? Name { get; private set; }
        public string? Email { get; private set; }
        public DateTime? DhInclusionGreaterThan { get; private set; }
        public DateTime? DhInclusionLessThan { get; private set; }
        public DateTime? DhChangeGreaterThan { get; private set; }
        public DateTime? DhChangeLessThan { get; private set; }
    }
}
