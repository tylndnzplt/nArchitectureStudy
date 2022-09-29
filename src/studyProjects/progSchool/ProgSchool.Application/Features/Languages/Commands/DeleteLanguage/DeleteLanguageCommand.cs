using AutoMapper;
using FluentValidation.Resources;
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

namespace ProgSchool.Application.Features.Languages.Commands.DeleteLanguage
{
    public class DeleteLanguageCommand:IRequest<DeletedLanguageDto>
    {
        public int Id { get; set; }

        public class DeletedLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand, DeletedLanguageDto>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinessRules _languageBusinessRules;

            public DeletedLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper, LanguageBusinessRules languageBusinessRules)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
                _languageBusinessRules = languageBusinessRules;
            }

            public async Task<DeletedLanguageDto> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
            {
                Language? language = await _languageRepository.GetAsync(x => x.Id == request.Id);
                _languageBusinessRules.LanguageShouldExistWhenRequested(language);

                DeletedLanguageDto deletedLanguageDto = _mapper.Map<DeletedLanguageDto>(language);
                await _languageRepository.DeleteAsync(language);
                return deletedLanguageDto;
            }
        }
    }
}
