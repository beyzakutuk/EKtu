﻿using EKtu.Domain.Entities;
using EKtu.Infrastructure.HASH;
using EKtu.Repository.IRepository;
using EKtu.Repository.IService.EmailPasswordService;

namespace EKtu.Persistence.Service.EmailPasswordService
{
    public class PasswordService<T> : IPasswordService<T> where T : BasePersonEntity, new()
    {
        private readonly IPasswordRepository<T> repository;
        public PasswordService(IPasswordRepository<T> passwordRepository)
        {
            repository = passwordRepository;
        }
        public async Task<int> EmailAndPassword(string tckno, string password)
        {
          var hasData=  await repository.EmailAndPassword(y => y.TckNo == tckno && y.Password == HashTransaction.HashPassword(password));
            if(hasData is null)
            {
                throw new Exception("Hata"); //buralar middleware ile yakalanacak
            }
            return hasData.Id;
        }
    }
}
