using System.Data;
using Newtonsoft.Json;
using PraxedesAPI.Entities.Models;
using PraxedesAPI.Data.Interfaces;
using PraxedesAPI.Services.Helpers;
using PraxedesAPI.Services.Interfaces;
using PraxedesAPI.Data.Models;
using PraxedesAPI.Data.Repository;
using PraxedesAPI.Entities.DTOs;
using AutoMapper;
using PraxedesAPI.Data.Models;
using PraxedesAPI.Services.Common;

namespace PraxedesAPI.Services.Implementation
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        public async Task<ServicesResult<bool>> MasiveAdd(string jsonString)
        {
            try
            {
                if (!string.IsNullOrEmpty(jsonString))
                {
                    bool validateJsonModel = ValidateJsonModel.ValidateModel<CommentModel>(jsonString);
                    if (!validateJsonModel)
                        return ServicesResult<bool>.FailedOperation(400, "No rows added");
                    DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsonString, typeof(DataTable));
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        bool res = await _commentRepository.MasiveAdd(dt, Constants.CommentTbName);
                        return ServicesResult<bool>.SuccessfulOperation(res);
                    }
                }
                return ServicesResult<bool>.FailedOperation(400, "No rows added");
            }
            catch (Exception ex)
            {
                return ServicesResult<bool>.FailedOperation(500, "Error in MasiveAdd: CommentService", ex);
            }
        }
        public async Task<ServicesResult<string>> GetCommentById(long id)
        {
            try
            {
                var res = await _commentRepository.GetCommentById(id);
                if (res != null)
                    return ServicesResult<string>.SuccessfulOperation(JsonConvert.SerializeObject(res));
                return ServicesResult<string>.FailedOperation(400, "Comment not found");
            }
            catch (Exception ex)
            {
                return ServicesResult<string>.FailedOperation(500, "Error in GetCommentById: CommentService", ex);
            }
        }
        public async Task<ServicesResult<string>> GetCommentByPostId(long id)
        {
            try
            {
                var res = await _commentRepository.GetCommentByPostId(id);
                if (res != null)
                    return ServicesResult<string>.SuccessfulOperation(JsonConvert.SerializeObject(res));
                return ServicesResult<string>.FailedOperation(400, "Comment not founded");
            }
            catch (Exception ex)
            {
                return ServicesResult<string>.FailedOperation(500, "Error in GetCommentByPostId: CommentService", ex);
            }
        }
        public async Task<ServicesResult<string>> UpdateCommentById(long id, CommentsDTO commentUpdated)
        {
            try
            {
                var commentModel = _mapper.Map<Comment>(commentUpdated);
                if (commentModel == null)
                    return ServicesResult<string>.FailedOperation(404, $"Comment with Id: {id}, not found");

                var res = await _commentRepository.UpdateCommentById(id, commentModel);
                if (res != null)
                    return ServicesResult<string>.SuccessfulOperation(JsonConvert.SerializeObject(res));
                return ServicesResult<string>.FailedOperation(400, "Comment was not updated");
            }
            catch (Exception ex)
            {
                return ServicesResult<string>.FailedOperation(500, "Error in UpdateCommentById: CommentService", ex);
            }
        }
        public async Task<ServicesResult<string>> UpdateCommentByPostId(long id, CommentsDTO commentUpdated)
        {
            try
            {
                var commentModel = _mapper.Map<Comment>(commentUpdated);
                if (commentModel == null)
                    return ServicesResult<string>.FailedOperation(404, $"Comment with Id: {id}, not found");

                var res = await _commentRepository.UpdateCommentByPostId(id, commentModel);
                if (res != null)
                    return ServicesResult<string>.SuccessfulOperation(JsonConvert.SerializeObject(res));
                return ServicesResult<string>.FailedOperation(400, "Comment was not updated");
            }
            catch (Exception ex)
            {
                return ServicesResult<string>.FailedOperation(500, "Error in UpdateCommentByPostId: CommentService", ex);
            }
        }

        public async Task<ServicesResult<bool>> DeleteCommentById(long id)
        {
            try
            {
                var res = await _commentRepository.DeleteCommentById(id);
                if (res != null)
                    return ServicesResult<bool>.SuccessfulOperation(res);
                return ServicesResult<bool>.FailedOperation(400, "Comment was not updated");
            }
            catch (Exception ex)
            {
                return ServicesResult<bool>.FailedOperation(500, "Error in DeleteCommentById: CommentService", ex);
            }
        }

        public async Task<ServicesResult<bool>> DeleteCommentByPostId(long id)
        {
            try
            {
                var res = await _commentRepository.DeleteCommentByPostId(id);
                if (res != null)
                    return ServicesResult<bool>.SuccessfulOperation(res);
                return ServicesResult<bool>.FailedOperation(400, "Comment was not updated");
            }
            catch (Exception ex)
            {
                return ServicesResult<bool>.FailedOperation(500, "Error in DeleteCommentByPostId: CommentService", ex);
            }
        }
    }
}
