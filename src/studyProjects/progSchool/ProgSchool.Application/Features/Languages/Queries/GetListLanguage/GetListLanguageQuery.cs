using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using ProgSchool.Application.Features.Languages.Dtos;
using ProgSchool.Application.Features.Languages.Models;
using ProgSchool.Application.Services.Repositories;
using ProgSchool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgSchool.Application.Features.Languages.Queries.GetListLanguage
{
    public class GetListLanguageQuery:IRequest<LanguageListModel>
    {
        /// <summary>
        /// Which page client want
        /// </summary>
        public PageRequest PageRequest { get; set; }

        public class GetListLanguageQueryHandler : IRequestHandler<GetListLanguageQuery, LanguageListModel>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;

            public GetListLanguageQueryHandler(ILanguageRepository languageRepository, IMapper mapper)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
            }

            public async Task<LanguageListModel> Handle(GetListLanguageQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Language> language = await _languageRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                LanguageListModel mappedLanguageListModel = _mapper.Map<LanguageListModel>(language);
                return mappedLanguageListModel;
            }
        }
    }
}
