using System.ComponentModel.DataAnnotations;
using Entities;
using ServiceContracts.Enums;

namespace ServiceContracts.DTO
{
    /// <summary>
    /// Act as a DTO for inserting a new user
    /// </summary>
    public class PersonAddRequest
    {
        [Required(ErrorMessage = "Person Name can't be blank")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Email can't be blank")]
        [EmailAddress(ErrorMessage = "Email value should be valid")]
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public GenderOptions? Gender { get; set; }
        public Guid? CountryId { get; set; }
        public string? Address { get; set; }
        public bool? ReceiveNewsLetters { get; set; }

        /// <summary>
        /// Converts the current object of PersonAddRequest into a new object of Person type
        /// </summary>
        /// <returns>Person object</returns>
        public Person ToPerson()
        {
            return new Person()
            {
                Name = this.Name,
                DateOfBirth = this.DateOfBirth,
                CountryId = this.CountryId,
                Address = this.Address,
                Gender = this.Gender.ToString(),
                ReceiveNewsLetters = this.ReceiveNewsLetters,
                Email = this.Email,
            };
        }
    }
}