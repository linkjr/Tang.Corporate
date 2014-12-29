using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tang.Corporate.DataObjects;
using Tang.Corporate.Domain.Repositories;
using Tang.Corporate.IApplication;

namespace Tang.Corporate.Application
{
    public class NewsService : ApplicationService, INewsService
    {
        private INewsRepository _repository;
        private IUserRepository _userRepository;

        public NewsService(IRepositoryContext context,
            INewsRepository repository, IUserRepository userRepository)
            : base(context)
        {
            this._repository = repository;
            this._userRepository = userRepository;
        }

        public void Create(ManageNewsDataObject dataObject)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Modify(ManageNewsDataObject dataOjbect)
        {
            throw new NotImplementedException();
        }

        public NewsDataObject Find(Guid id)
        {
            throw new NotImplementedException();
        }

        public NewsDataObject Find(Guid id, Guid userID)
        {
            throw new NotImplementedException();
        }

        public NewsResponse List(NewsRequest request)
        {
            throw new NotImplementedException();
        }

        public IList<NewsDataObject> List(int count)
        {
            var list = this._repository.FindAll().Select(m => new NewsDataObject { });
            return list.ToList();
        }


        public IQueryable<NewsDataObject> List()
        {
            var list = this._repository.FindAll()
                .Select(m => new NewsDataObject
            {
                ID = m.ID,
                Title = m.Title,
                CoverImg = m.CoverImg,
                Content = m.Content,
                CreateDate = m.CreateDate
            });
            return list;
        }
    }
}
