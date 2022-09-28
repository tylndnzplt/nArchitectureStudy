using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using ProgSchool.Application.Services.Repositories;
using ProgSchool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgSchool.Application.Features.Languages.Rules
{
    //Long live daft punk !
    public class LanguageBusinessRules
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageBusinessRules(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task LanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Language> result = await _languageRepository.GetListAsync(l => l.Name.ToLower() == name.ToLower());
            if (result.Items.Any()) throw new BusinessException($"{name} exists.");
        }

        public void BrandShouldExistWhenRequested(Language? language)
        {
            if (language == null) throw new BusinessException("Requested brand does not exist");
        }
    }
}
