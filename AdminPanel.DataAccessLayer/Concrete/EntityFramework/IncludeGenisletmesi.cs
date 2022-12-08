//using AdminPanel.EntityLayer.Concrete.Other.ArabaKismi;
//using AdminPanel.EntityLayer.Concrete.Other.AuthenticationKismi;
//using AdminPanel.EntityLayer.Concrete.Other.FirmaKismi;
//using AdminPanel.EntityLayer.Concrete.Other.HizmetKismi;
//using AdminPanel.EntityLayer.Concrete.Other.MusteriKismi;
//using AdminPanel.EntityLayer.Concrete.Other.PaketKismi;
//using AdminPanel.EntityLayer.Concrete.Other.PersonelKismi;
//using Microsoft.EntityFrameworkCore;

//namespace AdminPanel.DataAccessLayer.Concrete.EntityFramework
//{
//    internal static class IncludeGenisletmesi
//    {
//        internal static void AutoInclude(this ModelBuilder modelBuilder)
//        {
//            #region Authentication kısmı
//            //modelBuilder.Entity<TokensTable>().HasOne(e=>e.mailPassword).WithMany().OnDelete(DeleteBehavior.ClientCascade);

//            modelBuilder.Entity<TokensTable>().Navigation(e => e.mailPassword).AutoInclude();
//            #endregion

//            #region Araba kısmı
//            modelBuilder.Entity<Araba>().Navigation(e => e.kasaTip).AutoInclude();
//            modelBuilder.Entity<Araba>().Navigation(e => e.marka).AutoInclude();
//            modelBuilder.Entity<Araba>().Navigation(e => e.tip).AutoInclude();
//            modelBuilder.Entity<Araba>().Navigation(e => e.vitesTip).AutoInclude();

//            modelBuilder.Entity<ArabaAitOzellik>().Navigation(e => e.araba).AutoInclude();
//            modelBuilder.Entity<ArabaAitOzellik>().Navigation(e => e.ozellik).AutoInclude();
//            #endregion

//            #region Firma kısmı
//            modelBuilder.Entity<Bayi>().Navigation(e => e.firma).AutoInclude();
//            modelBuilder.Entity<Bayi>().Navigation(e => e.iletisim).AutoInclude();

//            modelBuilder.Entity<BayiYonetici>().Navigation(e => e.firma).AutoInclude();
//            modelBuilder.Entity<BayiYonetici>().Navigation(e => e.bayi).AutoInclude();
//            modelBuilder.Entity<BayiYonetici>().Navigation(e => e.personel).AutoInclude();

//            modelBuilder.Entity<Firma>().Navigation(e => e.iletisim).AutoInclude();

//            modelBuilder.Entity<FirmaSahip>().Navigation(e => e.firma).AutoInclude();
//            modelBuilder.Entity<FirmaSahip>().Navigation(e => e.personel).AutoInclude();
//            #endregion

//            #region Hizmet Kısmı
//            modelBuilder.Entity<HizmetAlt>().Navigation(e => e.hizmet).AutoInclude();

//            modelBuilder.Entity<HizmetAltOzellik>().Navigation(e => e.hizmetAlt).AutoInclude();
//            #endregion

//            #region Müşteri Kısmı
//            modelBuilder.Entity<Musteri>().Navigation(e => e.firma).AutoInclude();
//            #endregion

//            #region Paket Kısmı
//            modelBuilder.Entity<PaketAitOzellik>().Navigation(e => e.paket).AutoInclude();
//            modelBuilder.Entity<PaketAitOzellik>().Navigation(e => e.ozellik).AutoInclude();
//            #endregion

//            #region Personel Kısmı
//            modelBuilder.Entity<PersonelGorev>().Navigation(e => e.personel).AutoInclude();

//            modelBuilder.Entity<PersonelSifre>().Navigation(e => e.personel).AutoInclude();

//            modelBuilder.Entity<PersonelSosyalMedya>().Navigation(e => e.personel).AutoInclude();

//            modelBuilder.Entity<PersonelSosyalMedya>().Navigation(e => e.sosyalMedyaLogo).AutoInclude();
//            #endregion
//        }
//    }
//}
