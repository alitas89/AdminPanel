using AdminPanel.Guvenlik.Token.Abstract;

namespace AdminPanel.Guvenlik.Token.Concrete
{
    public class TokenOpsiyonlari : ITokenOpsiyonlari
    {
        public string Dinleyici { get; set; }
        public string Yayinci { get; set; }

        public int AccessTokenSonKulanim { get; set; }
        public int RefreshTokenSonKullanim { get; set; }
        public int GecerlilikBaslamasi { get; set; }

        public string GuvenlikAnahtari { get; set; }
        public int GecikmeSuresi { get; set; } = 0;
    }
}
