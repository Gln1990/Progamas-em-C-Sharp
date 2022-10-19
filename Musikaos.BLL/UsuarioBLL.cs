using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Musikaos.DAL;//
using Musikaos.DTO;//

namespace Musikaos.BLL
{
    public class UsuarioBLL
    {
        UsuarioDAL objBLL = new UsuarioDAL();

        //cadastrar
        public void CadastraUsuario(UsuarioDTO objCad)
        {
            objBLL.Cadastrar(objCad);
        }

        //Listar
        public List<UsuarioListDTO> ListarUsuario()
        {
            return objBLL.Listar();
        }

        //editar
        public void EditarUsuario(UsuarioDTO objEdita)
        {
            objBLL.Editar(objEdita);
        }

        //excluir

        public void ExcluirUsuario(int objExclui)
        {
            objBLL.Excluir(objExclui);
        }

        //autenticacao
        public UsuarioAutenticaDTO AutenticarUser(string objNome, string objSenha)
        {
                return objBLL.Autenticar(objNome, objSenha);
        }

    }
}
