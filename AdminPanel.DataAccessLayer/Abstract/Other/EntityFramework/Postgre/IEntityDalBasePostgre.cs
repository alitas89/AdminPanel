using AdminPanel.EntityLayer.Abctract;

namespace AdminPanel.DataAccessLayer.Abstract.Other.EntityFramework.Postgre
{
    public interface IEntityDalBasePostgre<TEntity>:IEntityEfDalBase<TEntity>
        where TEntity : class,IEntity,new()
    {
    }
}
