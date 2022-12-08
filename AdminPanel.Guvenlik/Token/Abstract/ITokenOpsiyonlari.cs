namespace AdminPanel.Guvenlik.Token.Abstract
{
    public interface ITokenOpsiyonlari
    {
        string Dinleyici { get; set; }
        string Yayinci { get; set; }

        /* Dk cünsinden tamsayı*/
        int AccessTokenSonKulanim { get; set; }
        int RefreshTokenSonKullanim { get; set; }
        int GecerlilikBaslamasi { get; set; }
        int GecikmeSuresi { get; set; }

        string GuvenlikAnahtari { get; set; }
    }
}
