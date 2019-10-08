using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Conferences.Api.Models
{
    public class ConferenceCreate : IValidatableObject
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public bool Attending { get; set; }
        public bool Speaking { get; set; }
        [Required]
        public string FocusTopic { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(FocusTopic.ToUpper() == "PHP")
            {
                yield return new ValidationResult("No. I'm not going...", new string[] { "FocusTopic" });
            }
        }
    }
}
