using AdminPanel.EntityLayer.Abctract;
using System.Linq.Expressions;

namespace AdminPanel.DataAccessLayer.Abstract.Base
{
    public interface IEntityDalBase<TEntity>
        where TEntity : class, IEntity, new()
    {//Kübra
        /***
         * sil delete
         * guncelle udpdate
         * ekle add
         * getir get
         */
        /// <summary>
        /// Silme işlemi yapar 
        /// sonuc başarılı ise true diğer durumlarda false
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(TEntity entity, DateTime? silmeZamani = null);

        /// <summary>
        /// Güncelleme işlemi yapar 
        /// sonuc başarılı ise true diğer durumlarda false
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(TEntity entity, DateTime? guncellemeZamani = null);

        /// <summary>
        /// Ekleme işlemi yapar 
        /// sonuc başarılı ise true diğer durumlarda false
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> AddAsync(TEntity entity, DateTime? kayitZamani = null);

        #region getirme işlemleri
        ///// <summary>
        ///// Getirme işlemi yapar 
        ///// Filtreye göre
        ///// </summary>
        ///// <param name="entity"></param>
        ///// <returns></returns>
        //Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Getirme işlemi yapar 
        /// Duruma göre ;)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filter = null);
        /**
         * Geetirm işleminin özelleştirme işlemi iş katmanında yapılacaktır
         */

        Task<int> GetTotalCountAsync(Expression<Func<TEntity, bool>>? filter = null);
        
        Task<List<TEntity>> GetPaginationAsync(int pageItemsCount, int pageIndex, Expression<Func<TEntity, bool>>? filter = null, bool desc = false);

        Task<List<TEntity>> GetPaginationAsync<Tkey>(int pageItemsCount, int pageIndex, Expression<Func<TEntity, Tkey>>? orderFilter, Expression<Func<TEntity, bool>>? filter = null, bool desc = false);
        #endregion

    }
}
