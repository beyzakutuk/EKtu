﻿using EKtu.Domain.Entities;
using EKtu.Repository.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKtu.Repository.IService.StudentService
{
    public interface IStudentService:IBaseService<Student>
    {

        Task<Response<List<StudentListExamGrandeResponseDto>>> StudentListExamGrandeAsync(int studentId);


        Task<Response<int>> StudentCheckEmailAsync(string studentEmail);

        Task<Response<NoContent>> StudentChooseLessonAsync(StudentChooseLessonRequestDto studentChooseLessonRequestDto);


        Task<Response<List<StudentAbsenceDto>>> StudentAbsenceAsync(int userId);

        Task<Response<StudentCertificateResponseDto>> StudentCertificateAsync(int userId);


        Task<Response<List<GetStudentChooseLessonDto>>> GetStudentChooseLessonAsync(int userId);
        Task<Response<int>> StudentChangeLessonAsync(List<StudentChangeLessonRequestDto> studentChangeLessonRequestDtos, int studentId);

    }
}
