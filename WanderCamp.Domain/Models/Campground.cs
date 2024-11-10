using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanderCamp.Domain.Models
{
    public class Campground
    {
        public int CampgroundId { get; set; }
        public string CampgroundName { get; set; }
        public string CampgroundDescription { get; set; }
        public string CampgroundLocation { get; set; }
        public decimal PricePerNight { get; set; }
        public int MaxOccupancy { get; set; }

    }
}
