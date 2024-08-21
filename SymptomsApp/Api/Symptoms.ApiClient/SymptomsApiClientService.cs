using Symptoms.ApiClient.Models;
using Symptoms.ApiClient.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Symptoms.ApiClient
{
    public class SymptomsApiClientService
    {
        private readonly HttpClient _httpClient;

        public SymptomsApiClientService(ApiClientOptions apiClientOptions)
        {
            var handler = new GlobalExceptionHandler
            {
                InnerHandler = new HttpClientHandler()
            };

            _httpClient = new HttpClient(handler) { BaseAddress = new Uri(apiClientOptions.ApiBaseAddress) };
        }

        // Pobiera listę objawów
        public async Task<List<Symptom>?> GetSymptoms()
        {
            var response = await _httpClient.GetAsync("/api/Symptoms");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<Symptom>>();
            }
            else
            {
                // Możesz obsłużyć błędy, jeśli potrzebujesz dodatkowej logiki
                Console.WriteLine($"Failed to get symptoms: {(int)response.StatusCode} - {response.ReasonPhrase}");
                return null;
            }
        }

        // Pobiera objaw według identyfikatora
        public async Task<Symptom?> GetById(string id)
        {
            var response = await _httpClient.GetAsync($"/api/Symptoms/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Symptom>();
            }
            else
            {
                // Możesz obsłużyć błędy, jeśli potrzebujesz dodatkowej logiki
                Console.WriteLine($"Failed to get symptom by ID: {(int)response.StatusCode} - {response.ReasonPhrase}");
                return null;
            }
        }

        // Dodaje nowy objaw
        public async Task<bool> SaveSymptom(Symptom symptom)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Symptoms", symptom);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                // Możesz obsłużyć błędy, jeśli potrzebujesz dodatkowej logiki
                Console.WriteLine($"Failed to add symptom: {(int)response.StatusCode} - {response.ReasonPhrase}");
                return false;
            }
        }

        // Aktualizuje istniejący objaw
        public async Task<bool> UpdateSymptom(Symptom symptom)
        {
            var response = await _httpClient.PutAsJsonAsync("/api/Symptoms", symptom);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                // Możesz obsłużyć błędy, jeśli potrzebujesz dodatkowej logiki
                Console.WriteLine($"Failed to update symptom: {(int)response.StatusCode} - {response.ReasonPhrase}");
                return false;
            }
        }

        // Usuwa objaw według identyfikatora
        public async Task<bool> DeleteSymptom(string id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Symptoms/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                // Możesz obsłużyć błędy, jeśli potrzebujesz dodatkowej logiki
                Console.WriteLine($"Failed to delete symptom: {(int)response.StatusCode} - {response.ReasonPhrase}");
                return false;
            }
        }
    }
}
//using Symptoms.ApiClient.Models;
//using Symptoms.ApiClient.Models.ApiModels;
//using System;
//using System.Collections.Generic;
//using System.Net.Http;
//using System.Net.Http.Json;
//using System.Text;
//using System.Threading.Tasks;

//namespace Symptoms.ApiClient
//{
//    public class SymptomsApiClientService
//    {
//        private readonly HttpClient _httpClient;
//        public SymptomsApiClientService(ApiClientOptions apiClientOptions)
//        {
//            //_httpClient = new HttpClient();
//            var handler = new GlobalExceptionHandler();
//            _httpClient = new HttpClient(handler) { BaseAddress = new Uri(apiClientOptions.ApiBaseAddress) };

//            //_httpClient.BaseAddress = new System.Uri(apiClientOptions.ApiBaseAddress);
//        }

//        public async Task<List<Symptom>?> GetSymptoms()
//        {
//            return await _httpClient.GetFromJsonAsync<List<Symptom>?>("/api/Symptoms");
//        }

//        public async Task<Symptom?> GetById(string id)
//        {
//            return await _httpClient.GetFromJsonAsync<Symptom?>($"/api/Symptoms/{id}");
//        }

//        public async Task SaveSymptom(Symptom symptom)
//        {
//            await _httpClient.PostAsJsonAsync("/api/Symptoms", symptom);
//        }

//        public async Task UpdateSymptom(Symptom symptom)
//        {
//            await _httpClient.PutAsJsonAsync("/api/Symptoms", symptom);
//        }

//        public async Task DeleteSymptom(string symptomId)
//        {
//            await _httpClient.DeleteAsync($"/api/Symptoms/{symptomId}");
//        }
//    }
//}
