using System.Data;
using Newtonsoft.Json;
using PraxedesAPI.Entities.Models;
using PraxedesAPI.Data.Interfaces;
using PraxedesAPI.Services.Helpers;
using PraxedesAPI.Services.Interfaces;
using PraxedesAPI.Entities.DTOs;
using AutoMapper;
using PraxedesAPI.Data.Models;
using PraxedesAPI.Services.Common;
using System.Net.NetworkInformation;

namespace PraxedesAPI.Services.Implementation
{
    public class PostService: IPostService
    {
        private readonly IPostRepository _PostRepository;
        private readonly IMapper _mapper;
        public PostService(IPostRepository PostRepository, IMapper mapper)
        {
            _PostRepository = PostRepository;
            _mapper = mapper;
        }
        public async Task<ServicesResult<bool>> MasiveAdd(string jsonString)
        {
            try
            {
                if (!string.IsNullOrEmpty(jsonString))
                {
                    bool validateJsonModel = ValidateJsonModel.ValidateModel(jsonString, Constants.PostsTbName);
                    if (!validateJsonModel)
                        return ServicesResult<bool>.FailedOperation(400, "No rows added");
                    DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsonString, typeof(DataTable));
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        bool res = await _PostRepository.MasiveAdd(dt, Constants.PostsTbName);
                        return ServicesResult<bool>.SuccessfulOperation(res);
                    }
                }
                return ServicesResult<bool>.FailedOperation(400, "No rows added");
            }
            catch (Exception ex)
            {
                return ServicesResult<bool>.FailedOperation(500, "Error in MasiveAdd: PostService", ex);
            }
        }

        public async Task<ServicesResult<string>> GetPostById(long id)
        {
            try
            {
                var res = await _PostRepository.GetPostById(id);
                if (res != null)
                    return ServicesResult<string>.SuccessfulOperation(JsonConvert.SerializeObject(res));
                return ServicesResult<string>.FailedOperation(400, "Post not found");
            }
            catch (Exception ex)
            {
                return ServicesResult<string>.FailedOperation(500, "Error in GetPostById: PostService", ex);
            }
        }

        public async Task<ServicesResult<string>> GetPostByUserId(long id)
        {
            try
            {
                var res = await _PostRepository.GetPostByUserId(id);
                if (res != null)
                    return ServicesResult<string>.SuccessfulOperation(JsonConvert.SerializeObject(res));
                return ServicesResult<string>.FailedOperation(400, "Post not found");
            }
            catch (Exception ex)
            {
                return ServicesResult<string>.FailedOperation(500, "Error in GetPostByUserId: PostService", ex);
            }
        }

        public async Task<ServicesResult<string>> UpdatePostById(long id, PostsDTO postUpdated)
        {
            try
            {
                var postModel = _mapper.Map<Post>(postUpdated);
                if (postModel == null)
                    return ServicesResult<string>.FailedOperation(404, $"Post with Id: {id}, not found");

                var res = await _PostRepository.UpdatePostById(id, postModel);
                if (res != null)
                    return ServicesResult<string>.SuccessfulOperation(JsonConvert.SerializeObject(res));
                return ServicesResult<string>.FailedOperation(400, "Post not found");
            }
            catch (Exception ex)
            {
                return ServicesResult<string>.FailedOperation(500, "Error in UpdatePostById: PostService", ex);
            }
        }

        public async Task<ServicesResult<string>> UpdatePostByUserId(long id, PostsDTO postUpdated)
        {
            try
            {
                var postModel = _mapper.Map<Post>(postUpdated);
                if (postModel == null)
                    return ServicesResult<string>.FailedOperation(404, $"Post with Id: {id}, not found");

                var res = await _PostRepository.UpdatePostByUserId(id, postModel);
                if (res != null)
                    return ServicesResult<string>.SuccessfulOperation(JsonConvert.SerializeObject(res));
                return ServicesResult<string>.FailedOperation(400, "Post not found");
            }
            catch (Exception ex)
            {
                return ServicesResult<string>.FailedOperation(500, "Error in UpdatePostByUserId: PostService", ex);
            }
        }
        public async Task<ServicesResult<bool>> DeletePostById(long id)
        {
            try
            {
                var res = await _PostRepository.DeletePostById(id);
                if (res != null)
                    return ServicesResult<bool>.SuccessfulOperation(res);
                return ServicesResult<bool>.FailedOperation(400, "Post was not updated");
            }
            catch (Exception ex)
            {
                return ServicesResult<bool>.FailedOperation(500, "Error in DeletePostById: CommentService", ex);
            }
        }
        public async Task<ServicesResult<bool>> DeletePostByUserId(long id)
        {
            try
            {
                var res = await _PostRepository.DeletePostByUserId(id);
                if (res != null)
                    return ServicesResult<bool>.SuccessfulOperation(res);
                return ServicesResult<bool>.FailedOperation(400, "Post was not updated");
            }
            catch (Exception ex)
            {
                return ServicesResult<bool>.FailedOperation(500, "Error in DeletePostByUserId: CommentService", ex);
            }
        }
    }
}