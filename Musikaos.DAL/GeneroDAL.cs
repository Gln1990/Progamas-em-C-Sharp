using Musikaos.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musikaos.DAL
{
    public class GeneroDAL : Conexao
    {
        public List<GeneroDTO> Listar()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM GENERO ORDER BY NomeGenero", conn);
                dr = cmd.ExecuteReader();

                List<GeneroDTO> lista = new List<GeneroDTO>();

                while (dr.Read())
                {
                    lista.Add(new GeneroDTO()
                    {
                        IdGenero = Convert.ToInt32(dr["IdGenero"]),
                        NomeGenero = Convert.ToString(dr["NomeGenero"])
                    });
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar Generos! " + ex.Message);
            }       
            finally
            {
                Desconectar();
            }
        }

        public GeneroDTO Selecionar(int idGenero)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM GENERO WHERE IdGenero = @v1", conn);
                cmd.Parameters.AddWithValue("@v1", idGenero);
                dr = cmd.ExecuteReader();

                GeneroDTO obj = new GeneroDTO();

                if (dr.Read())
                {
                    obj.IdGenero = Convert.ToInt32(dr["IdGenero"]);
                    obj.NomeGenero = Convert.ToString(dr["NomeGenero"]);
                }

                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao selecionar Genero! " + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
    }
}
