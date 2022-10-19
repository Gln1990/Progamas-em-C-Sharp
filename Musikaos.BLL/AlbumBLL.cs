using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Musikaos.DAL;//
using Musikaos.DTO;//

namespace Musikaos.BLL
{
    public class AlbumBLL
    {
        AlbumDAL objBLL = new AlbumDAL();

        //cadastrar
        public void CadastraAlbum(AlbumDTO objCad)
        {
            objBLL.Cadastrar(objCad);
        }

        //Listar
        public List<AlbumListDTO> ListarAlbum()
        {
            return objBLL.Listar();
        }

        //Filtrar
        public List<AlbumListDTO> FiltrarAlbum()
        {
            return objBLL.Filtrar();
        }

        public List<AlbumListDTO> FiltrarAlbum(int idGenero)
        {
            return objBLL.Filtrar(idGenero);
        }


        //editar
        public void EditarAlbum(AlbumDTO objEdita)
        {
            objBLL.Editar(objEdita);
        }

        //excluir
        public void ExcluirAlbum(int objExclui)
        {
            objBLL.Excluir(objExclui);
        }

        public AlbumListDTO SelecionarAlbum(int idAlbum)
        {
            return objBLL.Selecionar(idAlbum);
        }
    }
}
