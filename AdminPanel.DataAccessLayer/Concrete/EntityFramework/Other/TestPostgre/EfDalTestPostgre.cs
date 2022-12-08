using AdminPanel.DataAccessLayer.Abstract.Other.Genel.TestPostgre;
using AdminPanel.DataAccessLayer.Concrete.EntityFramework.Base.Postgre;
using AdminPanel.EntityLayer.Concrete.Other.TestPostgre;
using Microsoft.EntityFrameworkCore;

namespace AdminPanel.DataAccessLayer.Concrete.EntityFramework.Other.TestPostgre
{
    public class EfDalTestPostgre<TContext> : EntityEfDalPostgre<testpostgre,TContext>, IDalTestPostgre
        where TContext : DbContext,new()
    {
    }
}
