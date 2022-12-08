

namespace AdminPanel.Guvenlik.Token.Objects
{
    public class AccessToken
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime SonKullanımTarihi { get; set; }
    }
}
