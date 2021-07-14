using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JewelryEstimate_Assignment.DTOs;
using JewelryEstimate_Assignment.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JewelryEstimate_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstimateController : ControllerBase
    {
        private IUserRepository _userRepository;
        public EstimateController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        
        [HttpPost("Gold")]
        public async Task<ActionResult<EstimateResponseDTO>> EstimateGoldPrice(EstimateRequestDTO requestDTO)
        {
            var user = await _userRepository.GetUserAsync(requestDTO.UserName);

            return calculateTotalPrice(requestDTO, user.IsPrivileged);
        }

        private EstimateResponseDTO calculateTotalPrice(EstimateRequestDTO requestDTO,bool isDiscount)
        {
            decimal totalPrice = requestDTO.PricePerGram * requestDTO.Weight;
            decimal discount;
            if (isDiscount)
            {
                discount = requestDTO.discount / 100 * totalPrice;
                totalPrice = totalPrice - discount;
            }

            return new EstimateResponseDTO()
            {
                PricePerGram = requestDTO.PricePerGram,
                Weight = requestDTO.Weight,
                TotalPrice = totalPrice
            };
        }
    }
}
