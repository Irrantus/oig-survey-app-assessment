using Common.Models;
using Common.Models.ViewModels.Questionnaire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuestionnaireApi.Common;
using QuestionnaireApi.Data.Entities;
using QuestionnaireApi.Services;

namespace QuestionnaireApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class QuestionnaireController : ControllerBase
    {
        private readonly ILogger<QuestionnaireController> _logger;
        private readonly IQuestionnaireService _questionnaireService;

        public QuestionnaireController(
            ILogger<QuestionnaireController> logger,
            IQuestionnaireService questionnaireService)
        {
            _logger = logger;
            _questionnaireService = questionnaireService;
        }

        [HttpGet]
        public IEnumerable<QuestionnaireViewModel> Get([FromQuery] SortParams sortParams)
        {
            return _questionnaireService.GetQuestionnaires(sortParams);
        }

        [HttpGet("GetById/{id}")]
        public QuestionnaireViewModel GetById([FromRoute] int id)
        {
            return _questionnaireService.GetQuestionnaireById(id);
        }

        [HttpPost]
        public QuestionnaireViewModel Create([FromBody] CreateQuestionnaireViewModel createModel)
        {
            return _questionnaireService.CreateQuestionnaire(createModel);
        }

        [HttpPut]
        public QuestionnaireViewModel Update([FromBody] UpdateQuestionnaireViewModel updateModel)
        {
            return _questionnaireService.UpdateQuestionnaire(updateModel);
        }

        [HttpPatch("Close/{id}")]
        public bool CloseQuestionnaire([FromRoute] int id)
        {
            return _questionnaireService.CloseQuestionnaire(id);
        }
    }
}