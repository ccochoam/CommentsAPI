using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PraxedesAPI.Entities.DTOs;
using PraxedesAPI.Services.Interfaces;
using System;

namespace PraxedesAPI.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/comment")]
    public class CommentsController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IJsonPlaceholderService _jsonPlaceholderService;
        public CommentsController(ICommentService commentService, IJsonPlaceholderService jsonPlaceholderService)
        {
            _commentService = commentService;
            _jsonPlaceholderService = jsonPlaceholderService;
        }

        [HttpPost("MasiveAdd")]
        public async Task<IActionResult> MasiveAdd(string url)
        {
            try
            {
                var json = await _jsonPlaceholderService.RunService(url);
                if(string.IsNullOrEmpty(json))
                    return BadRequest("URL is wrong");

                var res = await _commentService.MasiveAdd(json);
                if (res.Success)
                    return Ok(res.Result);
                return StatusCode(500, "Error saving rows in database");

            }
            catch (Exception ex)
            {
                return BadRequest("Internal Server Error");
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var res = await _commentService.GetCommentById(id);
                if (res.Success)
                    return Ok(res.Result);
                return StatusCode(404, "Comment not found");
            }
            catch (Exception ex)
            {
                return BadRequest("Internal Server Error");
            }
        }

        [HttpGet("GetByPostId/{PostId}")]
        public async Task<IActionResult> GetbyPostId(long PostId)
        {
            try
            {
                var res = await _commentService.GetCommentById(PostId);
                if (res.Success)
                    return Ok(res.Result);
                return StatusCode(404, "Comment not found");
            }
            catch (Exception ex)
            {
                return BadRequest("Internal Server Error");
            }
        }

        [HttpPut("UpdateById")]
        public async Task<IActionResult> UpdateById(long id, [FromBody] CommentsDTO commentsDTO)
        {
            if (commentsDTO == null)
                return BadRequest("Comment model is null");

            if (id != commentsDTO.Id)
                return BadRequest("Id parameter is not equal to the Id parameter in the model.");
            try
            {
                var res = await _commentService.UpdateCommentById(id, commentsDTO);
                if (res.Success)
                    return Ok(res.Result);
                if (res.StatusCode == 400)
                    return StatusCode(400, res.Message);
                return BadRequest("Internal Server Error");
            }
            catch (Exception ex)
            {
                return BadRequest("Internal Server Error");
            }
        }

        [HttpPut("UpdateByPostId")]
        public async Task<IActionResult> UpdateCommentByPostId(long id, [FromBody] CommentsDTO commentsDTO)
        {
            if (commentsDTO == null)
                return BadRequest("Comment model is null");

            if (id != commentsDTO.Id)
                return BadRequest("Id parameter is not equal to the Id parameter in the model.");
            try
            {
                var res = await _commentService.UpdateCommentByPostId(id, commentsDTO);
                if (res.Success)
                    return Ok(res.Result);
                if (res.StatusCode == 400)
                    return StatusCode(400, res.Message);
                return BadRequest("Internal Server Error");
            }
            catch (Exception ex)
            {
                return BadRequest("Internal Server Error");
            }
        }

        [HttpDelete("DeleteById/{id}")]
        public async Task<IActionResult> DeleteCommentById(long id)
        {
            try
            {
                var res = await _commentService.DeleteCommentById(id);
                if (res.Success)
                    return Ok(res.Result);
                return BadRequest("Internal Server Error");
            }
            catch (Exception ex)
            {
                return BadRequest("Internal Server Error");
            }
        }

        [HttpDelete("DeleteByPostId/{PostId}")]
        public async Task<IActionResult> DeleteCommentByPostId(long PostId)
        {
            try
            {
                var res = await _commentService.DeleteCommentByPostId(PostId);
                if (res.Success)
                    return Ok(res.Result);
                return BadRequest("Internal Server Error");
            }
            catch (Exception ex)
            {
                return BadRequest("Internal Server Error");
            }
        }
    }
}