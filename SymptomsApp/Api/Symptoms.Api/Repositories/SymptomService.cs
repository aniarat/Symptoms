﻿using MongoDB.Driver;
using Symptoms.Api.Data;
using Symptoms.Api.Domain.DTOs;
using Symptoms.Api.Domain.Models;

namespace Symptoms.Api.Repositories
{
    public class SymptomService : ISymptomService
    {
        private readonly IMongoCollection<Symptom>? _symptoms;
        private readonly IMongoCollection<SymptomHistory>? _symptomsHistory;

        public SymptomService(MongoDbService mongoDbService)
        {
            _symptoms = mongoDbService.Database?.GetCollection<Symptom>("symptom");
            _symptomsHistory = mongoDbService.Database?.GetCollection<SymptomHistory>("symptom_history");

        }

        public async Task<Symptom> GetSymptomByIdAsync(string symptomId)
        {
            var filter = Builders<Symptom>.Filter.Eq(x => x.Id, symptomId);
            return await _symptoms.Find(filter).FirstOrDefaultAsync();
            //return symptom;
            //var objectId = ObjectId.Parse(symptomId);

            //return await _symptoms.Find(x => x.Id == objectId).FirstOrDefaultAsync();
        }

        public async Task<List<Symptom>> GetAllSymptomsAsync()
        {
            return await _symptoms.Find(_ => true).ToListAsync();
        }

        public async Task<Symptom> AddSymptomAsync(Symptom symptom)
        {
            if (string.IsNullOrEmpty(symptom.Id))
            {
                symptom.Id = null;
            }
            var existingSymptomsOfType = await _symptoms.Find(s => s.PainType == symptom.PainType).ToListAsync();
            var occurrenceCounter = existingSymptomsOfType.Count + 1;
            symptom.OccurrenceCounter = occurrenceCounter;

            await _symptoms.InsertOneAsync(symptom);
            return symptom;
        }


        public async Task<DeleteResult> DeleteSymptomAsync(string symptomId)
        {
            var filter = Builders<Symptom>.Filter.Eq(x => x.Id, symptomId);
            return await _symptoms.DeleteOneAsync(filter);


            //var objectId = ObjectId.Parse(symptomId);
            //return await _symptoms.DeleteOneAsync(x => x.Id == objectId);
        }

        public async Task UpdateSymptomAsync(Symptom symptom, SymptomDto updatedSymptom)
        {
            //var objectId = ObjectId.Parse(symptom.Id); // Konwertuj string na ObjectId

            var filter = Builders<Symptom>.Filter.Eq(x => x.Id, symptom.Id);
            var oldSymptom = await _symptoms.Find(filter).FirstOrDefaultAsync();
            if (oldSymptom != null)
            {
                var modifiedFields = new List<string>();

                if (oldSymptom.SeverityScale != updatedSymptom.SeverityScale)
                    modifiedFields.Add("SeverityScale");
                if (oldSymptom.SymptomDurationHours != updatedSymptom.SymptomDurationHours)
                    modifiedFields.Add("SymptomDurationHours");

                foreach (var fieldName in modifiedFields)
                {
                    var oldValue = oldSymptom.GetType().GetProperty(fieldName)?.GetValue(oldSymptom)?.ToString();
                    var newValue = updatedSymptom.GetType().GetProperty(fieldName)?.GetValue(updatedSymptom)?.ToString();

                    await SaveSymptomHistoryAsync(symptom.Id, fieldName, oldValue, newValue);
                }

                // Update symptom fields
                oldSymptom.SeverityScale = updatedSymptom.SeverityScale;
                oldSymptom.SymptomDurationHours = updatedSymptom.SymptomDurationHours;

                // Save changes to symptoms collection
                await _symptoms.ReplaceOneAsync(filter, oldSymptom);
            }
            else
            {
                throw new Exception("Symptom not found");
            }
        }

        private async Task SaveSymptomHistoryAsync(string symptomId, string fieldName, string oldValue, string newValue)
        {

            var history = new SymptomHistory
            {
                SymptomId = symptomId,
                FieldName = fieldName,
                OldValue = oldValue,
                NewValue = newValue,
                ModifiedDate = DateTime.Now
            };

            await _symptomsHistory.InsertOneAsync(history);
        }

        public async Task<List<SymptomHistory>> GetSymptomHistoryAsync()
        {
            return await _symptomsHistory.Find(_ => true).ToListAsync();
        }

        public async Task<List<SymptomHistory>> GetSymptomHistoryByIdAsync(string symptomId)
        {

            //var objectId = ObjectId.Parse(symptomId);
            var filter = Builders<SymptomHistory>.Filter.Eq(s => s.SymptomId, symptomId);
            var histories = await _symptomsHistory.Find(filter).ToListAsync();
            return histories.Select(h => new SymptomHistory
            {
                FieldName = h.FieldName,
                OldValue = h.OldValue,
                NewValue = h.NewValue,
                ModifiedDate = h.ModifiedDate
            }).ToList();
        }
    }
}
