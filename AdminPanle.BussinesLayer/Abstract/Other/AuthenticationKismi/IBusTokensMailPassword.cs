using AdminPanel.EntityLayer.Concrete.Other.AuthenticationKismi;
using AdminPanle.BusinessLayer.Abstract.Base;
using AdminPanle.BusinessLayer.Other.Response;

namespace AdminPanle.BusinessLayer.Abstract.Other.AuthenticationKismi
{
    public interface IBusTokensMailPassword : IEntityBusBase<TokensMailPassword>
    {
        Task<ObjectResponse<TokensMailPassword>> GetByEmail(string email);

        Task<ObjectResponse<TokensMailPassword>> GetByEmailAndPassword(string email, string password);
    }
}
