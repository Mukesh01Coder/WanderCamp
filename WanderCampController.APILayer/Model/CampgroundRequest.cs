using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanderCamp.Domain.Models;

namespace WanderCampController.APILayer.Model
{
    public class CampgroundRequest
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public decimal PricePerNight { get; set; }
        public int MaxOccupancy { get; set; }
        public string ErrorMessage { get; internal set; }

        public CampgroundRequest() { }

        public CampgroundRequest(Campground campground)
        {
            Name = campground.CampgroundName;
            Description = campground.CampgroundDescription;
            Location = campground.CampgroundLocation;
            PricePerNight = campground.PricePerNight;
            MaxOccupancy = campground.MaxOccupancy;
        }
    }
}
