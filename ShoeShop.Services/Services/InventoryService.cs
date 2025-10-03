using AutoMapper;
using ShoeShop.Repository.Entities;
using ShoeShop.Repository.Interfaces;
using ShoeShop.Services.DTOs;
using ShoeShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeShop.Services.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IShoeRepository _shoeRepository;
        private readonly IStockPullOutRepository _pullOutRepository;
        private readonly IMapper _mapper;

        public InventoryService(IShoeRepository shoeRepository,
                                IStockPullOutRepository pullOutRepository,
                                IMapper mapper)
        {
            _shoeRepository = shoeRepository;
            _pullOutRepository = pullOutRepository;
            _mapper = mapper;
        }

        // --- Shoes ---

        public async Task<ShoeDto> CreateShoeAsync(CreateShoeDto dto)
        {
            var newShoeEntity = _mapper.Map<Shoe>(dto);
            newShoeEntity.CreatedDate = DateTime.UtcNow;
            newShoeEntity.IsActive = true;

            await _shoeRepository.AddAsync(newShoeEntity);
            await _shoeRepository.SaveChangesAsync();

            return _mapper.Map<ShoeDto>(newShoeEntity);
        }

        public async Task<IEnumerable<ShoeDto>> GetAllShoesAsync()
        {
            var shoes = await _shoeRepository.GetAllWithVariationsAsync();
            return _mapper.Map<IEnumerable<ShoeDto>>(shoes);
        }

        public async Task<ShoeDto?> GetShoeByIdAsync(int id)
        {
            var shoe = await _shoeRepository.GetByIdWithVariationsAsync(id);
            return shoe == null ? null : _mapper.Map<ShoeDto>(shoe);
        }

        // FIX: Idinagdag ang missing method para ma-implement ang IInventoryService
        public async Task<int> GetStockQuantityAsync(int shoeId)
        {
            var shoe = await _shoeRepository.GetByIdWithVariationsAsync(shoeId);

            if (shoe == null)
            {
                return 0;
            }

            return shoe.ColorVariations.Sum(c => c.StockQuantity);
        }

        public async Task UpdateShoeAsync(int id, CreateShoeDto dto)
        {
            var shoeToUpdate = await _shoeRepository.GetByIdWithVariationsAsync(id);
            if (shoeToUpdate == null)
            {
                throw new KeyNotFoundException($"Shoe with ID {id} not found.");
            }

            _mapper.Map(dto, shoeToUpdate);

            // Tiyakin na ang ColorVariations ay maayos na na-u-update
            var updatedVariations = dto.ColorVariations.Select(v => _mapper.Map<ShoeColorVariation>(v)).ToList();
            shoeToUpdate.ColorVariations.Clear();
            foreach (var variation in updatedVariations)
            {
                shoeToUpdate.ColorVariations.Add(variation);
            }

            await _shoeRepository.UpdateAsync(shoeToUpdate);
            await _shoeRepository.SaveChangesAsync();
        }

        public async Task DeleteShoeAsync(int id)
        {
            var shoeToDelete = await _shoeRepository.GetByIdWithVariationsAsync(id);
            if (shoeToDelete != null)
            {
                // FIX: Ang interface ay nangangailangan ng Shoe entity, hindi ID.
                await _shoeRepository.DeleteAsync(shoeToDelete);
                await _shoeRepository.SaveChangesAsync();
            }
        }

        public async Task<bool> AdjustStockAsync(int shoeId, int quantityChange, string reason, string user)
        {
            var shoe = await _shoeRepository.GetByIdWithVariationsAsync(shoeId);
            if (shoe == null) return false;

            var variation = shoe.ColorVariations.FirstOrDefault();
            if (variation == null) return false;

            variation.StockQuantity += quantityChange;

            // Ito ang nagre-record ng Pull-Out/Stock-In Transaction
            var pullOut = new StockPullOut
            {
                ShoeColorVariationId = variation.Id,
                Quantity = Math.Abs(quantityChange), // Ginagamit ang absolute value
                Reason = reason,
                RequestedBy = user,
                PullOutDate = DateTime.UtcNow,
                Status = quantityChange > 0 ? "RECEIVED" : "PULLED_OUT" // Status based on quantityChange sign
            };

            await _pullOutRepository.AddAsync(pullOut);
            await _shoeRepository.UpdateAsync(shoe);
            await _shoeRepository.SaveChangesAsync();

            return true;
        }

        // --- Color Variations ---

        public async Task<ColorVariationDto> AddColorVariationAsync(int shoeId, CreateColorVariationDto dto)
        {
            var shoe = await _shoeRepository.GetByIdWithVariationsAsync(shoeId);
            if (shoe == null) throw new KeyNotFoundException("Shoe not found");

            var newVariation = _mapper.Map<ShoeColorVariation>(dto);
            newVariation.ShoeId = shoeId;

            shoe.ColorVariations.Add(newVariation);
            await _shoeRepository.UpdateAsync(shoe);
            await _shoeRepository.SaveChangesAsync();

            return _mapper.Map<ColorVariationDto>(newVariation);
        }

        public async Task<IEnumerable<ColorVariationDto>> GetColorVariationsByShoeIdAsync(int shoeId)
        {
            var shoe = await _shoeRepository.GetByIdWithVariationsAsync(shoeId);
            return shoe == null ? Enumerable.Empty<ColorVariationDto>()
                                  : _mapper.Map<IEnumerable<ColorVariationDto>>(shoe.ColorVariations);
        }

        public async Task<ColorVariationDto?> GetColorVariationByIdAsync(int variationId)
        {
            var allShoes = await _shoeRepository.GetAllWithVariationsAsync();
            var variation = allShoes.SelectMany(s => s.ColorVariations)
                                     .FirstOrDefault(v => v.Id == variationId);

            return variation == null ? null : _mapper.Map<ColorVariationDto>(variation);
        }

        public async Task<ColorVariationDto> UpdateColorVariationAsync(int variationId, CreateColorVariationDto dto)
        {
            var allShoes = await _shoeRepository.GetAllWithVariationsAsync();
            var shoe = allShoes.FirstOrDefault(s => s.ColorVariations.Any(v => v.Id == variationId));

            if (shoe == null) throw new KeyNotFoundException("Variation not found");

            var variationToUpdate = shoe.ColorVariations.First(v => v.Id == variationId);

            _mapper.Map(dto, variationToUpdate);

            await _shoeRepository.UpdateAsync(shoe);
            await _shoeRepository.SaveChangesAsync();

            return _mapper.Map<ColorVariationDto>(variationToUpdate);
        }

        public async Task DeleteColorVariationAsync(int variationId)
        {
            var allShoes = await _shoeRepository.GetAllWithVariationsAsync();
            var shoe = allShoes.FirstOrDefault(s => s.ColorVariations.Any(v => v.Id == variationId));

            if (shoe != null)
            {
                var variationToDelete = shoe.ColorVariations.First(v => v.Id == variationId);
                shoe.ColorVariations.Remove(variationToDelete);

                await _shoeRepository.UpdateAsync(shoe);
                await _shoeRepository.SaveChangesAsync();
            }
        }

        // --- Pull Out History ---

        // Pinalitan ang lumang GetPullOutHistoryForShoeAsync(int shoeId)
        public async Task<IEnumerable<StockPullOutDto>> GetAllPullOutHistoryAsync()
        {
            // Kukunin ang lahat ng StockPullOut Entities (Ipagpalagay na ang GetAllPullOutsAsync() ay available)
            var allPullOuts = await _pullOutRepository.GetAllPullOutsAsync();

            // I-ma-map ang Entities sa DTOs
            return _mapper.Map<IEnumerable<StockPullOutDto>>(allPullOuts);
        }

        public class InventoryMappingProfile : Profile
        {
            public InventoryMappingProfile()
            {
                // I-map ang database entity (source) sa DTO (destination)
                CreateMap<StockPullOut, PullOutRequestDto>();
            }
        }
    }
}