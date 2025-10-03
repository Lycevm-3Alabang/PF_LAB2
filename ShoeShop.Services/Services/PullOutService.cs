using AutoMapper;
using ShoeShop.Repository.Interfaces;
using ShoeShop.Services.DTOs;
using ShoeShop.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoeShop.Services.Services
{
    // Implementation ng Pull Out Service
    public class PullOutService : IPullOutService
    {
        private readonly IStockPullOutRepository _pullOutRepository;
        private readonly IMapper _mapper;

        // Constructor para sa Dependency Injection
        public PullOutService(IStockPullOutRepository pullOutRepository, IMapper mapper)
        {
            _pullOutRepository = pullOutRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StockPullOutDto>> GetAllPullOutsAsync()
        {
            // Kukunin ang lahat ng pull out entities mula sa repository
            var pullOuts = await _pullOutRepository.GetAllPullOutsAsync();

            // I-ma-map ang entities sa DTOs bago i-return
            return _mapper.Map<IEnumerable<StockPullOutDto>>(pullOuts);
        }
    }
}
