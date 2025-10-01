using ShoeShop.Repository.Entities;

namespace ShoeShop.Repository.Interfaces
{
    public interface IShoeRepository
    {
        Task<Shoe> GetShoeByIdAsync(int id);
        Task<IEnumerable<Shoe>> GetAllShoesAsync();
        Task<Shoe> AddShoeAsync(Shoe shoe);
        Task UpdateShoeAsync(Shoe shoe);
        Task DeleteShoeAsync(int id);
    }
}
