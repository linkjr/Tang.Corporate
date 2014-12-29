﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tang.Corporate.DataObjects;
using Tang.Corporate.Domain.Repositories;
using Tang.Corporate.IApplication;
using Tang.Corporate.Infrastructure.Exceptions;

namespace Tang.Corporate.Application
{
    public class UserService : ApplicationService, IUserService
    {
        private IUserRepository _repository;

        public UserService(IRepositoryContext context,
            IUserRepository repository)
            : base(context)
        {
            this._repository = repository;
        }


        public UserDataObject Login(UserLoginDataObject dataObject)
        {
            if (dataObject == null)
                throw new ValidationException("dataObject为空。");
            if (string.IsNullOrEmpty(dataObject.Account))
                throw new ValidationException("登录账号为空。");
            if (string.IsNullOrEmpty(dataObject.Password))
                throw new ValidationException("登录密码为空。");

            //var ar = this._repository.FindAll().FirstOrDefault(m => m.Account == dataObject.Account);
            //ar.Login(dataObject.Account, dataObject.Password);
            var ar = this.FindByAccount(dataObject.Account);
            return ar;
        }


        public UserDataObject FindByAccount(string account)
        {
            var list = from m in this._repository.FindAll()
                       orderby m.CreateDate descending
                       select new UserDataObject
                       {
                           ID = m.ID,
                           Account = m.Account,
                           Password = m.Password,
                           CreateDate = m.CreateDate
                       };
            var dataObject = list.FirstOrDefault(m => m.Account == account);
            return dataObject;
        }
    }
}