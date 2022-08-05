using AutoMapper;
using System;
using System.Linq;
using TesteAPI.Services.Token;

namespace TesteAPI.BLL
{
    public class UsuarioBLL : Interfaces.IUsuarioBLL
    {
        private readonly DAL.Repositories.Interfaces.IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UsuarioBLL(DAL.Repositories.Interfaces.IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;   
        }
        
        public dynamic Logar(MLL.ViewObject.UsuarioVO user)
        {

            var userBase = _uow.UsuarioRepositorio.GetAll(x => x.Login == user.Login && x.Senha == user.Senha).FirstOrDefault();

            if (userBase is null)
                throw new System.Exception("Usuário informado é invalido");


            var token = TokenService.GenerateToken(userBase);

            return new MLL.Acesso
            {
                Token = token,
                Data_expiracao = DateTime.Now.AddHours(1).ToString()
            };
            
        }
    }
}
