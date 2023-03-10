namespace VinaCent.Blaze.EntityFrameworkCore.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly BlazeDbContext _context;

        public InitialHostDbBuilder(BlazeDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
            new DefaultTextTemplatesCreator(_context).Create();
            
            _context.SaveChanges();
        }
    }
}
