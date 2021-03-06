﻿using AutoMapper;
using SmartSchool.Dtos;
using SmartSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.Helpers
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            CreateMap<Aluno, AlunoDto>().ForMember(dest => dest.Nome, opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}"))
                                        .ForMember(dest => dest.Idade, opt => opt.MapFrom(src => src.DataNasc.GetCurrentAge()));
            CreateMap<Professor, ProfessorDto>().ForMember(dest => dest.Nome,
                                                           opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}"));
        }
    }
}
