//using AdminPanel.EntityLayer.Concrete.Other.FirmaKismi;
//using Microsoft.EntityFrameworkCore;

//namespace AdminPanel.DataAccessLayer.Concrete.EntityFramework
//{
//    internal static class RelationshipRemoveGenisletmesi
//    {
//        internal static void RemoveRelationship(this ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Firma>().HasOne(e => e.iletisim).WithMany().OnDelete(DeleteBehavior.ClientCascade);
//            modelBuilder.Entity<Bayi>().HasOne(e => e.iletisim).WithMany().OnDelete(DeleteBehavior.ClientCascade);

//            modelBuilder.Entity<FirmaSahip>().HasOne(e => e.personel).WithMany().OnDelete(DeleteBehavior.ClientCascade);
//            modelBuilder.Entity<BayiYonetici>().HasOne(e => e.personel).WithMany().OnDelete(DeleteBehavior.ClientCascade);
//            modelBuilder.Entity<BayiYonetici>().HasOne(e => e.firma).WithMany().OnDelete(DeleteBehavior.ClientCascade);
//        }
//    }
//}
