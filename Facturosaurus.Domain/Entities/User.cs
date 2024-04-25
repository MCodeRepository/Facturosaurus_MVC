using System;

namespace Facturosaurus.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Active { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
