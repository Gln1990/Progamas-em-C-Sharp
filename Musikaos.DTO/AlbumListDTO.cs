using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musikaos.DTO
{
    public class AlbumListDTO
    {
        public int IdAlbum { get; set; }
        public string NomeAlbum { get; set; }
        public string ArtistaAlbum { get; set; }
        public string SeloAlbum { get; set; }
        public string UrlImagemAlbum { get; set; }
        public string DescricaoGenero { get; set; }
    }
}
