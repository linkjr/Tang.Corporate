using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tang.Corporate.Domain.Models;
using Tang.Corporate.Domain.Repositories;

namespace Tang.Corporate.Infrastructure.Repositories.EntityFramework
{
    public class NewsRepository : EntityFrameworkRepository<News>, INewsRepository
    {
        public NewsRepository(IRepositoryContext context)
            : base(context) { }
    }
}
