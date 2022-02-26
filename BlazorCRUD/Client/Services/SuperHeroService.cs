using BlazorCRUD.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorCRUD.Client.Services
{
	public class SuperHeroService : ISuperHeroService
	{
		private readonly HttpClient _httpClient;

		public event Action OnChange;

		public List<Comic> Comics { get; set; } = new List<Comic>();
		public List<SuperHero> Heroes { get; set; } = new List<SuperHero>();

		public SuperHeroService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<SuperHero>> CreateSuperHero(SuperHero hero)
		{
			HttpResponseMessage result = await _httpClient.PostAsJsonAsync($"api/SuperHero", hero);
			Heroes= await result.Content.ReadFromJsonAsync<List<SuperHero>>();
			OnChange.Invoke();
			return Heroes;
		}

		public async Task GetComics()
		{
			Comics = await _httpClient.GetFromJsonAsync<List<Comic>>("api/superhero/comics");
		}

		public async Task<SuperHero> GetSuperHero(int id)
		{
			return await _httpClient.GetFromJsonAsync<SuperHero>($"api/SuperHero/{id}");
		}

		public async Task<List<SuperHero>> GetSuperHeroes()
		{
			Heroes = await _httpClient.GetFromJsonAsync<List<SuperHero>>("api/SuperHero");
			return Heroes;
		}

		public async Task<List<SuperHero>> UpdateSuperHero(SuperHero hero, int id)
		{
			HttpResponseMessage result = await _httpClient.PutAsJsonAsync($"api/SuperHero/{id}", hero);
			Heroes = await result.Content.ReadFromJsonAsync<List<SuperHero>>();
			OnChange.Invoke();
			return Heroes;
		}

		public async Task<List<SuperHero>> DeleteSuperHero(int id)
		{
			HttpResponseMessage result = await _httpClient.DeleteAsync($"api/SuperHero/{id}");
			Heroes = await result.Content.ReadFromJsonAsync<List<SuperHero>>();
			OnChange.Invoke();
			return Heroes;
		}
	}
}
