using System;
using AutoMapper;
using NewPlatformService.DTOs;
using NewPlatformService.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NewPlatformService.Profiles
{
    public class PlatformsProfile : Profile
    {
        public PlatformsProfile()
        {
            CreateMap<Platform, PlatformReadDTO>();
            CreateMap<PlatformCreateDTO, Platform>();
        }
    }
}

