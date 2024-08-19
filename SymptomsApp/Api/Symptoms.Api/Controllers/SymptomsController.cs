using Microsoft.AspNetCore.Mvc;
using Symptoms.Api.Domain.Models;
using Symptoms.Api.Domain.DTOs;
using Symptoms.Api.Domain;

namespace Symptoms.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SymptomsController : ControllerBase
    {
        private readonly ISymptomRepository _symptomService;

        public SymptomsController(ISymptomRepository symptomService)
        {
            this._symptomService = symptomService;
        }


        [HttpGet]
        public async Task<List<Symptom>> GetSymptoms()
        {
            return await _symptomService.GetAllSymptomsAsync();
        }
        [HttpGet("{symptomId}")]
        public async Task<ActionResult<Symptom>> GetSymptom(string symptomId)
        {
            var symptom = await _symptomService.GetSymptomByIdAsync(symptomId);
            if (symptom is null)
            {
                return NotFound();
            }
            return symptom;
        }
        [HttpPost]
        public async Task<Symptom> Post(Symptom symptom)
        {
            await _symptomService.AddSymptomAsync(symptom);
            return symptom;
        }
        [HttpPut("{symptomId}")]
        public async Task<IActionResult> Update([FromRoute] string symptomId, [FromBody] SymptomDto updatedSymptom)
        {
            var symptom = await _symptomService.GetSymptomByIdAsync(symptomId);
            if (symptom is null)
            {
                return NotFound();
            }
            //updatedSymptom.Id = symptom.Id;
            await _symptomService.UpdateSymptomAsync(symptom, updatedSymptom);
            return Ok();
        }
        [HttpDelete("{symptomId}")]
        public async Task<IActionResult> Delete(string symptomId)
        {
            var symptom = await _symptomService.GetSymptomByIdAsync(symptomId);
            if (symptom is null)
            {
                return NotFound();
            }
            await _symptomService.DeleteSymptomAsync(symptomId);
            return Ok();
        }

        [HttpGet("history")]
        public async Task<List<SymptomHistory>> GetSymptomsHistory()
        {
            return await _symptomService.GetSymptomHistoryAsync();
        }

        [HttpGet("{symptomId}/history")]
        public async Task<List<SymptomHistory>> GetSymptomHistoryById(string symptomId)
        {
            var symptomHistory = await _symptomService.GetSymptomHistoryByIdAsync(symptomId);

            return symptomHistory;
        }

    }
}
