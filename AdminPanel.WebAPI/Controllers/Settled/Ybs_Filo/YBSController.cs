using AdminPanel.EntityLayer.Concrete.Other.Ybs_Filo;
using AdminPanel.WebAPI.Controllers.Base;
using AdminPanle.BusinessLayer.Abstract.Other.Ybs_Filo;
using AdminPanle.BusinessLayer.Other;
using AdminPanle.BusinessLayer.Other.Response;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanel.WebAPI.Controllers.Settled.Ybs_Filo
{
    public class YBSController : BaseController<IBusGetTemp, TEMP_SOSYALYARDIM3>
    {
        public YBSController() : base(BusOlusturucu.Olustur().BusGetTemp)
        {

        }

        [HttpGet]
        [Route("[controller]/GetByTC/{TC}")]
        public async Task<ActionResult<List<TEMP_SOSYALYARDIM3>>> GetByTC(string TC)
        {
            ActionResult result;

            result = dondur(await _entityBusBase.GetByTCAsync(TC));

            return result;
        }

        [HttpGet]
        [Route("[controller]/[Action]/")]
        public async Task<ActionResult<PageResponse<List<TEMP_SOSYALYARDIM3>>>> GetPageByDogumYili(int pageItemsCount, int pageIndex)
        {
            ActionResult result;

            result = dondur(await _entityBusBase.GetPageOrderByDogumYili(pageItemsCount,pageIndex));

            return result;
        }
        
    }
         
}
