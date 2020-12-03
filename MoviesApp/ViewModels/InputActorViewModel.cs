using MoviesApp.Filters;
using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.ViewModels
{
    public class InputActorViewModel
    {
        [Required]
        [StringLength(32, ErrorMessage = "First Name must be longer than 4 symbols.", MinimumLength = 4)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "Last Name must be longer than 4 symbols.", MinimumLength = 4)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [LeastDate(2013)]
        [BiggestDate(1921)]
        public DateTime BirthDate { get; set; }
    }
}
