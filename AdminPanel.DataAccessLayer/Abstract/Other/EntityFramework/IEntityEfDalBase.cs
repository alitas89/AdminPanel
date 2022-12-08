using AdminPanel.DataAccessLayer.Abstract.Base;
using AdminPanel.EntityLayer.Abctract;
using System.Linq.Expressions;

namespace AdminPanel.DataAccessLayer.Abstract.Other.EntityFramework
{
    public interface IEntityEfDalBase<TEntity> : IEntityDalBase<TEntity>
        where TEntity : class, IEntity, new()
    {
        
    }
}
