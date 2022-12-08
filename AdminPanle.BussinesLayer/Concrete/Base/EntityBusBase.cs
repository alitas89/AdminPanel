
using AdminPanel.DataAccessLayer.Abstract.Base;
using AdminPanel.EntityLayer.Abctract;
using AdminPanle.BusinessLayer.Abstract.Base;
using AdminPanle.BusinessLayer.Other.Extensions;
using AdminPanle.BusinessLayer.Other.Response;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.Extensions.Options;
using System;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;

namespace AdminPanle.BusinessLayer.Concrete.Base
{
    public class EntityBusBase<TEntity, DalBase> : IEntityBusBase<TEntity>
        where TEntity : class, IEntity, new()
        where DalBase : class, IEntityDalBase<TEntity>
    {
        protected DalBase _entityDalBase;
        public EntityBusBase(DalBase entityDalBase)
        {
            //deneme
            _entityDalBase = entityDalBase;
        }

        #region Ekleme işlemleri
        public async Task<ObjectResponse<object>> AddAsync(TEntity entity)
        {
            ObjectResponse<object> result;
            //bool result = false;

            if (entity.isIdEmpty())
            {
                try
                {
                    if (await _entityDalBase.AddAsync(entity))
                        result = new ObjectResponse<object>(true);
                    else
                        result = new ObjectResponse<object>("Ekeleme işlemi başarısız");
                }
                catch (Exception ex)
                {
                    result = new ObjectResponse<object>("Eklemişleminde hata ile karşılaşıldı. :\n\t" + ex.Message);
                }
            }
            else
                result = new ObjectResponse<object>("Geçersiz parametre");

            return result;
        }

        public async Task<ObjectResponse<object>> AddAsync(List<TEntity> entities)
        {
            ObjectResponse<object> result;

            try
            {
                if (entities != null && entities.Count() > 0)
                {
                    result = new ObjectResponse<object>(true);
                    foreach (TEntity entity in entities)
                    {

                        if (!(await _entityDalBase.AddAsync(entity)))
                        {
                            result = new ObjectResponse<object>("Liste ekleme işleminde ekelenemeyen nesneler oluştu");
                            break;
                        }
                    }
                }
                else
                    result = new ObjectResponse<object>("Geçersiz parametre");
            }
            catch (Exception ex)
            {
                result = new ObjectResponse<object>("Nesneler eklenirken hata ile karşılaşıldı. :\n\t" + ex.Message);
            }

            return result;
        }

        public async Task<ObjectResponse<TEntity>> AddByAsync(TEntity entity)
        {
            ObjectResponse<TEntity> result;
            try
            {
                if (entity.isNotNull())
                {
                    DateTime dateTime = DateTime.Now;

                    if (await _entityDalBase.AddAsync(entity, dateTime))
                        result = new ObjectResponse<TEntity>(entity); // adres aynı olduğu için ilgili nesne gelir
                    //result = new ObjectResponse<TEntity>(
                    //    (await _entityDalBase.GetAsync()).FirstOrDefault(p => p.kayitZamani == dateTime));
                    else
                        result = new ObjectResponse<TEntity>("Nesne eklenemedi");
                }
                else
                    result = new ObjectResponse<TEntity>("Geçersiz parametre");
            }
            catch (Exception ex)
            {
                result = new ObjectResponse<TEntity>("Nesne eklenirken hata ile karşılaşıldı. :\n\t" + ex.Message);
            }

            return result;
        }
        #endregion

        #region Silme işlemleri
        public async Task<ObjectResponse<object>> DeleteAsync(List<TEntity> entities)
        {
            ObjectResponse<object> result;
            try
            {
                if (entities != null && entities.Count() > 0)
                {
                    result = new ObjectResponse<object>(true);
                    foreach (TEntity entity in entities)
                    {

                        if (!await _entityDalBase.DeleteAsync(entity))
                        {
                            result = new ObjectResponse<object>("Silme işleminde silinemeyen nesneler oldu");
                            break;
                        }
                    }
                }
                else
                    result = new ObjectResponse<object>("Geçersiz parametre");
            }
            catch (Exception ex)
            {
                result = new ObjectResponse<object>("Nesneler silinirken hata ile karşılaşıldı. :\n\t" + ex.Message);
            }
            return result;
        }

        public async Task<ObjectResponse<object>> DeleteAsync(int id)
        {
            ObjectResponse<object> result = new ObjectResponse<object>(true);
            try
            {
                if (id > 0)
                {
                    TEntity? entity = (await _entityDalBase.GetAsync(e => e.id == id)).FirstOrDefault();
                    if (entity.isNotNull() && !entity.silinmisMi())
                    {
                        if (!await _entityDalBase.DeleteAsync(entity))
                            result = new ObjectResponse<object>($"{id} li nesne silinemedi");
                    }
                    else
                        result = new ObjectResponse<object>("Nesne bulunamadı veya silinmiş");
                }
                else
                    result = new ObjectResponse<object>("Geçersiz parametre");

            }
            catch (Exception ex)
            {
                result = new ObjectResponse<object>("Nesne silinirken hata ile karşılaşıldı. :\n\t" + ex.Message);
            }
            return result;
        }

        public async Task<ObjectResponse<object>> DeleteAsync(TEntity entity)
        {
            ObjectResponse<object> result;
            try
            {
                if (entity.isIdNotEmpty())
                {
                    if (await _entityDalBase.DeleteAsync(entity))
                        result = new ObjectResponse<object>(true);
                    else
                        result = new ObjectResponse<object>("Silme işlemi ilgili nesne için başarısız");
                }
                else
                    result = new ObjectResponse<object>("Geçersiz parametre");
            }
            catch (Exception ex)
            {
                result = new ObjectResponse<object>("Nesne silinirken hata ile karşılaşıldı. :\n\t" + ex.Message);
            }
            return result;
        }
        #endregion

        #region Getirme işlemleri
        public async Task<ObjectResponse<List<TEntity>>> GetAllAsync()
        {
            ObjectResponse<List<TEntity>> result;
            var entities = await _entityDalBase.GetAsync();

            try
            {
                if (entities != null && entities.Count < 0)
                    result = new ObjectResponse<List<TEntity>>("Veriler getirilemedi");
                else
                    result = new ObjectResponse<List<TEntity>>(entities);
            }
            catch (Exception ex)
            {
                result = new ObjectResponse<List<TEntity>>("Nesneler getirilirken hata ile karşılaşıldı. :\n\t" + ex.Message);
            }

            return result;
        }

        public async Task<ObjectResponse<TEntity>> GetByIdAsync(int id)
        {
            ObjectResponse<TEntity> result;
            try
            {
                if (id > 0)
                    result = new ObjectResponse<TEntity>((await _entityDalBase.GetAsync(e => e.id == id)).FirstOrDefault());
                else
                    result = new ObjectResponse<TEntity>("Geçersiz parametre");
            }
            catch (Exception ex)
            {
                result = new ObjectResponse<TEntity>("Nesne getirilirken hata ile karşılaşıldı. :\n\t" + ex.Message);
            }
            return result;
        }

        public async Task<ObjectResponse<List<TEntity>>> GetPage(int pageItemsCount, int pageIndex)
        {
            ObjectResponse<List<TEntity>> result;

            try
            {
                var entities = await this._entityDalBase.GetPaginationAsync(pageItemsCount, pageIndex);
                if (entities.isNotNull() && entities.isNotEmpty())
                {
                    result = new ObjectResponse<List<TEntity>>(entities);
                }
                else
                    result = new ObjectResponse<List<TEntity>>("İlgili nesneler getirilemedi");
            }
            catch (Exception ex)
            {
                result = new ObjectResponse<List<TEntity>>("Nesneler getirilirken hata ile karşılaşıldı. :\n\t" + ex.Message);
            }

            return result;
        }

        public async Task<ObjectResponse<PageResponse<TEntity>>> GetPage
            (int pageItemsCount, int pageIndex, string? orderFieldName, string? searchString, bool desc = false)
        {
            ObjectResponse<PageResponse<TEntity>> result;
            string searchQuery = null;
            Func<TEntity, bool> filter =(p=>p.isNull());

            try
            {
                var opt = ScriptOptions.Default.AddReferences(typeof(TEntity).Assembly);
                var EType = typeof(TEntity);
                var properties = EType.GetRuntimeProperties();

                properties = properties.Where(p => p.Name.ToLower().Trim() != "id");

                var dynamicColumn = properties.Where(p => p.Name.ToLower() == orderFieldName.ToLower().Trim()).FirstOrDefault();


                Expression<Func<TEntity, object>>? orderQurey = (p=>p.id);

                if (searchString != null && searchString.Trim().Length > 0)
                {
                    searchQuery = getSearchQuery(properties, searchString);

                    filter = await CSharpScript.EvaluateAsync<Func<TEntity, Boolean>>(searchQuery, opt);
                }

                if (orderFieldName != null && orderFieldName.Trim().Length > 0)
                {
                    orderQurey = await CSharpScript.EvaluateAsync < Expression<Func < TEntity, object >>> ($"p=>p.{dynamicColumn.Name}", opt); // 90% patlayacak
                }

                var entities = await this._entityDalBase.GetPaginationAsync<object>(pageItemsCount, pageIndex,orderQurey, Expression.Lambda<Func<TEntity, bool>>(Expression.Call(filter.Method)), desc);
                var totalCount = await this._entityDalBase.GetTotalCountAsync(Expression.Lambda<Func<TEntity, bool>>(Expression.Call(filter.Method)));
                if (entities.isNotNull() && entities.isNotEmpty())
                {
                    result = new ObjectResponse<PageResponse<TEntity>>(new PageResponse<TEntity>(entities,totalCount));
                }
                else
                    result = new ObjectResponse<PageResponse<TEntity>>("İlgili nesneler getirilemedi");

            }
            catch (Exception ex)
            {
                result = new ObjectResponse<PageResponse<TEntity>>("Nesneler getirilirken hata ile karşılaşıldı. :\n\t" + ex.Message);
            }

            return result;
        }

        private string getSearchQuery(IEnumerable<PropertyInfo> properties, string searchString)
        {
            string result = null;
            if (properties != null && properties.Count() > 0)
            {
                result = "p => ";
                foreach (var property in properties)
                {
                    //if () liste controlü yapılacak
                    //    continue;

                    result += "p." + property.Name +  ".ToString().ToLower().Trim().CompareTo(\""+searchString.Trim().ToLower()+"\") ||";
                }
                result = result.Substring(0, result.Length - 2); // ensondaki yada karakteri kaldırılıyor.
            }

            return result;
        }

        public async Task<ObjectResponse<object>> GetItemsTotalCount()
        {
            ObjectResponse<object> result;
            try
            {
                int response = await _entityDalBase.GetTotalCountAsync();

                if (response < 0)
                    throw new Exception("İmkansız sayı!");

                result = new ObjectResponse<object>(response);
            }
            catch (Exception ex)
            {
                result = new ObjectResponse<object>("Nesnelerin toplam sayısı getirilirken hata ile karşılaşıldı. :\n\t" + ex.Message);
            }

            return result;
        }

        #endregion

        #region Güncellem İşlemleri
        public async Task<ObjectResponse<object>> UpdateAsync(TEntity entity)
        {
            ObjectResponse<object> result;

            try
            {
                if (entity.isNotNull() && entity.isIdNotEmpty())
                    //if (await _entityDalBase.UpdateAsync(entity))
                    //    result = new ObjectResponse<object>(true);
                    //else
                    //    result = new ObjectResponse<object>("Nesne güncellenemedi");
                    result = new ObjectResponse<object>("Güncelleme işlemi devre dışı bırakıldı");
                else
                    result = new ObjectResponse<object>("Geçersiz parametre");
            }
            catch (Exception ex)
            {
                result = new ObjectResponse<object>("Nesne güncellenirken hata ile karşılaşıldı. :\n\t" + ex.Message);
            }

            return result;
        }

        public async Task<ObjectResponse<TEntity>> UpdateByAsync(TEntity entity)
        {
            ObjectResponse<TEntity> result;

            try
            {
                if (entity.isNotNull() && entity.isIdNotEmpty())
                {
                    DateTime dateTime = DateTime.Now;
                    //entity.guncellemeZamani = dateTime;

                    //if (await _entityDalBase.UpdateAsync(entity))
                    //{
                    //    result = new ObjectResponse<TEntity>((await _entityDalBase.GetAsync(
                    //        e => e.guncellemeZamani == dateTime &&
                    //        e.Id == entity.Id)).FirstOrDefault());
                    //}
                    //else
                    //    result = new ObjectResponse<TEntity>("Güncelleme işlemi başarısız");
                    result = new ObjectResponse<TEntity>("Güncelleme işlemi devre dışı bırakıldı");
                }
                else
                    result = new ObjectResponse<TEntity>("Geçersiz parametre");
            }
            catch (Exception ex)
            {
                result = new ObjectResponse<TEntity>("Nesne güncellenirken hata ile karşılaşıldı. :\n\t" + ex.Message);
            }

            return result;
        }

       
        #endregion
    }
}
