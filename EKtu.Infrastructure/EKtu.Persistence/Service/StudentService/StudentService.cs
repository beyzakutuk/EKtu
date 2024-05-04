﻿using EKtu.Domain.Entities;
using EKtu.Infrastructure.HASH;
using EKtu.Persistence.Builder.BuilderCreate;
using EKtu.Persistence.Builder.IBuilder;
using EKtu.Repository.Dtos;
using EKtu.Repository.IRepository;
using EKtu.Repository.IRepository.StudentRepository;
using EKtu.Repository.IService;
using EKtu.Repository.IService.StudentService;
using Microsoft.EntityFrameworkCore;

namespace EKtu.Persistence.Service.StudentService
{
    public class StudentService : BaseService<Student>, IStudentService
    {
        private readonly IStudentRepository studentRepository;
        private ISaves _saves;
        private readonly IStudentBuilder studentBuilder;
        public StudentService(IBaseRepository<Student> baseRepository, ISaves saves, IStudentRepository studentRepository,IStudentBuilder _studentBuilder) : base(baseRepository, saves)
        {
            this.studentRepository = studentRepository;
            this._saves = saves;
            studentBuilder = _studentBuilder;
        }

        public async Task<Response<List<StudentListExamGrandeResponseDto>>> StudentListExamGrandeAsync(int studentId)
        {
         var IQueryAbleStudent= await studentRepository.StudentListExamGrandeAsync(studentId);

            var list =await IQueryAbleStudent.Select(y => new StudentListExamGrandeResponseDto()
            {
                FirstName=y.FirstName,
                LastName=y.LastName,
                StudentChooseExamGrande=y.StudentChooseLessons.Select(x=> new StudentChooseLessonExamGrandeResponseDto()
                {
                    Exam1=x.ExamNote.Exam1,
                    Exam2=x.ExamNote.Exam2,
                    LessonName=x.Lesson.LessonName
                }).ToList(),
            }).ToListAsync();

            return Response<List<StudentListExamGrandeResponseDto>>.Success(list, 200);

        }


        public async Task<Response<int>> StudentCheckEmailAsync(string studentEmail)
        {
          Student student= await studentRepository.FirstOrDefaultAsync(y=>y.Email== studentEmail);
            if (student == null)
                return Response<int>.Fail("mail adresi bulunamadı", 404);

            return Response<int>.Success(student.Id, 200);

        }

        public async Task<Response<NoContent>> StudentChooseLessonAsync(StudentChooseLessonRequestDto studentChooseLessonRequestDto)
        {
            try
            {
                await studentRepository.StudentChooseLessonAsync(studentChooseLessonRequestDto);
                await _saves.SaveChangesAsync();
                return Response<NoContent>.Success(204);
            }
            catch (Exception)
            {
                return Response<NoContent>.Fail("Hata değer eklenemedi", 400);
            }
          
        }

        public async Task<Response<List<StudentAbsenceDto>>> StudentAbsenceAsync(int userId)
        {

           var query = await studentRepository.SelectingStudentAbsent(userId);

           var resp=  await query.GroupBy(x =>x.StudentChooseLesson.Lesson.LessonName).Select(y => new StudentAbsenceDto()
            {
               LessonName =y.Key,
               AbsenceCount =y.Count()
            }).ToListAsync();



            if(resp.Any())
                return Response<List<StudentAbsenceDto>>.Success(resp, 200);
            return Response<List<StudentAbsenceDto>>.Success(204);

        }

        public async Task<Response<StudentCertificateResponseDto>> StudentCertificateAsync(int userId)
        {
          Student? Student= await studentRepository.StudentCertificateAsync(userId);

            if (Student is null)
                return Response<StudentCertificateResponseDto>.Fail("öğrenci yok", 400);
           return Response<StudentCertificateResponseDto>.Success(new StudentCertificateResponseDto()
            {
                TckNo=Student.TckNo,
                FirstName=Student.FirstName,
                LastName=Student.LastName,
            },200);
        }
    }
}
