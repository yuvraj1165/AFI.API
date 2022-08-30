using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFI.API.Models
{
    public class CustomerRegistrationDTO
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string PolicyHolderFirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string PolicyHolderLastName { get; set; }

        [Required, MaxLength(9), MinLength(9)]
        public string PolicyReferenceNumber { get; set; }

        public DateTime DOB { get; set; }

        public string PolicyHolderEmail { get; set; }
    }
}