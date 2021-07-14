using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryEstimate_Assignment.DTOs
{
    public class EstimateRequestDTO : LoginDTO
    {
        public decimal PricePerGram { get; set; }

        public decimal Weight { get; set; }

        public decimal discount { get; set; }
    }
}
