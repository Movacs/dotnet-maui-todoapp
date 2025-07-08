using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TodoAppMaui.Models;

namespace TodoAppMaui.Services
{
    public class TodoApiService
    {
        private readonly HttpClient? _httpClient;

        public TodoApiService()
        {
            
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5555/")
            };
        }

        public async Task<List<TodoItem>?> GetTodoItemsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("todos");

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var json = await response.Content.ReadAsStringAsync();
#pragma warning disable CS8603 // Possible null reference return.
                return JsonSerializer.Deserialize<List<TodoItem>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
#pragma warning restore CS8603 // Possible null reference return.
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<bool> DeleteTodoItemAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"todos/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
