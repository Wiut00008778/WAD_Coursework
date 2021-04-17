using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Royality.DAL.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MinLength(3)]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Watch> Watches { get; set; }
    }
}
