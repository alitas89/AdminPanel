using AdminPanel.DataAccessLayer.Abstract.Other.Genel.YBS_Asis;
using AdminPanel.EntityLayer.Abctract;
using AdminPanel.EntityLayer.Concrete.Other.Ybs_Filo;
using AdminPanle.BusinessLayer.Abstract.Other.Ybs_Filo;
using AdminPanle.BusinessLayer.Concrete.Base;
using AdminPanle.BusinessLayer.Other.Extensions;
using AdminPanle.BusinessLayer.Other.Response;
using System.Linq.Expressions;

namespace AdminPanle.BusinessLayer.Concrete.Other.Ybs_Filo
{
    public class BusGetTemp : EntityBusBase<TEMP_SOSYALYARDIM3, IGetTempDAL>, IBusGetTemp
    {
        public BusGetTemp(IGetTempDAL entityDalBase) : base(entityDalBase)
        {
            
        }

        public async Task<ObjectResponse<List<TEMP_SOSYALYARDIM3>>> GetByTCAsync(string TC)
        {
            ObjectResponse<List<TEMP_SOSYALYARDIM3>> response;
            if (TC.isNotEmpty() && TC.Length == 11) {
                List<TEMP_SOSYALYARDIM3> result = null;

                try
                {
                     result = (await this._entityDalBase.GetAsync(p => p.tcNo == TC));
                    if (result.isNotNull())
                    {
                        response = new ObjectResponse<List<TEMP_SOSYALYARDIM3>>(result);
                    }
                    else
                    {
                        response = new ObjectResponse<List<TEMP_SOSYALYARDIM3>>("İlgli TC de kayıt bulunamadı.");
                    }
                }
                catch (Exception ex)
                {
                    response = new ObjectResponse<List<TEMP_SOSYALYARDIM3>>("ilgili nesneler getirilirken hata oluştu. :\n\t" + ex.Message);
                }
            }
            else
            {
                response = new ObjectResponse<List<TEMP_SOSYALYARDIM3>>("Geçersiz Parametre: geçersiz TC");
            }

                return response;
        }

        public async Task<ObjectResponse<PageResponse<TEMP_SOSYALYARDIM3>>> GetPageOrderByDogumYili(int pageItemsCount, int pageIndex)
        {
            ObjectResponse<PageResponse<TEMP_SOSYALYARDIM3>> result;
            Expression<Func<TEMP_SOSYALYARDIM3, bool>>? filter = p => p.dogumYili != null && !p.dogumYili.Trim().Equals("0"); // doğum yılı null olmayan ve 0 olmayanlar
            try
            {
                int totalCount = await this._entityDalBase.GetTotalCountAsync(filter);
                var entities = await this._entityDalBase.GetPaginationAsync(pageItemsCount, pageIndex,p=>p.dogumYili,filter,false);
                if (entities.isNotNull() && entities.isNotEmpty())
                {
                    result = new ObjectResponse<PageResponse<TEMP_SOSYALYARDIM3>>
                        (new PageResponse<TEMP_SOSYALYARDIM3>(entities,totalCount));
                }
                else
                    result = new ObjectResponse<PageResponse<TEMP_SOSYALYARDIM3>>("İlgili nesneler getirilemedi");
            }
            catch (Exception ex)
            {
                result = new ObjectResponse<PageResponse<TEMP_SOSYALYARDIM3>>("Nesneler getirilirken hata ile karşılaşıldı. :\n\t" + ex.Message);
            }

            return result;
        }
    }
}
