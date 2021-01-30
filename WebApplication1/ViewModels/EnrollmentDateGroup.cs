using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class EnrollmentDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? Year { get; set; }

        public int VehicleCount { get; set; }
    }
}