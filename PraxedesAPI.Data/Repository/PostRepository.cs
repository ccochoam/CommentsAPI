using System.Data;
using PraxedesAPI.Data.Interfaces;
using PraxedesAPI.Data.Models;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace PraxedesAPI.Data.Repository
{
    public class PostRepository: IPostRepository
    {
        private readonly PraxedesBdContext _praxedesBdContext;
        public PostRepository(PraxedesBdContext praxedesBdContext)
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

        public async Task<Post> GetPostById(long id)
        {
            try
            {
                var res = _praxedesBdContext.Posts.FirstOrDefault(q => q.Id == id);
            return res;
            }
            catch { throw; }
        }

        public async Task<List<Post>> GetPostByUserId(long id)
        {
            try
            {
                var res = _praxedesBdContext.Posts.Where(q => q.UserId == id).ToList();
                return res;
            }
            catch { throw; }
        }

        public async Task<Post> UpdatePostById(long id, Post postUpdated)
        {
            try
            {
                var res = _praxedesBdContext.Posts.FirstOrDefault(c => c.Id == id);
                    Post post = GetPostModel(res, postUpdated);
                    _praxedesBdContext.SaveChanges();
                    return post;
            }
            catch { throw; }
        }
        public async Task<Post> UpdatePostByUserId(long id, Post postUpdated)
        {
            try
            {
                var res = _praxedesBdContext.Posts.FirstOrDefault(c => c.UserId == id);
                    Post post = GetPostModel(res, postUpdated);
                    return res;
            }
            catch { throw; }
        }

        public async Task<bool> DeletePostById(long id)
        {
            try
            {
                var res = _praxedesBdContext.Posts.FirstOrDefault(q => q.Id == id);
                if (res != null)
                {
                    _praxedesBdContext.Posts.Remove(res);
                    _praxedesBdContext.SaveChanges();
                }

                return true;
            }
            catch { throw; }
        }
        public async Task<bool> DeletePostByUserId(long id)
        {
            try
            {
                var res = _praxedesBdContext.Posts.FirstOrDefault(q => q.UserId == id);
                if (res != null)
                {
                    _praxedesBdContext.Posts.Remove(res);
                    _praxedesBdContext.SaveChanges();
                }

                return true;
            }
            catch { throw; }
        }

        public Post GetPostModel(Post postModelOld, Post postUpdated)
        {
            postModelOld.Body = postUpdated.Body;
            postModelOld.Title = postUpdated.Title;
            return postModelOld;
        }

    }
}
