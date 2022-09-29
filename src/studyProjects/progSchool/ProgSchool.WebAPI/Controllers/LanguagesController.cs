using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgSchool.Application.Features.Languages.Commands.CreateLanguage;
using ProgSchool.Application.Features.Languages.Commands.DeleteLanguage;
using ProgSchool.Application.Features.Languages.Commands.UpdateLanguage;
using ProgSchool.Application.Features.Languages.Dtos;
using ProgSchool.Application.Features.Languages.Models;
using ProgSchool.Application.Features.Languages.Queries.GetByIdLanguage;
using ProgSchool.Application.Features.Languages.Queries.GetListLanguage;

namespace ProgSchool.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateLanguageCommand createLanguageCommand)
        {
            //CreatedLanguageDto result = await .Send
            CreatedLanguageDto result = await Mediator.Send(createLanguageCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListLanguageQuery getListLanguageQuery = new() { PageRequest = pageRequest };
            LanguageListModel result = await Mediator.Send(getListLanguageQuery);

            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdLanguageQuery getByIdLanguageQuery)
        {
            LanguageGetByIdDto languageGetByIdDto = await Mediator.Send(getByIdLanguageQuery);
            return Ok(languageGetByIdDto);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> DeleteById([FromRoute] DeleteLanguageCommand deleteLanguageCommand)
        {
            DeletedLanguageDto deletedLanguageDto = await Mediator.Send(deleteLanguageCommand);
            return Ok(deletedLanguageDto);
        }

        [HttpPut("{Id}/{Name}")]
        public async Task<IActionResult> UpdateById([FromRoute] UpdateLanguageCommand updateLanguageCommand)
        {
            UpdatedLanguageCommandDto updatedLanguageCommandDto = await Mediator.Send(updateLanguageCommand);
            return Ok(updatedLanguageCommandDto);
        }
    }
}
