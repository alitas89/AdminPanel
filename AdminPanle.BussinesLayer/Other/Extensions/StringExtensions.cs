namespace AdminPanle.BusinessLayer.Other.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// string null ve boş ise true
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool isEmpty(this string val) => string.IsNullOrEmpty(val);
        /// <summary>
        /// string nul değil ve boş deilse yani " " deilse true diğerdurumlarda false
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool isNotEmpty(this string val) => !string.IsNullOrEmpty(val) && val.Trim().Length > 0;

        /// <summary>
        /// boş deil ve email şartı olan xyz@mail.abc deki gibi @ var ve en az iki parça oluyor ise
        /// ve parça sonu olan mail.abc . ya göre parçalayınca en az iki parça oluyor ise bu bir emaildir
        /// der ve true döndürür
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool isEmail(this string val)
        {
            bool result;

            if (val.isNotEmpty())
            {
                var ilk = val.Split("@");

                if (ilk != null && ilk.Length >= 2)
                {
                    var son = ilk.LastOrDefault();
                    var kntrl = son.Split(".");

                    result = kntrl != null && kntrl.Length >= 2;
                }
                else
                    result = false;
            }
            else result = false;

            return result;
        }
    }
}
