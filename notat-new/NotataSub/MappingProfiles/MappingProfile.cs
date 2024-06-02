using AutoMapper;
using NotataSub.Models;
using NotataSub.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotataSub.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Lecture, LectureCreate>();
            CreateMap<LectureCreate, Lecture>();
        }
    }
}
