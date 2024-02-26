﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using Shop_API.Repository.IRepository;
using Shop_Models.Dto;
using Shop_Models.Entities;

namespace Shop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ColorController : ControllerBase
    {
        private readonly IColorRepository _colorRepository;
        private readonly IPagingRepository _iPagingRepository;
        private readonly IConfiguration _config;
        private readonly ResponseDto _reponse;
        public ColorController(IColorRepository colorRepository, IConfiguration config, IProductDetailRepository repository, IPagingRepository pagingRepository)
        {
            _colorRepository = colorRepository;
            _config = config;
            _reponse = new ResponseDto();
            _iPagingRepository = pagingRepository;
        }

        [HttpGet/*, Authorize(Roles = "Admin,User")*/]
        public async Task<IActionResult> GetAllColor()
        {

            string apiKey = _config.GetSection("ApiKey").Value;
            if (apiKey == null)
            {
                return Unauthorized();
            }

            var keyDomain = Request.Headers["Key-Domain"].FirstOrDefault();
            if (keyDomain != apiKey.ToLower())
            {
                return Unauthorized();
            }
            return Ok(await _colorRepository.GetAllColors());
        }

        [HttpPost("CreateReturnDto")]
        public async Task<IActionResult> CreateReturnDto(Color obj)
        {

            string apiKey = _config.GetSection("ApiKey").Value;
            if (apiKey == null)
            {
                return Unauthorized();
            }

            var keyDomain = Request.Headers["Key-Domain"].FirstOrDefault();
            if (keyDomain != apiKey.ToLower())
            {
                return Unauthorized();
            }
            obj.Id = Guid.NewGuid();
            obj.TrangThai = 1;
            var response = await _colorRepository.CreateReturnDto(obj);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        
        [HttpPost("CreateColor")]
        public async Task<IActionResult> CreateColor(Color obj)
        {

            string apiKey = _config.GetSection("ApiKey").Value;
            if (apiKey == null)
            {
                return Unauthorized();
            }

            var keyDomain = Request.Headers["Key-Domain"].FirstOrDefault();
            if (keyDomain != apiKey.ToLower())
            {
                return Unauthorized();
            }
            obj.Id = Guid.NewGuid();

            obj.TrangThai = 1;
            if (await _colorRepository.Create(obj))
            {
                return Ok("Thêm thành công");
            }
            return BadRequest("Thêm thất bại");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateColor(Color obj)
        {

            string apiKey = _config.GetSection("ApiKey").Value;
            if (apiKey == null)
            {
                return Unauthorized();
            }

            var keyDomain = Request.Headers["Key-Domain"].FirstOrDefault();
            if (keyDomain != apiKey.ToLower())
            {
                return Unauthorized();
            }
            if (await _colorRepository.Update(obj))
            {
                return Ok("Sửa thành công");
            }
            return BadRequest("Sửa thất bại");
        }
        [HttpPut("UpdateReturnDto")]
        public async Task<IActionResult> UpdateReturnDto(Color obj)
        {

            string apiKey = _config.GetSection("ApiKey").Value;
            if (apiKey == null)
            {
                return Unauthorized();
            }

            var keyDomain = Request.Headers["Key-Domain"].FirstOrDefault();
            if (keyDomain != apiKey.ToLower())
            {
                return Unauthorized();
            }
            var response = await _colorRepository.UpdateReturnDto(obj);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteColor(Guid id)
        {

            string apiKey = _config.GetSection("ApiKey").Value;
            if (apiKey == null)
            {
                return Unauthorized();
            }

            var keyDomain = Request.Headers["Key-Domain"].FirstOrDefault();
            if (keyDomain != apiKey.ToLower())
            {
                return Unauthorized();
            }
            if (await _colorRepository.Delete(id))
            {
                return Ok("Xóa thành công");
            }
            return BadRequest("Xóa thất bại");

        }


        [HttpGet("GetColorFSP")]
        public async Task<IActionResult> GetColorFSP(string? search, double? from, double? to, string? sortBy, int page)
        {
            //string apiKey = _config.GetSection("ApiKey").Value;
            //if (apiKey == null)
            //{
            //    return Unauthorized();
            //}

            //var keyDomain = Request.Headers["Key-Domain"].FirstOrDefault();
            //if (keyDomain != apiKey.ToLower())
            //{
            //    return Unauthorized();
            //}
            _reponse.Result = _iPagingRepository.GetAllColor(search, from, to, sortBy, page);
            _reponse.Count = 10;
            return Ok(_reponse);
        }

        [HttpGet("GetColorById")]
        public async Task<IActionResult> GetColorById(Guid guid)
        {

            //    string apiKey = _config.GetSection("ApiKey").Value;
            //    if (apiKey == null)
            //    {
            //        return Unauthorized();
            //    }

            //    var keyDomain = Request.Headers["Key-Domain"].FirstOrDefault();
            //    if (keyDomain != apiKey.ToLower())
            //    {
            //        return Unauthorized();
            //    }
            //_reponse.Result = _colorRepository.GetById(guid);
            return Ok(await _colorRepository.GetById(guid));
        }

    }
}
