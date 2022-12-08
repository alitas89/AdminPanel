using AdminPanel.DataAccessLayer.Other;
using AdminPanle.BusinessLayer.Abstract.Other.AuthenticationKismi;
using AdminPanle.BusinessLayer.Abstract.Other.TestPostgre;
using AdminPanle.BusinessLayer.Abstract.Other.Ybs_Filo;
using AdminPanle.BusinessLayer.Concrete.Other.AuthenticationKismi;
using AdminPanle.BusinessLayer.Concrete.Other.TestPostgre;
using AdminPanle.BusinessLayer.Concrete.Other.Ybs_Filo;

namespace AdminPanle.BusinessLayer.Other
{
    /// <summary>
    /// Business Layer Nesne oluşturucusu
    /// </summary>
    public class BusOlusturucu
    {
        private static BusOlusturucu _olusturucu;
        private static readonly object _object = new object();


        #region Authentication Kismi
        public IBusTokensTable TokensTable { get; }
        public IBusTokensMailPassword TokensMailPassword { get; }
        #endregion

        #region YBS_TEMP
        public IBusGetTemp BusGetTemp { get; }
        #endregion

        #region PostgreSql veritabanı testi
        public IBusTestPostgre TestPostgre { get; }
        #endregion

        private BusOlusturucu()
        {

            #region Authentication kısmı
            TokensMailPassword = new BusTokensMailPassword(DalOlusturucu.Olustur().TokensMailPassword);
            TokensTable = new BusTokensTable(DalOlusturucu.Olustur().TokensTable);
            //Authentication = new BusAuthentication();//sonsuz döngüye giriyor
            #endregion

            #region YBS_TEMP
            BusGetTemp = new BusGetTemp(DalOlusturucu.Olustur().getTempDAL);
            #endregion

            #region PostgreSql veritabanı testi
            TestPostgre = new BusTestPostgre(DalOlusturucu.Olustur().TestPostgre);
            #endregion
        }

        public static BusOlusturucu Olustur()
        {
            if (_olusturucu.isNull())
            {
                lock (_object)
                {
                    if (_olusturucu.isNull())
                    {
                        _olusturucu = new BusOlusturucu();
                    }
                }
            }
            return _olusturucu;
        }

    }

    internal static class geniset
    {
        internal static bool isNull(this BusOlusturucu olusturucu)
        {
            return olusturucu == null;
        }
    }
}
