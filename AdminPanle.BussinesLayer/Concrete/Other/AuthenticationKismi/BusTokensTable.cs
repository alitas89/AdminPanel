using AdminPanel.DataAccessLayer.Abstract.Other.Genel.AuthenticationKismi;
using AdminPanel.EntityLayer.Abctract;
using AdminPanel.EntityLayer.Concrete.Other.AuthenticationKismi;
using AdminPanle.BusinessLayer.Abstract.Other.AuthenticationKismi;
using AdminPanle.BusinessLayer.Concrete.Base;
using AdminPanle.BusinessLayer.Other.Extensions;
using AdminPanle.BusinessLayer.Other.Response;

namespace AdminPanle.BusinessLayer.Concrete.Other.AuthenticationKismi
{
    public class BusTokensTable : EntityBusBase<TokensTable, IDalTokensTable>, IBusTokensTable
    {
        public BusTokensTable(IDalTokensTable entityDalBase) : base(entityDalBase)
        {
        }

        public async Task<ObjectResponse<List<TokensTable>>> GetByEmail(string email)
        {
            ObjectResponse<List<TokensTable>> result;
            if (email.isEmail())
            {
                try
                {
                    var list = await _entityDalBase.GetAsync(e => e.mailPassword.mail == email);

                    if (list.isNotEmpty())
                    {
                        result = new ObjectResponse<List<TokensTable>>(list);
                    }
                    else
                        result = new ObjectResponse<List<TokensTable>>("Kayıtlı veri bulunamadı");
                }
                catch (Exception ex)
                {
                    result = new ObjectResponse<List<TokensTable>>("Veriler getirilirken hata oluştu : " + ex.Message);
                }

            }
            else
                result = new ObjectResponse<List<TokensTable>>("Geçersiz argüman");
            return result;
        }

        public async Task<ObjectResponse<List<TokensTable>>> GetByGecerli()
        {
            ObjectResponse<List<TokensTable>> result;
            try
            {
                var list = await _entityDalBase.GetAsync(e => e.refreshTokenDate >= DateTime.Now);

                if (list.isNotEmpty())
                {
                    result = new ObjectResponse<List<TokensTable>>(list);
                }
                else
                    result = new ObjectResponse<List<TokensTable>>("Kayıtlı veri bulunamadı");
            }
            catch (Exception ex)
            {
                result = new ObjectResponse<List<TokensTable>>("Veriler getirilirken hata oluştu : " + ex.Message);
            }
            return result;
        }

        public async Task<ObjectResponse<List<TokensTable>>> GetByMailPassword(TokensMailPassword mailPassword)
        {
            ObjectResponse<List<TokensTable>> result;
            if (mailPassword.isNotNull())
            {
                try
                {
                    var list = await _entityDalBase.
                        GetAsync(e => e.mailPassword.mail == mailPassword.mail &&
                        e.mailPassword.password == mailPassword.password);

                    if (list.isNotEmpty())
                    {
                        result = new ObjectResponse<List<TokensTable>>(list);
                    }
                    else
                        result = new ObjectResponse<List<TokensTable>>("Kayıtlı veri bulunamadı");
                }
                catch (Exception ex)
                {
                    result = new ObjectResponse<List<TokensTable>>("Veriler getirilirken hata oluştu : " + ex.Message);
                }

            }
            else
                result = new ObjectResponse<List<TokensTable>>("Geçersiz argüman");
            return result;
        }

        public async Task<ObjectResponse<TokensTable>> GetByRefreshToken(string refreshToken)
        {
            ObjectResponse<TokensTable> result;
            if (refreshToken.isNotEmpty())
            {
                try
                {
                    var list = await _entityDalBase.GetAsync(e => e.refreshToken == refreshToken);

                    if (list.isNotEmpty())
                    {
                        result = new ObjectResponse<TokensTable>(list.FirstOrDefault());
                    }
                    else
                        result = new ObjectResponse<TokensTable>("Kayıtlı veri bulunamadı");
                }
                catch (Exception ex)
                {
                    result = new ObjectResponse<TokensTable>("Veriler getirilirken hata oluştu : " + ex.Message);
                }

            }
            else
                result = new ObjectResponse<TokensTable>("Geçersiz argüman");
            return result;
        }
    }
}
