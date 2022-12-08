using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdminPanel.WebAPI.Controllers.Base.Tests;
using AdminPanel.EntityLayer.Concrete.Other.Ybs_Filo;
using AdminPanle.BusinessLayer.Abstract.Other.Ybs_Filo;

namespace AdminPanel.WebAPI.Controllers.Settled.Ybs_Filo.Tests
{
    [TestClass()]
    public class YBSControllerTests:BaseControllerTests<YBSController, IBusGetTemp, TEMP_SOSYALYARDIM3>
    {
        [AssemblyInitialize]
        public static void Asembly (TestContext context)
        {
            test();
        }

        [TestInitialize]
        public  void Kurulum()
        {
            this.Kur();
        }

    }
}