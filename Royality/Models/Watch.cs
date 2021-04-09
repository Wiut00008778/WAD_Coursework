using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Royality.Models
{
    public class Watch
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [DisplayName("Model")]
        public string ModelName { get; set; }

        [Required]
        [Range(0, 999999999.99)]
        public decimal Price { get; set; }

        
        public double Size { get; set; }

        
        public double GuaranteePeriod { get; set; }

        [Required]
        [MinLength(5)]
        public string Location { get; set; }

        public int? ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

    }
}
