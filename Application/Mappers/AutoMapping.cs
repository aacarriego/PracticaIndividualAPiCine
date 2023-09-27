using Application.DTO;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class AutoMapping : Profile
    {
        public AutoMapping() 
        {
            CreateMap<FuncionResponseDTO, Funcion>();


            CreateMap<Funcion, FuncionResponseDTO>();
        }
    }
}
