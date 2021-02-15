using Orcamento.Web.Models;
using System.Security.Principal;

namespace Orcamento.Web
{
    internal class AplicacaoPrincipal : GenericPrincipal
    {
        public UsuarioViewModel Dados { get; set; }

        public AplicacaoPrincipal(IIdentity identity, string[] roles, int id) : base(identity, roles)
        {
            Dados = UsuarioViewModel.RecuperarPeloId(id);
        }
    }
}