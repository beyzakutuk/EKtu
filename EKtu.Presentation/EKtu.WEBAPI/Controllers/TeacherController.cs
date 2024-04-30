﻿using EKtu.Domain.Entities;
using EKtu.Persistence.Builder.IBuilder;
using EKtu.Repository.Dtos;
using EKtu.Repository.IService.AddPersonService;
using EKtu.Repository.IService.TeacherService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EKtu.WEBAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeacherController : ResponseBase
    {
        private readonly IAddPersonService<Teacher> addTeacherService;
        private readonly ITeacherBuilder teacherBuilder;
        private readonly ITeacherService teacherService;

        public TeacherController(IAddPersonService<Teacher> addteacherService, ITeacherBuilder teacherBuilder, ITeacherService teacherService)
        {
            this.addTeacherService = addteacherService;
            this.teacherBuilder = teacherBuilder;
            this.teacherService = teacherService;
        }
        [HttpPost]
        [Authorize(Policy ="ClientCredentials")]
        public async Task<IActionResult> AddTeacher([FromBody]AddTeacherRequestDto teacherRequestDto)
        {
           Teacher _teacher= this.teacherBuilder
                .FirstName(teacherRequestDto.FirstName)
                .LastName(teacherRequestDto.LastName)
                .Password(teacherRequestDto.Password)
                .TckNo(teacherRequestDto.TckNo)
                .GetPerson();
            return ResponseData<NoContent>(await this.addTeacherService.AddAsync(_teacher));
        }
        [HttpGet]
        [Authorize(Policy ="TeacherClassList")]
        public async Task<IActionResult> TeacherClassList()
        {
            var teacherId = User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
          return ResponseData<List<TeacherClassReponseDto>>(await teacherService.TeacherClass(Convert.ToInt32(teacherId.Value)));
        }
    }
}
