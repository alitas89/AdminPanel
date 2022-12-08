using AdminPanel.EntityLayer.Abctract;
using AdminPanle.BusinessLayer.Other.Response;

namespace AdminPanle.BusinessLayer.Abstract.Base
{
    // iş katmanı genel arayüzü
    // IEntityBusBase == InterfaceEntityBusinesLayerBase
    public interface IEntityBusBase<TEntity>
        where TEntity : class, IEntity, new()
    {
        #region Getirme işlemleri

        /// <summary>
        /// Liste olarak getirme 
        /// </summary>
        /// <returns></returns>
        Task<ObjectResponse<List<TEntity>>> GetAllAsync();

        /// <summary>
        /// id ye göre
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ObjectResponse<TEntity>> GetByIdAsync(int id);

        /// <summary>
        /// Sayfalam  işlemi içindir.
        /// Page index değeri normal insanların kullandığı değerler (ör: 1,2,3...) gibi yollanmalıdır.
        /// Eğerki sıfır veya bir yollanır ise aynı nesneler geri gelir.
        /// </summary>
        /// <param name="pageItemsCount"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        Task<ObjectResponse<List<TEntity>>> GetPage(int pageItemsCount, int pageIndex);

        Task<ObjectResponse<PageResponse<TEntity>>> GetPage(int pageItemsCount, int pageIndex,string? orderFieldName,string? searchString,bool desc=false);

        /// <summary>
        /// Toplam nesne sayısını öğrenmek içindir.
        /// </summary>
        /// <returns></returns>
        Task<ObjectResponse<object>> GetItemsTotalCount();
        #endregion

        #region Silme işlemleri

        /// <summary>
        /// Liste olarak siler
        /// sonuç başarılı ise true döndürür
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task<ObjectResponse<object>> DeleteAsync(List<TEntity> entities);

        /// <summary>
        /// id olarak siler
        /// sonuç başarılı ise true döndürür
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ObjectResponse<object>> DeleteAsync(int id);

        /// <summary>
        /// Göderilmiş olan nesneye göre siler
        /// sonuç başarılı ise true döndürür
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<ObjectResponse<object>> DeleteAsync(TEntity entity);
        #endregion

        #region Güncelleme işlemleri

        /// <summary>
        /// Güncelleme işlemi yapar
        /// işlem başarılı ise  success true diğer durumlarda false
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<ObjectResponse<object>> UpdateAsync(TEntity entity);

        /// <summary>
        /// Güncelleme işlemi yapar
        /// işlem başarılı ise nesneyi döndürür
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<ObjectResponse<TEntity>> UpdateByAsync(TEntity entity);
        #endregion

        #region Ekleme işlemleri
        /// <summary>
        /// Ekleme işlemi yapar teknesne için
        /// sonuç başarılı ise true döndürür
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<ObjectResponse<object>> AddAsync(TEntity entity);

        /// <summary>
        /// Liste olarak ekler
        /// sonuç başarılı ise true döndürür
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<ObjectResponse<object>> AddAsync(List<TEntity> entities);

        /// <summary>
        /// Ekleme işlemi yapar işlem başarılı ise kayıtlı halini geri dödürür
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<ObjectResponse<TEntity>> AddByAsync(TEntity entity);
        #endregion
    }
}
