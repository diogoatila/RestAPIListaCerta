using RestAPIListaCerta.Data.VO;

namespace RestAPIListaCerta.Services
{
    public interface ILoginService
    {
        TokenVO ValidateCredentials(UserVO user);
        TokenVO ValidateCredentials(TokenVO token);

        bool RevokeToken(string userName);
    }
}
