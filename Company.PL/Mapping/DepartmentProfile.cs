﻿using AutoMapper;
using Company.DAL.Models;
using Company.PL.Dtos;
using Company.PL.DTOs;

namespace Company.PL.Mapping
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, CreateDepartmentDto>().ReverseMap();
        }
    }
}
