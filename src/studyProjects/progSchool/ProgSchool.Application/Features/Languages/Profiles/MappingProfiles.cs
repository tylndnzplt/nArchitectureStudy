using AutoMapper;
using ProgSchool.Application.Features.Languages.Commands.CreateLanguage;
using ProgSchool.Application.Features.Languages.Dtos;
using ProgSchool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgSchool.Application.Features.Languages.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Language, CreatedLanguageDto>().ReverseMap();
            CreateMap<Language, CreateLanguageCommand>().ReverseMap();
        }
    }
}
