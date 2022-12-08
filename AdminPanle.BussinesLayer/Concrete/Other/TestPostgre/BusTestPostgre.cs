using AdminPanel.DataAccessLayer.Abstract.Other.Genel.TestPostgre;
using AdminPanel.EntityLayer.Concrete.Other.TestPostgre;
using AdminPanle.BusinessLayer.Abstract.Other.TestPostgre;
using AdminPanle.BusinessLayer.Concrete.Base;

namespace AdminPanle.BusinessLayer.Concrete.Other.TestPostgre
{
    public class BusTestPostgre:EntityBusBase<testpostgre,IDalTestPostgre>,IBusTestPostgre
    {
        public BusTestPostgre(IDalTestPostgre entityDalBase):base(entityDalBase)
        {

        }
    }
}
