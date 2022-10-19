using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Musikaos.DTO;

namespace Musikaos.DAL
{
    public class UsuarioDAL : Conexao
    {
        //inserir
        public void Cadastrar(UsuarioDTO objCad)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("INSERT INTO Usuario (NomeUsuario,SenhaUsuario,EmailUsuario,FKTpUsuario) VALUES (@v1,@v2,@v3,@v4)", conn);
                cmd.Parameters.AddWithValue("@v1", objCad.NomeUsuario);
                cmd.Parameters.AddWithValue("@v2", objCad.SenhaUsuario);
                cmd.Parameters.AddWithValue("@v3", objCad.EmailUsuario);
                cmd.Parameters.AddWithValue("@v4", objCad.FKTpUsuario);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Cadastrar !! " + ex.Message);
            }
            finally
            {
                Desconectar();
            }

        }

        //listar
        public List<UsuarioListDTO> Listar()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT IdUsuario, NomeUsuario, SenhaUsuario, EmailUsuario,DescricaoTpUsuario FROM Usuario JOIN TpUsuario ON FKTpUsuario=IdTpUsuario", conn);
                dr = cmd.ExecuteReader();
                List<UsuarioListDTO> Lista = new List<UsuarioListDTO>();//criando lista vazia

                while (dr.Read())
                {
                    UsuarioListDTO obj = new UsuarioListDTO();
                    obj.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                    obj.NomeUsuario = dr["NomeUsuario"].ToString();
                    obj.SenhaUsuario = dr["SenhaUsuario"].ToString();
                    obj.EmailUsuario = dr["EmailUsuario"].ToString();
                    obj.DescricaoTpUsuario = dr["DescricaoTpUsuario"].ToString();
                   
                    Lista.Add(obj);
                }
                return Lista;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Listar !! " + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //update
        public void Editar(UsuarioDTO objEdita)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("UPDATE Usuario SET NomeUsuario=@v1,SenhaUsuario=@v2,EmailUsuario=@v3,FKTpUsuario=@v4 WHERE IdUsuario=@v5", conn);
                cmd.Parameters.AddWithValue("@v1", objEdita.NomeUsuario);
                cmd.Parameters.AddWithValue("@v2", objEdita.SenhaUsuario);
                cmd.Parameters.AddWithValue("@v3", objEdita.EmailUsuario);
                cmd.Parameters.AddWithValue("@v4", objEdita.FKTpUsuario);
                cmd.Parameters.AddWithValue("@v5", objEdita.IdUsuario);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Editar !! " + ex.Message);
            }
            finally
            {
                Desconectar();
            }

        }

        //delete
        public void Excluir(int objExclui)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("DELETE FROM Usuario WHERE IdUsuario=@v5", conn);
                cmd.Parameters.AddWithValue("@v5", objExclui);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Excluir !! " + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //autenticaUser
        public UsuarioAutenticaDTO Autenticar(string objNome, string objSenha)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT NomeUsuario, SenhaUsuario, FKTpUsuario FROM Usuario WHERE NomeUsuario=@v1 AND SenhaUSuario=@v2", conn);
                cmd.Parameters.AddWithValue("@v1", objNome);
                cmd.Parameters.AddWithValue("@v2", objSenha);
                dr = cmd.ExecuteReader();

                UsuarioAutenticaDTO obj = null;
                if (dr.Read())
                {
                    obj = new UsuarioAutenticaDTO();
                    obj.NomeUsuario = dr["NomeUsuario"].ToString();
                    obj.SenhaUsuario = dr["SenhaUsuario"].ToString();
                    obj.FKTpUsuario = dr["FKTpUsuario"].ToString();
                }
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception("Usuário não cadastrado !! " + ex.Message);
            }
            finally
            {
                Desconectar();
            }

        }
    }
}
