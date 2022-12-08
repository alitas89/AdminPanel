using AdminPanel.DataAccessLayer.Abstract.Other.Genel.AuthenticationKismi;
using AdminPanel.DataAccessLayer.Abstract.Other.Genel.TestPostgre;
using AdminPanel.DataAccessLayer.Abstract.Other.Genel.YBS_Asis;
using AdminPanel.DataAccessLayer.Concrete.EntityFramework;
using AdminPanel.DataAccessLayer.Concrete.EntityFramework.Other.AuthenticationKismi;
using AdminPanel.DataAccessLayer.Concrete.EntityFramework.Other.TestPostgre;
using AdminPanel.DataAccessLayer.Concrete.EntityFramework.Other.YBS_Asis;

namespace AdminPanel.DataAccessLayer.Other
{
    /// <summary>
    /// Data Access Layer Nesne Olusturucusu
    /// </summary>
    public class DalOlusturucu
    {
        private static DalOlusturucu? _nesneOlusturucu;
        private static readonly object kilit = new object();


        #region Authentication kısmı
        public IDalTokensTable TokensTable { get; }
        public IDalTokensMailPassword TokensMailPassword { get; }
        #endregion

        #region YBS_TEMP
        public IGetTempDAL getTempDAL { get; }
        #endregion

        #region PostgreSql veritabanı testi
        public IDalTestPostgre TestPostgre { get; }
        #endregion


        private DalOlusturucu()
        {

            #region Authentication kısmı
            TokensTable = new EfDalTokensTable();
            TokensMailPassword = new EfDalTokensMailPassword();
            #endregion

            #region YBS_TEMP
            getTempDAL = new GetTempDAL<EFContextOracle>();
            #endregion

            #region PostgreSql veritabanı testi
            TestPostgre = new EfDalTestPostgre<EfContextPostgre>();
            #endregion

        }

        public static DalOlusturucu Olustur()
        {
            if (_nesneOlusturucu.isNull())
            {
                lock (kilit)
                {
                    if (_nesneOlusturucu.isNull())
                    {
                        _nesneOlusturucu = new DalOlusturucu();
                    }
                }
            }
            return _nesneOlusturucu;
        }
    }

    internal static class genislet
    {
        internal static bool isNull(this DalOlusturucu olusturucu)
        {
            return olusturucu == null;
        }
    }
}
