namespace JewelleryAssignmentClient
{
    public class EstimateResponse
    {
        public decimal PricePerGram { get; set; }

        public decimal Weight { get; set; }

        public decimal TotalPrice { get; set; }
    }

    public class EstimateRequest : LoginDTO
    {
        public decimal PricePerGram { get; set; }

        public decimal Weight { get; set; }

        public decimal discount { get; set; }
    }
}
