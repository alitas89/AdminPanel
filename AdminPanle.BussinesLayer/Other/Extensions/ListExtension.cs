using System.Collections;

namespace AdminPanle.BusinessLayer.Other.Extensions
{
    public static class ListExtension
    {
        /// <summary>
        /// nul değil ve içerisinde bir veri varsa true diğer durumlarda false
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool isNotEmpty(this IList list) => list.isNotNull() && list.Count > 0;

        /// <summary>
        /// null değil ise true diğer durumda false
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool isNotNull(this IList list) => list != null;
    }
}
