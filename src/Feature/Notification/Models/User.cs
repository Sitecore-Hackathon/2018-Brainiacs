using System;

namespace Notification.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string FireBaseRegistrationId { get; set; }
        public string ProfileImageUrl { get; set; }
        public string DeviceType { get; set; }
        public string Group { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
    }
}