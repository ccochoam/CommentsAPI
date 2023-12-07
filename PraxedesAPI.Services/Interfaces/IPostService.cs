using PraxedesAPI.Data.Models;
using PraxedesAPI.Entities.DTOs;
using PraxedesAPI.Entities.Models;
using PraxedesAPI.Services.Common;
using System.Data;

namespace PraxedesAPI.Services.Interfaces
{
    public interface IPostService
    {
        Task<ServicesResult<bool>> MasiveAdd(string jsonString);
        Task<ServicesResult<string>> GetPostById(long id);
        Task<ServicesResult<string>> GetPostByUserId(long id);
        Task<ServicesResult<string>> UpdatePostById(long id, PostsDTO postUpdated);
        Task<ServicesResult<string>> UpdatePostByUserId(long id, PostsDTO postUpdated);
        Task<ServicesResult<bool>> DeletePostById(long id);
        Task<ServicesResult<bool>> DeletePostByUserId(long id);
    }
}
