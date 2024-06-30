using ExoTContext;
using ExoTModels;
using Microsoft.EntityFrameworkCore;

namespace ExoTApi.Repositories
{
    public class TacheRepository : ITacheRepository
    {
        private readonly ExoContext _context;

        public TacheRepository(IDbContextFactory<ExoContext> factory)
        {
            _context = factory.CreateDbContext();
        }

        public void Creer(TacheCreation tache)
        {
            Tache tache1 = new Tache
            {
                Titre = tache.Titre
            };
            _context.Tache.Add(tache1);
            _context.SaveChanges();
        }

        public void Modification(int Id ,TacheUpdate tache)
        {

            Tache tacheDb = _context.Tache.SingleOrDefault(t => t.Id == Id);

            tacheDb.Titre = tache.Titre;
            tacheDb.Terminer = tache.Terminer;
            _context.Tache.Update(tacheDb);
            _context.SaveChanges();

        }

        public Tache RecuperationParId(int Id)
        {
           return  _context.Tache.SingleOrDefault(t => t.Id == Id);
        }

        public List<Tache> RecuperationTotale()
        {
            return _context.Tache.ToList();
        }

        public void Suppression(int Id)
        {
            var tache = _context.Tache.SingleOrDefault(t => t.Id == Id);
            if (tache != null)
            {
                _context.Tache.Remove(tache);
                _context.SaveChanges();
            }

        }
    }
}
