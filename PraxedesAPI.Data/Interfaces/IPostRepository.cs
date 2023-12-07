using PraxedesAPI.Data.Models;
using System.Data;

namespace PraxedesAPI.Data.Interfaces
{
    public interface IPostRepository
    {
        Task<bool> MasiveAdd(DataTable data, string tableName);
        Task<Post> GetPostById(long id);
        Task<List<Post>> GetPostByUserId(long id);
        Task<Post> UpdatePostById(long id, Post postUpdated);
        Task<Post> UpdatePostByUserId(long id, Post postUpdated);
        Task<bool> DeletePostById(long id);
        Task<bool> DeletePostByUserId(long id);
    }
}
