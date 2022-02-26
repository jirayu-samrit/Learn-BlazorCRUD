using BlazorCRUD.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCRUD.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SuperHeroController : ControllerBase
	{
		static List<Comic> comics = new List<Comic>()
		{
			new Comic(){ Id=1, Name ="Marvel"},
			new Comic(){ Id=2, Name ="DC"}
		};
		static List<SuperHero> heroes = new List<SuperHero>()
		{
			new SuperHero(){Id = 1, FirstName="Peter", LastName="Parker", HeroName="Spiderman", Comic = comics[0]},
			new SuperHero(){Id = 2, FirstName="Bruce", LastName="Wayne", HeroName="Batman", Comic = comics[1]}
		};

		[HttpGet]
		public async Task<IActionResult> GetSuperHeroes()
		{
			return Ok(heroes);
		}

		[HttpGet("comics")]
		public async Task<IActionResult> GetComics()
		{
			return Ok(comics);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetSuperHero(int id)
		{
			SuperHero hero = heroes.FirstOrDefault(h => h.Id == id);
			if (hero == null)
			{
				return NotFound("Super Hero not found. too bad...");
			}

			return Ok(hero);
		}

		[HttpPost]
		public async Task<IActionResult> CreateSuperHero(SuperHero hero)
		{
			hero.Id = heroes.Max(h => h.Id + 1);
			heroes.Add(hero);
			return Ok(heroes);
		}
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateSuperHero(SuperHero hero, int id)
		{
			SuperHero dbhero = heroes.FirstOrDefault(h => h.Id == id);
			if (dbhero == null)
			{
				return NotFound("Super Hero not found. too bad...");
			}

			dbhero.FirstName = hero.FirstName.ToString();
			dbhero.LastName = hero.LastName.ToString();
			dbhero.HeroName = hero.HeroName.ToString();
			dbhero.Comic = hero.Comic;


			return Ok(heroes);
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteSuperHero(int id)
		{
			SuperHero dbhero = heroes.FirstOrDefault(h => h.Id == id);
			if (dbhero == null)
			{
				return NotFound("Super Hero not found. too bad...");
			}
			heroes.Remove(dbhero);

			return Ok(heroes);
		}
	}
}
