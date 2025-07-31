using FortressAuth.Domain.Entities.Base;

namespace FortressAuth.Domain.Entity
{
    public class User : DefaultEntityGuid
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public string Role { get; private set; }
        public string Description { get; private set; }

        public User(string name, string email, string passwordHash, string role) : base()
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be null or empty.", nameof(email));
            }
            if (string.IsNullOrWhiteSpace(passwordHash))
            {
                throw new ArgumentException("Password hash cannot be null or empty.", nameof(passwordHash));
            }
            if (string.IsNullOrWhiteSpace(role))
            {
                throw new ArgumentException("Role cannot be null or empty.", nameof(role));
            }

            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            Role = role;
        }

        public void ChangeName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
            {
                throw new ArgumentException("New name cannot be null or empty.", nameof(newName));
            }

            Name = newName;
        }

        public void SetNewPasswordHash(string newPasswordHash)
        {
            if (string.IsNullOrWhiteSpace(newPasswordHash))
            {
                throw new ArgumentException("New password hash cannot be null or empty.", nameof(newPasswordHash));
            }

            PasswordHash = newPasswordHash;
        }

        public void SetDescription(string description)
        {
            Description = description;
        }
    }
}
