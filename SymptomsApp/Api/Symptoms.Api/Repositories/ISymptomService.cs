using MongoDB.Driver;
using Symptoms.Api.Domain.DTOs;
using Symptoms.Api.Domain.Models;

namespace Symptoms.Api.Repositories
{
    public interface ISymptomService
    {
        public Task<Symptom> GetSymptomByIdAsync(string symptomId);
        public Task<List<Symptom>> GetAllSymptomsAsync();
        public Task<Symptom> AddSymptomAsync(Symptom symptom);
        public Task UpdateSymptomAsync(Symptom symptom, SymptomDto symptomDto);
        public Task<DeleteResult> DeleteSymptomAsync(string symptomId);
        public Task<List<SymptomHistory>> GetSymptomHistoryAsync();
        Task<List<SymptomHistory>> GetSymptomHistoryByIdAsync(string symptomId);

    }
}
