using MongoDB.Driver;
using Symptoms.Api.Domain.DTOs;
using Symptoms.Api.Domain.Models;

namespace Symptoms.Api.Domain
{
    public interface ISymptomRepository
    {
        public Task<Symptom> GetSymptomByIdAsync(string symptomId);
        public Task<List<Symptom>> GetAllSymptomsAsync();
        public Task<Symptom> AddSymptomAsync(Symptom symptom);
        public Task UpdateSymptomAsync(string symptomId, SymptomDto symptomDto);
        public Task<DeleteResult> DeleteSymptomAsync(string symptomId);
        public Task<List<SymptomHistory>> GetSymptomHistoryAsync();
        Task<List<SymptomHistory>> GetSymptomHistoryByIdAsync(string symptomId);

    }
}
