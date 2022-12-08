using AdminPanel.EntityLayer.Concrete.Other.TestPostgre;
using AdminPanel.WebAPI.Controllers.Base;
using AdminPanle.BusinessLayer.Abstract.Other.TestPostgre;
using AdminPanle.BusinessLayer.Other;

namespace AdminPanel.WebAPI.Controllers.Settled.TestPostgre
{

    public class TestPostgreController : BaseController<IBusTestPostgre, testpostgre>
    {
        public TestPostgreController() : base(BusOlusturucu.Olustur().TestPostgre)
        {
        }
    }
}
