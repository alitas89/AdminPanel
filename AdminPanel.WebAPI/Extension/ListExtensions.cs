using System.Collections;

namespace AdminPanel.WebAPI.Extension
{
    public static class ListExtensions
    {
        // liste boş vey null ise true
        public static bool isEmpty(this IList values) //where T : object

        {
            return values == null || values.Count <= 0;
        }

        // listedolu ve içinde enaz 1 eleman var ise true
        public static bool isNotEmpty(this IList values) //where T : object
        {
            return values != null && values.Count > 0;
        }
    }
}
