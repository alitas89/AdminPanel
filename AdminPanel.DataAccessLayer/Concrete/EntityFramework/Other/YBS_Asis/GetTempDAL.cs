using AdminPanel.DataAccessLayer.Abstract.Other.Genel.YBS_Asis;
using AdminPanel.EntityLayer.Concrete.Other.Ybs_Filo;
using AdminPanel.DataAccessLayer.Concrete.EntityFramework.Base.Oracle;
using Microsoft.EntityFrameworkCore;

namespace AdminPanel.DataAccessLayer.Concrete.EntityFramework.Other.YBS_Asis
{
    public class GetTempDAL<TContext> : EntityEfDalOracle<TEMP_SOSYALYARDIM3, TContext>, IGetTempDAL
        where TContext : DbContext, new() // Data access layer oluşturucu içerisinden verilecektir.
    {

        
    }
}
