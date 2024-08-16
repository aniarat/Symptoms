using Symptoms.ApiClient.Models;
using Symptoms.ApiClient.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Symptoms.ApiClient
{
    public class SymptomsApiClientService
    {
        private readonly HttpClient _httpClient;
        public SymptomsApiClientService(ApiClientOptions apiClientOptions)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new System.Uri(apiClientOptions.ApiBaseAddress);
        }

        public async Task<List<Symptom>?> GetSymptoms()
        {
            return await _httpClient.GetFromJsonAsync<List<Symptom>?>("/api/Symptoms");
        }

        public async Task<Symptom?> GetById(string id)
        {
            return await _httpClient.GetFromJsonAsync<Symptom?>($"/api/Symptoms/{id}");
        }

        public async Task SaveSymptom(Symptom symptom)
        {
            await _httpClient.PostAsJsonAsync("/api/Symptoms", symptom);
        }

        public async Task UpdateSymptom(Symptom symptom)
        {
            await _httpClient.PutAsJsonAsync("/api/Symptoms", symptom);
        }

        public async Task DeleteSymptom(string symptomId)
        {
            await _httpClient.DeleteAsync($"/api/Symptoms/{symptomId}");
        }
    }
}
