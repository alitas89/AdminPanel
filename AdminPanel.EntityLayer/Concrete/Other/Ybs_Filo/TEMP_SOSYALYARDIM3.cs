using AdminPanel.EntityLayer.Concrete.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPanel.EntityLayer.Concrete.Other.Ybs_Filo
{

    public class TEMP_SOSYALYARDIM3 : YbsFiloBase
    {
        [Column("ACIKLAMA")]
        public string? aciklama { get; set; }

        [Column("AD_SOYAD")]
        public string? adSoyad { get; set; }

        [Column("BELGE_NO")]
        public int? belgeNo { get; set; }

        [Column("CINSIYET")]
        public string? cinsiyet { get; set; }

        [Column("DOGUM_YILI")]
        public string? dogumYili { get; set; }

        [Column("DURUM")]
        public string? durum { get; set; }

        [Column("HANE_65YAS_USTU")]
        public string? hane65YasUstu { get; set; }

        [Column("HANE_COCUK_SAYISI")]
        public string? haneCocukSayisi { get; set; }

        [Column("HANE_KISI_SAYISI")]
        public string? haneKisiSayisi { get; set; }

        [Column("HANE_OGRENCI_DURUMU")]
        public string? haneOgrenciDurumu { get; set; }

        [Column("ILCE")]
        public string? ilce { get; set; }

        [Column("ISDELETED")]
        public int? silinmisMi { get; set; }

        [Column("KAYIT_TARIHI")]
        public DateTime? kayitTarihi { get; set; }

        [Column("KURUM")]
        public string? kurum { get; set; }

        [Column("MAHALLE")]
        public string? mahalle { get; set; }

        [Column("MEVKII")]
        public string? mevki { get; set; }

        [Column("PAKET_TIPI")]
        public string? paketTipi { get; set; }

        [Column("TC_NO")]
        public string? tcNo { get; set; }

        [Column("TELEFON")]
        public string? telefon { get; set; }

        [Column("YARDIM_TIPI")]
        public string? yardimTipi { get; set; }

        [Column("YARDIM_TUTARI")]
        public string? yardimTutari { get; set; }

    }
}
