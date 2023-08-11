using Microsoft.EntityFrameworkCore;
using MovieHub.Contracts;
using MovieHub.Data;
using MovieHub.Data.Models;
using MovieHub.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHub.Services
{
    public class ActorService:IActorService
    {
        private readonly MovieHubDbContext db;

        public ActorService(MovieHubDbContext context)
        {
            db = context;
        }
        public async Task<AddActorViewModel> GetNewAddActorModelAsync()
        {
            var rewads = await db.Rewards.Select(x => new RewardViewModel
            {
                Id = x.Id,
                Title = x.Title
            }).ToListAsync();

            var model = new AddActorViewModel()
            {
                Rewards = rewads
            };
            return model;
        }
        public async Task<ActorDetailsViewModel?> GetActorByIdAsync(Guid id)
        {
            var searchedActor = await db.Actors.FirstAsync(x => x.Id == id);
            var actor = await db.Actors.Where(x => x.Id == id).Select(x => new ActorDetailsViewModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                ImgURL = x.ImgURL,
                BornDate = x.BornDate,
                Description = x.Description,
                BornCityName = x.BornCityName,
                Movies = x.Movies
            }).FirstOrDefaultAsync();
            foreach (var item in searchedActor.Rewards)
            {
                actor.Rewards.Add(item);
            }
            foreach (var item in actor.Movies)
            {
                item.Movie = await db.Movies.FirstOrDefaultAsync(x => x.Id == item.MovieId);
            }
            return actor;
        }
        public async Task AddActorAsync(AddActorViewModel actor, Guid Id)
        {
            bool IsExist = await db.Actors.AnyAsync(x => x.FirstName == actor.FirstName && x.LastName == actor.LastName && x.Description == actor.Description);
            Movie movieToAdd = await db.Movies.FirstAsync(x => x.Id == Id);
            var rewards = new List<RewardViewModel>
            {
                actor.FirstReward,actor.SecondReward, actor.ThirdReward
            };
            MovieActor movieActor = new MovieActor
            {
                MovieId = movieToAdd.Id,
                Movie = movieToAdd
            };
            if (!IsExist)
            {
                var actorCreate = new Actor
                {
                    Id = Guid.NewGuid(),
                    FirstName = actor.FirstName,
                    LastName = actor.LastName,
                    BornCityName = actor.BornCityName,
                    Description = actor.Description,
                    BornDate = actor.BornDate,
                    DeathDate = actor.DeathDate,
                    ImgURL = actor.ImgURL
                };
                for (int i = 0; i < rewards.Count; i++)
                {
                    if (rewards[i] != null)
                    {

                        actorCreate.Rewards.Add(await db.Rewards.FirstAsync(x => x.Id == rewards[i].Id));
                    }
                }
                movieActor.Actor = actorCreate;
                movieActor.ActorId = actorCreate.Id;
                actorCreate.Movies.Add(movieActor);
                await db.Actors.AddAsync(actorCreate);
            }
            else
            {
                Actor findActor = await db.Actors.FirstAsync(x => x.FirstName == actor.FirstName && x.LastName == actor.LastName && x.Description == actor.Description);
                movieActor.Actor = findActor;
                movieActor.ActorId = findActor.Id;
                findActor.Movies.Add(movieActor);
            }
            movieToAdd.MovieActors.Add(movieActor);




            await db.MoviesActors.AddAsync(movieActor);

            await db.SaveChangesAsync();
        }
        public async Task<AddActorViewModel?> GetActorByIdForEditAsync(Guid Id)
        {
            var rewads = await db.Rewards.Select(x => new RewardViewModel
            {
                Id = x.Id,
                Title = x.Title
            }).ToListAsync();

            return await db.Actors.Where(x => x.Id == Id).Select(x => new AddActorViewModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Description = x.Description,
                Rewards = rewads,
                BornDate = x.BornDate,
                ImgURL = x.ImgURL,
                DeathDate = x.DeathDate,
                BornCityName = x.BornCityName
            }).FirstOrDefaultAsync();
        }
        public async Task EditActorAsync(AddActorViewModel model)
        {
            var currActor = await db.Actors.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
            if (currActor == null)
            {
                return;
            }
            var rewards = new HashSet<RewardViewModel>
            {
                model.FirstReward,model.SecondReward, model.ThirdReward
            };

            currActor.FirstName = model.FirstName;
            currActor.LastName = model.LastName;
            currActor.Description = model.Description;
            currActor.BornDate = model.BornDate;
            currActor.DeathDate = model.DeathDate;
            currActor.BornCityName = model.BornCityName;
            currActor.ImgURL = model.ImgURL;

            currActor.Rewards.Clear();

            foreach (var reward in rewards)
            {
                if (reward != null)
                {

                    currActor.Rewards.Add(await db.Rewards.FirstAsync(x => x.Id == reward.Id));
                }
            }

            await db.SaveChangesAsync();
        }
        public async Task DeleteActorAsync(Guid actorId)
        {
            var actor = await db.Actors.Include(x => x.Rewards).FirstOrDefaultAsync(x => x.Id == actorId);

            var movieActors = await db.MoviesActors.Where(x => x.ActorId == actorId).ToListAsync();


            actor.Rewards.Clear();
            if (actor != null)
            {
                actor.Rewards.Clear();
                db.MoviesActors.RemoveRange(movieActors);

                db.Actors.Remove(actor);
            }
            await db.SaveChangesAsync();
        }
       
    }
}
