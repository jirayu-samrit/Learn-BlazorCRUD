using BlazorCRUD.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorCRUD.Client.Services
{
	public interface ISuperHeroService
	{
		List<Comic> Comics { get; set; }
		List<SuperHero> Heroes { get; set; }

		event Action OnChange;
		Task<List<SuperHero>> GetSuperHeroes();
		Task<SuperHero> GetSuperHero(int id);
		Task<List<SuperHero>> CreateSuperHero(SuperHero hero);
		Task<List<SuperHero>> UpdateSuperHero(SuperHero hero,int id);
		Task<List<SuperHero>> DeleteSuperHero(int id);
		Task GetComics();
	}
}
