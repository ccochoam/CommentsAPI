using System.Data;
using PraxedesAPI.Data.Interfaces;
using PraxedesAPI.Data.Models;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace PraxedesAPI.Data.Repository
{
    public class CommentRepository: ICommentRepository
    {
        private readonly PraxedesBdContext _praxedesBdContext;
        public CommentRepository(PraxedesBdContext praxedesBdContext)
        {
            _praxedesBdContext = praxedesBdContext;
        }

        public async Task<bool> MasiveAdd(DataTable dataTable, string tableName)
        {
            using var sqlBulkCopy = new SqlBulkCopy(_praxedesBdContext.Database.GetDbConnection().ConnectionString)
            {
                DestinationTableName = tableName
            };

            await _praxedesBdContext.Database.OpenConnectionAsync();
            try
            {
                await sqlBulkCopy.WriteToServerAsync(dataTable);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _praxedesBdContext.Database.CloseConnection();
            }
        }
        public async Task<List<Comment>> GetCommentById(long id)
        {
            var res = _praxedesBdContext.Comments.Where(q => q.Id == id).ToList();
            return res;
        }

        public async Task<List<Comment>> GetCommentByPostId(long id)
        {
            var res = _praxedesBdContext.Comments.Where(q => q.PostId == id).ToList();
            return res;
        }

        public async Task<Comment> UpdateCommentById(long id, Comment CommentUpdated)
        {
            var res = _praxedesBdContext.Comments.FirstOrDefault(c => c.Id == id);
            Comment comment = GetCommentModel(res, CommentUpdated);
            _praxedesBdContext.SaveChanges();
            return comment;
        }
        public async Task<Comment> UpdateCommentByPostId(long id, Comment CommentUpdated)
        {
            var res = _praxedesBdContext.Comments.FirstOrDefault(c => c.PostId == id);
            Comment comment = GetCommentModel(res, CommentUpdated);
            return res;
        }

        public async Task<bool> DeleteCommentById(long id)
        {
            try
            {
                var res = _praxedesBdContext.Comments.FirstOrDefault(q => q.Id == id);
                if (res != null)
                {
                    _praxedesBdContext.Comments.Remove(res);
                    _praxedesBdContext.SaveChanges();
                }

                return true;
            }
            catch { throw; }
        }
        public async Task<bool> DeleteCommentByPostId(long id)
        {
            try
            {
                var res = _praxedesBdContext.Comments.FirstOrDefault(q => q.PostId == id);
                if (res != null)
                {
                    _praxedesBdContext.Comments.Remove(res);
                    _praxedesBdContext.SaveChanges();
                }

                return true;
            }
            catch { throw; }
        }

        public Comment GetCommentModel(Comment CommentModelOld, Comment CommentUpdated)
        {
            CommentModelOld.Body = CommentUpdated.Body;
            CommentModelOld.Name = CommentUpdated.Name;
            return CommentModelOld;
        }
    }
}
