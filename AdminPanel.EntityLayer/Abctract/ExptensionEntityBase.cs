
namespace AdminPanel.EntityLayer.Abctract
{
    public static class ExptensionEntityBase
    {
        /// <summary>
        /// silinip slinmeme durumu:
        /// silimiş ise true diğer tüm durumlarda false
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool silinmisMi(this IEntity entity)
        {
            return !entity.isNull(); //& entity.sil;
        }

        /// <summary>
        /// null ise true diğer durumda false
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool isNull(this IEntity? entity) => entity == null;

        /// <summary>
        /// null değil ise true diğer durumda false
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool isNotNull(this IEntity? entity) => entity != null;

        /// <summary>
        /// id atalı değil ise true diğer durumlarda false
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool isIdEmpty(this IEntity entity) => entity.isNotNull() && entity.id <= 0;

        /// <summary>
        /// id atalı ise true diğer durumlarda false
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool isIdNotEmpty(this IEntity entity) => entity.isNotNull() && entity.id > 0;
    }
}
