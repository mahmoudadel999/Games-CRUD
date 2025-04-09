namespace GameZone.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly AppDbContext _dbContext;

        public CategoriesService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<SelectListItem> GetSelectList()
        {
            return _dbContext.Categories
                              .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                              .OrderBy(c => c.Text)
                              .ToList();
        }
    }
}
