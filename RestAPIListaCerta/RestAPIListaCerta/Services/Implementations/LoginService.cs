using RestAPIListaCerta.Configurations;
using RestAPIListaCerta.Data.VO;
using RestAPIListaCerta.Repository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RestAPIListaCerta.Services.Implementations
{
    public class LoginService : ILoginService
    {
        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
        private TokenConfigurations _configuration;
        private IUsuariosRepository _repository;
        private readonly ITokenService _tokenService;

        public LoginService(TokenConfigurations configuration, IUsuariosRepository repository, ITokenService tokenService)
        {
            _configuration = configuration;
            _repository = repository;
            _tokenService = tokenService;
        }

        public TokenVO ValidateCredentials(UserVO userCredentials)
        {
            //Valida credenciais no banco
            var user = _repository.ValidateCredentials(userCredentials);
           
            if (user == null) return null;

            //Gera as Claims
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)

            };

            //Gera Token e RefreshToken
            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();
            
            //Seta os valores no usuário
            user.RefreshToken = refreshToken;
            user.ExpiryTime = DateTime.Now.AddDays(_configuration.DaysToExpiry);

            //Atualiza informações do usuário
            _repository.RefreshUserInfo(user);

            //Data que foi gerado o token
            DateTime createDate = DateTime.Now;
            //Data de expiração
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);


            //informações do token
            return new TokenVO(
                true,
                createDate.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                accessToken,
                refreshToken
                );
        }

        public TokenVO ValidateCredentials(TokenVO token)
        {
            //Gera Token e RefreshToken
            var accessToken = token.AccessToken;
            var refreshToken = token.RefreshToken;

            var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);

            var userName = principal.Identity.Name;

            var user = _repository.ValidateCredentials(userName);

            if (user == null || user.RefreshToken != refreshToken
                || user.ExpiryTime <= DateTime.Now) return null;

            accessToken = _tokenService.GenerateAccessToken(principal.Claims);
            refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;

            _repository.RefreshUserInfo(user);

            //Data que foi gerado o token
            DateTime createDate = DateTime.Now;
            //Data de expiração
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);


            //informações do token
            return new TokenVO(
                true,
                createDate.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                accessToken,
                refreshToken
                );

        }

        public bool RevokeToken(string userName)
        {
            return _repository.RevokeToken(userName);
        }
    }
}
