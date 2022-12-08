using AdminPanel.DataAccessLayer.Abstract.Other.EntityFramework.Postgre;
using AdminPanel.EntityLayer.Abctract;
using Microsoft.EntityFrameworkCore;

namespace AdminPanel.DataAccessLayer.Concrete.EntityFramework.Base.Postgre
{
    public class EntityEfDalPostgre<TEntity,TContext>:EntityEfDal<TEntity,TContext>,IEntityDalBasePostgre<TEntity>
        where TEntity : class,IEntity,new()
        where TContext : DbContext,new()
    {
    }
}
