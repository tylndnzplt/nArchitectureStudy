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

namespace ProgSchool.Application.Features.Languages.Commands.UpdateLanguage
{
    public class UpdateLanguageCommand:IRequest<UpdatedLanguageCommandDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdatedLanguageCommandHandler:IRequestHandler<UpdateLanguageCommand, UpdatedLanguageCommandDto>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinessRules _languageBusinessRules;

            public UpdatedLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper, LanguageBusinessRules languageBusinessRules)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
                _languageBusinessRules = languageBusinessRules;
            }

            public async Task<UpdatedLanguageCommandDto> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
            {
                await _languageBusinessRules.LanguageNameCanNotBeDuplicatedWhenInsertedOrUpdated(request.Name);

                Language language = _mapper.Map<Language>(request);
                Language updatedLanguage = await _languageRepository.UpdateAsync(language);

                UpdatedLanguageCommandDto updatedLanguageCommandDto = _mapper.Map<UpdatedLanguageCommandDto>(updatedLanguage);
                return updatedLanguageCommandDto;
            }
        }
    }
}
