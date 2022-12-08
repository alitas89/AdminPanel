using AdminPanel.AppSettings;
using AdminPanel.EntityLayer.Abctract;
using AdminPanel.WebAPI.Extension;
using AdminPanle.BusinessLayer.Abstract.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdminPanel.WebAPI.Controllers.Base.Tests
{

    public class BaseControllerTests<TController, ITEntityBusBase, TEntity>
        where TController : BaseController<ITEntityBusBase,TEntity>,new()
        where ITEntityBusBase : class, IEntityBusBase<TEntity>
        where TEntity : class, IEntity, new()

    {
        private protected static TController _controller;

        internal static void test()
        {
            var builder = WebApplication.CreateBuilder();

            builder.AppSettingsConfigure();

            builder.Services.AddConnectionString();
            builder.Services.AddConnectionStringPostgre();
            builder.Services.AddCrosAyari();
        }
        
        public  void Kur()
        {
            _controller = new TController();
        }

        [TestMethod()]
        public async Task GetItemsTotalCountTest()
        {
            //Hazırlık
            ObjectResult response;
            
            //Eylem
            response = (ObjectResult)(await _controller.GetItemsTotalCount());
            
            temellYanitIslem(response,typeof(int));

            //Tez
            Assert.IsTrue((int)response.Value >= 0,"Veriler gelirken imkansız değer döndü \n değer:"+response.Value);
        }

        [TestMethod()]
        public async Task GetPageTest()
        {
            //Hazırlık
            int pageItemsCount = 10;
            int pageIndex = 1;
            ObjectResult response;

            //Eylem
            response =  (ObjectResult)(await _controller.GetPage(pageItemsCount, pageIndex)).Result;
            
            temellYanitIslem(response,typeof(List<TEntity>));
            
            //Tez
            Assert.IsNotNull(response.Value,"Veri gelmedi. Boş döndü");
            Assert.IsTrue(((List<TEntity>)response.Value).Count > 0,"Liste Boş döndü");
            Assert.IsTrue(((List<TEntity>)response.Value).Count <= pageItemsCount && ((List<TEntity>)response.Value).Count > 0, "İstenen sayıda veri dönmedi.");
        }

        private protected void temellYanitIslem(ObjectResult response,Type beklenenValueType)
        {
            //Hazırlık
            Type beklenenTip = typeof(OkObjectResult);
            int beklenenStatusCode = StatusCodes.Status200OK;

            //var responseVal = response.Value;
            var statusCode = response.StatusCode;

            //Tez
            Assert.AreEqual(beklenenTip, response.GetType(), "Gelen yanıt tipi beklenmeyen\nTip: " + response.GetType());
            Assert.AreEqual(beklenenStatusCode, statusCode,"Beklenmeyen bir status code geldi.\nStatusCode: "+statusCode);
            Assert.IsInstanceOfType(response.Value, beklenenValueType,"Beklenmeyen değer tipi.\nDönen Tip: "+response.Value.GetType());
        }

        //[TestMethod()]
        //public void GetByIdTest()
        //{
        //    Assert.Fail();
        //}


    }
}