using Musikaos.DAL;
using Musikaos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musikaos.BLL
{
    public class GeneroBLL
    {
        GeneroDAL objDAL = new GeneroDAL();

        public List<GeneroDTO> ListarGenero()
        {
            return objDAL.Listar();
        }

        public GeneroDTO SelecionarGenero(int id)
        {
            return objDAL.Selecionar(id);
        }
    }
}
