using System.ComponentModel.DataAnnotations;

namespace MinneapolisMachines.App.Models.Accounts
{
    public class AppUserViewModel
    {
        [Key]
        public string UserId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}