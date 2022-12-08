using AdminPanel.DataAccessLayer.Abstract.Other.EntityFramework.Oracle;
using AdminPanel.EntityLayer.Abctract;
using Microsoft.EntityFrameworkCore;

namespace AdminPanel.DataAccessLayer.Concrete.EntityFramework.Base.Oracle
{
    public class EntityEfDalOracle<TEntity, TContext> : EntityEfDal<TEntity,TContext>,IEntityEfDalBaseOracle<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
   
    {
        //Override
        public async Task<bool> AddAsync(TEntity entity, DateTime? kayitZamani = null)
        {
            bool result = false;
            using (TContext context = new TContext())
            {

                if (entity.isNotNull())//entity.isNull() normalde ekleme nesnesinde Id olmaz lakin oracle için gerekli 
                {
                    
                    // son id yi alma start
                    int id = (context.Set<TEntity>().ToList().OrderByDescending(p => p.id).FirstOrDefault()).id;
                    id++;
                    entity.id = id;
                    // son id yi alma end
                    context.Entry(entity).State = EntityState.Added;
                    int response = await context.SaveChangesAsync();

                    if (response > 0)
                        result = true;
                }

            }
            return result;
        }

    }
}
