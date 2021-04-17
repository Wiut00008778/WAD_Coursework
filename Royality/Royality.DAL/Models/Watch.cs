using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Royality.DAL.Models
{
    public class Watch
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string ModelName { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "999999999.99")]
        public decimal Price { get; set; }

        [Range(0.0, Double.MaxValue)]
        public double Size { get; set; }

        [Range(0.0, Double.MaxValue)]
        public double GuaranteePeriod { get; set; }

        [Required]
        [MinLength(5)]
        public string Location { get; set; }

        public int? ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

    }
}
