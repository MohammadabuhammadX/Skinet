using Core.Entities;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        Task<int> Complete(); //the idea behind this , is going to return the number of the changes to our database , the Ef is going to track all of the changes to the entities whether we add whether we remove we add things to a list whatever we do insidde uown, this part going to save our changes to our database
    }
}
