namespace GameZone.Services
{
    public interface IGamesService
    {
        IEnumerable<Game> GetAllGames();
        Game? GetById(int id);
        Task Create(CreateGameFormViewModel game);
        Task<Game?> Update(EditGameFormViewModel game);
        bool Delete(int id);
    }
}
