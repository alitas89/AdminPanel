using AdminPanel.DataAccessLayer.Abstract.Other.Genel.AuthenticationKismi;
using AdminPanel.EntityLayer.Concrete.Other.AuthenticationKismi;
using AdminPanle.BusinessLayer.Abstract.Other.AuthenticationKismi;
using AdminPanle.BusinessLayer.Concrete.Base;
using AdminPanle.BusinessLayer.Other.Extensions;
using AdminPanle.BusinessLayer.Other.Response;

namespace AdminPanle.BusinessLayer.Concrete.Other.AuthenticationKismi
{
    public class BusTokensMailPassword : EntityBusBase<TokensMailPassword, IDalTokensMailPassword>, IBusTokensMailPassword
    {
        public BusTokensMailPassword(IDalTokensMailPassword entityDalBase) : base(entityDalBase)
        {
        }

        public async Task<ObjectResponse<TokensMailPassword>> GetByEmail(string email)
        {
            ObjectResponse<TokensMailPassword> result;
            if (email.isEmail())
            {
                try
                {
                    var list = await this._entityDalBase.GetAsync(t => t.mail == email);

                    if (list != null && list.Count > 0)
                    {
                        result = new ObjectResponse<TokensMailPassword>(list.FirstOrDefault());
                    }
                    else
                        result = new ObjectResponse<TokensMailPassword>("Sistemde kayıtlı değildir.");
                }
                catch (Exception ex)
                {
                    result = new ObjectResponse<TokensMailPassword>("Nesneler getiriliken hata oluştu :" + ex.Message);
                }

            }
            else
                result = new ObjectResponse<TokensMailPassword>("Bu bir email değildir");

            return result;
        }

        public async Task<ObjectResponse<TokensMailPassword>> GetByEmailAndPassword(string email, string password)
        {
            ObjectResponse<TokensMailPassword> result;
            if (email.isEmail() && password.isNotEmpty())
            {
                try
                {
                    var list = await this._entityDalBase.GetAsync(t => t.mail == email && t.password == password);
                    if (list != null && list.Count > 0)
                    {
                        result = new ObjectResponse<TokensMailPassword>(list.FirstOrDefault());
                    }
                    else
                        result = new ObjectResponse<TokensMailPassword>("Sistemde kayıtlı değildir.");
                }
                catch (Exception ex)
                {
                    result = new ObjectResponse<TokensMailPassword>("Nesneler getiriliken hata oluştu :" + ex.Message);
                }
            }
            else
            {
                result = new ObjectResponse<TokensMailPassword>("Geçersiz parametre");
            }

            return result;
        }
    }
}
