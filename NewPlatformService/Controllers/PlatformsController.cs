using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NewPlatformService.Data;
using NewPlatformService.DTOs;
using NewPlatformService.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewPlatformService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _plantformRepo;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatformRepo plantformRepo, IMapper mapper)
        {
            _plantformRepo = plantformRepo;
            _mapper = mapper;
        }
        // GET: api/values
        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDTO>> GetPlatforms()
        {
            var platforms = _plantformRepo.GetAllPlatforms();
            return platforms.Any() ?
                Ok(_mapper.Map<IEnumerable<PlatformReadDTO>>(platforms)) :
                Ok(Enumerable.Empty<PlatformReadDTO>());
        }

        // GET api/values/5
        [HttpGet("{id}", Name = nameof(GetPlatformById))]
        public ActionResult<PlatformReadDTO> GetPlatformById(int id)
        {
            Console.WriteLine($"Helloooooo, id {id}");
            var platform = _plantformRepo.GetPlatformById(id);
            if (platform == null)
            {
                return BadRequest();
            }

            return Ok(_mapper.Map<PlatformReadDTO>(platform));
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] PlatformCreateDTO value)
        {
            var platform = _mapper.Map<Platform>(value);
            _plantformRepo.CreatePlatform(platform);
            var result = _plantformRepo.SaveChanges();
            var responseDTO = _mapper.Map<PlatformReadDTO>(platform);
            return result ?
                CreatedAtRoute(nameof(GetPlatformById), new { Id = responseDTO.Id }, responseDTO) :
                BadRequest();
        }
    }
}

