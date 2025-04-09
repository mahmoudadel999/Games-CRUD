namespace GameZone.Services
{
    public class DevicesService : IDevicesService
    {
        private readonly AppDbContext _dbContext;

        public DevicesService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<SelectListItem> GetSelectList()
        {
            return _dbContext.Devices
                 .Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name })
                 .OrderBy(d => d.Text)
                 .AsNoTracking()
                 .ToList();
        }
    }
}
