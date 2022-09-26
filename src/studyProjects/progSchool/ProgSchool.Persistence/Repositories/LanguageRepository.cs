using Core.Persistence.Repositories;
using ProgSchool.Application.Services.Repositories;
using ProgSchool.Domain.Entities;
using ProgSchool.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgSchool.Persistence.Repositories
{
    public class LanguageRepository : EfRepositoryBase<Language, BaseDbContext>, ILanguageRepository
    {
        public LanguageRepository(BaseDbContext context) : base(context)
        {

        }
    }
}
