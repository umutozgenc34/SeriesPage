using SeriesPage.Model.Scenes.Entities;
using SeriesPage.Repository.Context;
using SeriesPage.Repository.Scenes.Abstracts;
using Shared.Repositories;

namespace SeriesPage.Repository.Scenes.Concretes;

public class SceneRepository(AppDbContext context) : BaseRepository<AppDbContext,Scene,int>(context),ISceneRepository;

