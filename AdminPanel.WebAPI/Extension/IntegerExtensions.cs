namespace AdminPanel.WebAPI.Extension
{
    public static class IntegerExtensions
    {
        /// <summary>
        /// if value <= 0 return true
        /// else return false
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static bool isInvalid(this int Id)
        {
            return Id <= 0;
        }
        /// <summary>
        /// if value > 0 return true
        /// else return false
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static bool isNotInvalid(this int Id)
        {
            return Id > 0;
        }

    }
}
