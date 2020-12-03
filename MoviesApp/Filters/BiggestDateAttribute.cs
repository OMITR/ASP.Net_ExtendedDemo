using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Filters
{
    public class BiggestDateAttribute : ValidationAttribute
    {
        public BiggestDateAttribute(int year)
        {
            Year = year;
        }

        public int Year { get; }

        public string GetErrorMessage() =>
            $"Actor must be born in or after {Year}.";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var birthDate = ((DateTime)value).Year;

            if (birthDate < Year)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
