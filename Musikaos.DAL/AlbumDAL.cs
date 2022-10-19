using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;//
using Musikaos.DTO;//


namespace Musikaos.DAL
{
    public class AlbumDAL : Conexao
    {
        //inserir
        public void Cadastrar(AlbumDTO objCad)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("INSERT INTO Album (Nomealbum,ArtistaAlbum,SeloAlbum,UrlImagemAlbum,FKGeneroAlbum) VALUES (@v1,@v2,@v3,@v4,@v5)", conn);
                cmd.Parameters.AddWithValue("@v1", objCad.NomeAlbum);
                cmd.Parameters.AddWithValue("@v2", objCad.ArtistaAlbum);
                cmd.Parameters.AddWithValue("@v3", objCad.SeloAlbum);
                cmd.Parameters.AddWithValue("@v4", objCad.UrlImagemAlbum);
                cmd.Parameters.AddWithValue("@v5", objCad.FKGeneroAlbum);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao cadastrar!! " + ex.Message);
            }
            finally
            {
                Desconectar();
            }

        }

        //listar
        public List<AlbumListDTO> Listar()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT IdAlbum,NomeAlbum,ArtistaAlbum,SeloAlbum,UrlImagemAlbum,DescricaoGenero FROM Album JOIN Genero ON FKGeneroAlbum=IdGenero", conn);
                dr = cmd.ExecuteReader();
                List<AlbumListDTO> Lista = new List<AlbumListDTO>();
                while (dr.Read())
                {
                    AlbumListDTO obj = new AlbumListDTO();
                    obj.IdAlbum = Convert.ToInt32(dr["IdAlbum"]);
                    obj.NomeAlbum = dr["NomeAlbum"].ToString();
                    obj.ArtistaAlbum = dr["ArtistaAlbum"].ToString();
                    obj.SeloAlbum = dr["SeloAlbum"].ToString();
                    obj.UrlImagemAlbum = dr["UrlImagemAlbum"].ToString();
                    obj.DescricaoGenero = dr["DescricaoGenero"].ToString();

                    Lista.Add(obj);
                }
                return Lista;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao listar!! " + ex.Message);
            }
            finally
            {
                Desconectar();
            }

        }

        //editar
        public void Editar(AlbumDTO objEdita)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("UPDATE Album SET NomeAlbum=@v1,ArtistaAlbum=@v2,SeloAlbum=@v3,UrlImagemAlbum=@v4,FKGeneroAlbum=@v5 WHERE IdAlbum=@v6", conn);
                cmd.Parameters.AddWithValue("@v1", objEdita.NomeAlbum);
                cmd.Parameters.AddWithValue("@v2", objEdita.ArtistaAlbum);
                cmd.Parameters.AddWithValue("@v3", objEdita.SeloAlbum);
                cmd.Parameters.AddWithValue("@v4", objEdita.UrlImagemAlbum);
                cmd.Parameters.AddWithValue("@v5", objEdita.FKGeneroAlbum);
                cmd.Parameters.AddWithValue("@v6", objEdita.IdAlbum);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao editar o registro!! " + ex.Message);
            }
            finally
            {
                Desconectar();
            }

        }

        //excluir
        public void Excluir(int objExclui)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("DELETE FROM Album WHERE IdAlbum=@v6", conn);
                cmd.Parameters.AddWithValue("@v6", objExclui);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao excluir o registro!! " + ex.Message);
            }
            finally
            {
                Desconectar();
            }

        }

        //filtrar
        public List<AlbumListDTO> Filtrar()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT IdAlbum,NomeAlbum,ArtistaAlbum,SeloAlbum,UrlImagemAlbum,NomeGenero FROM Album JOIN Genero ON FKGeneroAlbum=IdGenero", conn);
                dr = cmd.ExecuteReader();
                List<AlbumListDTO> Lista = new List<AlbumListDTO>();
                while (dr.Read())
                {
                    AlbumListDTO obj = new AlbumListDTO();
                    obj.IdAlbum = Convert.ToInt32(dr["IdAlbum"]);
                    obj.NomeAlbum = dr["NomeAlbum"].ToString();
                    obj.ArtistaAlbum = dr["ArtistaAlbum"].ToString();
                    obj.SeloAlbum = dr["SeloAlbum"].ToString();
                    obj.UrlImagemAlbum = dr["UrlImagemAlbum"].ToString();
                    obj.DescricaoGenero = dr["NomeGenero"].ToString();

                    Lista.Add(obj);
                }
                return Lista;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao listar!! " + ex.Message);
            }
            finally
            {
                Desconectar();
            }

        }

        public List<AlbumListDTO> Filtrar(int idGenero)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT IdAlbum,NomeAlbum,ArtistaAlbum,SeloAlbum,UrlImagemAlbum,NomeGenero FROM Album JOIN Genero ON FKGeneroAlbum=IdGenero WHERE FKGeneroAlbum= " + idGenero, conn);
                dr = cmd.ExecuteReader();
                List<AlbumListDTO> Lista = new List<AlbumListDTO>();
                while (dr.Read())
                {
                    AlbumListDTO obj = new AlbumListDTO();
                    obj.IdAlbum = Convert.ToInt32(dr["IdAlbum"]);
                    obj.NomeAlbum = dr["NomeAlbum"].ToString();
                    obj.ArtistaAlbum = dr["ArtistaAlbum"].ToString();
                    obj.SeloAlbum = dr["SeloAlbum"].ToString();
                    obj.UrlImagemAlbum = dr["UrlImagemAlbum"].ToString();
                    obj.DescricaoGenero = dr["NomeGenero"].ToString();

                    Lista.Add(obj);
                }
                return Lista;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao listar!! " + ex.Message);
            }
            finally
            {
                Desconectar();
            }

        }

        public AlbumListDTO Selecionar(int idAlbum)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT IdAlbum,NomeAlbum,ArtistaAlbum,SeloAlbum,UrlImagemAlbum,NomeGenero FROM Album JOIN Genero ON FKGeneroAlbum=IdGenero WHERE IdAlbum = " + idAlbum, conn);
                dr = cmd.ExecuteReader();

                AlbumListDTO obj = new AlbumListDTO();
                
                if (dr.Read())
                {
                    obj.IdAlbum = Convert.ToInt32(dr["IdAlbum"]);
                    obj.NomeAlbum = dr["NomeAlbum"].ToString();
                    obj.ArtistaAlbum = dr["ArtistaAlbum"].ToString();
                    obj.SeloAlbum = dr["SeloAlbum"].ToString();
                    obj.UrlImagemAlbum = dr["UrlImagemAlbum"].ToString();
                    obj.DescricaoGenero = dr["NomeGenero"].ToString();
                }
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao selecionar!! " + ex.Message);
            }
            finally
            {
                Desconectar();
            }

        }

    }
}
