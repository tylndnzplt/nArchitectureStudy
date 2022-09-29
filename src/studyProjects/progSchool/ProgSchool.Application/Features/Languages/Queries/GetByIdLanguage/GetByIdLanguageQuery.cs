using AutoMapper;
using MediatR;
using ProgSchool.Application.Features.Languages.Dtos;
using ProgSchool.Application.Features.Languages.Rules;
using ProgSchool.Application.Services.Repositories;
using ProgSchool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgSchool.Application.Features.Languages.Queries.GetByIdLanguage
{
    public class GetByIdLanguageQuery:IRequest<LanguageGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdLanguageQueryHandler:IRequestHandler<GetByIdLanguageQuery,LanguageGetByIdDto>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinessRules _languageBusinessRules;

            public GetByIdLanguageQueryHandler(ILanguageRepository languageRepository, IMapper mapper, LanguageBusinessRules languageBusinessRules)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
                _languageBusinessRules = languageBusinessRules;
            }

            public async Task<LanguageGetByIdDto> Handle(GetByIdLanguageQuery request, CancellationToken cancellationToken)
            {
                Language? language = await _languageRepository.GetAsync(x => x.Id == request.Id);
                _languageBusinessRules.LanguageShouldExistWhenRequested(language);

                LanguageGetByIdDto languageGetByIdDto = _mapper.Map<Language, LanguageGetByIdDto>(language);

                return languageGetByIdDto;

            }
        }
    }
}
