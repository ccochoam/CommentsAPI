using PraxedesAPI.Data.Models;
using System.Data;

namespace PraxedesAPI.Data.Interfaces
{
    public interface ICommentRepository
    {
        Task<bool> MasiveAdd(DataTable data, string tableName);
        Task<List<Comment>> GetCommentById(long id);
        Task<List<Comment>> GetCommentByPostId(long id);
        Task<Comment> UpdateCommentById(long id, Comment CommentUpdated);
        Task<Comment> UpdateCommentByPostId(long id, Comment CommentUpdated);
        Task<bool> DeleteCommentById(long id);
        Task<bool> DeleteCommentByPostId(long id);
    }
}
