using JewelleryAssignmentClient.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryAssignmentClient
{
    public class Estimate
    {
        private EstimateResponse _response = default;
        public EstimateResponse Response { get { return _response; } }
        private readonly ServiceClient _serviceClient;
        public Estimate()
        {
            _serviceClient = new ServiceClient();
        }

        public void CalculateEstimate()
        {
            var account = Account.GetObject();
            decimal discount = 0;

            Console.WriteLine("Gold Price (Per gram): ");
            decimal pricePerGraom = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Weight (grams)");
            decimal weight = Convert.ToDecimal(Console.ReadLine());

            if (account.User.IsPrivilegdUser)
            {
                Console.WriteLine("Discount %: ");
                discount = Convert.ToDecimal(Console.ReadLine());
            }

            Console.WriteLine("Press any key to calculate");
            Console.ReadLine();

            
            EstimateRequest request = new EstimateRequest()
            {
                UserName = account.User.userName,
                password = "test",
                Weight = weight,
                PricePerGram = pricePerGraom,
                discount = discount
            };           

            try
            {
                Task.Run(async () => {
                    _response = await _serviceClient.PostAsync<EstimateRequest, EstimateResponse>("api/Estimate/Gold", request, account.User.userName, "12345");
                }).Wait();
            }
            catch(AggregateException ex)
            {
                foreach(var e in ex.Flatten().InnerExceptions)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
            Console.WriteLine("Total Price: " + _response.TotalPrice);
            
        }
    }
}
