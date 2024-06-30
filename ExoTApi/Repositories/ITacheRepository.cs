using ExoTModels;

namespace ExoTApi.Repositories
{
    public interface ITacheRepository
    {
        void Creer(TacheCreation Tache);

        List<Tache> RecuperationTotale();

        Tache RecuperationParId(int Id);

        void Suppression(int Id);

        void Modification(int Id,TacheUpdate Tache);
    }
}
