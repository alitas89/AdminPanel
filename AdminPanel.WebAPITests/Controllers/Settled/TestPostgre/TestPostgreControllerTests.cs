using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdminPanel.WebAPI.Controllers.Base.Tests;
using AdminPanle.BusinessLayer.Abstract.Other.TestPostgre;
using AdminPanel.EntityLayer.Concrete.Other.TestPostgre;

namespace AdminPanel.WebAPI.Controllers.Settled.TestPostgre.Tests
{
    [TestClass()]
    public class TestPostgreControllerTests: BaseControllerTests<TestPostgreController,IBusTestPostgre,testpostgre>
    {
        [TestInitialize]
        public void ClassKurulum()
        {
            this.Kur();
        }
    }
}