using MoviesApp.Filters;
using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Service.DTO.Mappers
{
    public class ActorDto
    {
        public int? ActorId { get; set; }

        [Required]
        [LengthCheck(4, ErrorMessage = "First Name must be longer than 4 symbols.")]
        public string FirstName { get; set; }

        [Required]
        [LengthCheck(4, ErrorMessage = "Last Name must be longer than 4 symbols.")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DateCheckFilter]
        public DateTime BirthDate { get; set; }
    }
}