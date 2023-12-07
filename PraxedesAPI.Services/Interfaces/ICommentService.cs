using PraxedesAPI.Entities.DTOs;
using PraxedesAPI.Services.Common;
using PraxedesAPI.Services.Implementation;

namespace PraxedesAPI.Services.Interfaces
{
    public interface ICommentService
    {
        Task<ServicesResult<bool>> MasiveAdd(string jsonString);
        Task<ServicesResult<string>> GetCommentById(long id);

        Task<ServicesResult<string>> GetCommentByPostId(long id);

        Task<ServicesResult<string>> UpdateCommentById(long id, CommentsDTO commentsDTO);

        Task<ServicesResult<string>> UpdateCommentByPostId(long id, CommentsDTO commentDTO);

        Task<ServicesResult<bool>> DeleteCommentById(long id);

        Task<ServicesResult<bool>> DeleteCommentByPostId(long id);
    }
}
