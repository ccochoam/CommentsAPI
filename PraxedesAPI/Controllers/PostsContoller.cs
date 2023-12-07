using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PraxedesAPI.Data.Models;
using PraxedesAPI.Entities.DTOs;
using PraxedesAPI.Services.Implementation;
using PraxedesAPI.Services.Interfaces;

namespace PraxedesAPI.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/posts")]
    public class PostsContoller : Controller
    {
        private readonly IPostService _postService;
        private readonly IJsonPlaceholderService _jsonPlaceholderService;
        public PostsContoller(IPostService postService, IJsonPlaceholderService jsonPlaceholderService) 
        {
            _postService = postService;
            _jsonPlaceholderService = jsonPlaceholderService;
        }

        [HttpPost("MasiveAdd/")]
        public async Task<IActionResult> MasiveAdd(string url)
        {
            try
            {
                var json = await _jsonPlaceholderService.RunService(url);
                if (string.IsNullOrEmpty(json))
                    return BadRequest("URL is wrong");
                var res = await _postService.MasiveAdd(json);
                if (res.Success)
                    return Ok(res.Result);
                return BadRequest("Internal Server Error");
            }
            catch (Exception ex)
            {
                return BadRequest("Internal Server Error");
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetPostById(long id)
        {
            try
            {
                var res = await _postService.GetPostById(id);
                if (res.Success)
                    return Ok(res.Result);
                return BadRequest("Internal Server Error");
            }
            catch (Exception ex)
            {
                return BadRequest("Internal Server Error");
            }
        }

        [HttpGet("GetUserId/{UserId}")]
        public async Task<IActionResult> GetPostbyUserId(long UserId)
        {
            try
            {
                var res = await _postService.GetPostById(UserId);
                if (res.Success)
                    return Ok(res.Result);
                return BadRequest("Internal Server Error");
            }
            catch (Exception ex)
            {
                return BadRequest("Internal Server Error");
            }
        }

        [HttpPut("UpdateById")]
        public async Task<IActionResult> UpdatePostById(long id, [FromBody] PostsDTO postsDTO)
        {
            if (postsDTO == null)
                return BadRequest("Post model is null");

            if (id != postsDTO.Id)
                return BadRequest("Id parameter is not equal to the Id parameter in the model.");
            try
            {
                var res = await _postService.UpdatePostById(id, postsDTO);
                if (res.Success)
                    return Ok(res.Result);
                return BadRequest("Internal Server Error");
            }
            catch (Exception ex)
            {
                return BadRequest("Internal Server Error");
            }
        }

        [HttpPut("UpdateByUserId")]
        public async Task<IActionResult> UpdatePostByUserId(long id, [FromBody] PostsDTO postsDTO)
        {
            if (postsDTO == null)
                return BadRequest("Post model is null");

            if (id != postsDTO.Id)
                return BadRequest("Id parameter is not equal to the Id parameter in the model.");
            try
            {
                var res = await _postService.UpdatePostByUserId(id, postsDTO);
                if (res.Success)
                    return Ok(res.Result);
                return BadRequest("Internal Server Error");
            }
            catch (Exception ex)
            {
                return BadRequest("Internal Server Error");
            }
        }

        [HttpDelete("DeleteById/{id}")]
        public async Task<IActionResult> DeletePostById(long id)
        {
            try
            {
                var res = await _postService.DeletePostById(id);
                if (res.Success)
                    return Ok(res.Result);
                return BadRequest("Internal Server Error");
            }
            catch (Exception ex)
            {
                return BadRequest("Internal Server Error");
            }
        }

        [HttpDelete("DeleteByUserId/{UserId}")]
        public async Task<IActionResult> DeletePostByUserId(long UserId)
        {
            try
            {
                var res = await _postService.DeletePostByUserId(UserId);
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