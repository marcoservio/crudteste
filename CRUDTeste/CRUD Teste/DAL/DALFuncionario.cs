using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace CRUD_Teste.DAL
{
    class DALFuncionario
    {
        private DALConexao conexao;


        public DALFuncionario(DALConexao cx)
        {
            this.conexao = cx;
        }


        public void Salvar(Modelo.ModeloFuncionario modelo)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "INSERT INTO funcionario(nome, celular, email, endereco, rg, cpf) VALUES (?nome, ?celular, ?email, ?endereco, ?rg, ?cpf); SELECT @@IDENTITY";
                cmd.Parameters.Add(new MySqlParameter("nome", modelo.FuncNome));
                cmd.Parameters.Add(new MySqlParameter("celular", modelo.FuncCelular));
                cmd.Parameters.Add(new MySqlParameter("email", modelo.FuncEmail));
                cmd.Parameters.Add(new MySqlParameter("endereco", modelo.FuncEndereco));
                cmd.Parameters.Add(new MySqlParameter("rg", modelo.FuncRg));
                cmd.Parameters.Add(new MySqlParameter("cpf", modelo.FuncCpf));

                conexao.Conectar();

                modelo.FuncCod = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void Alterar(Modelo.ModeloFuncionario modelo)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "UPDATE funcionario SET nome = ?nome, celular = ?celular, email = ?email, endereco = ?endereco, rg = ?rg, cpf = ?cpf WHERE codigo = ?codigo;";
                cmd.Parameters.Add(new MySqlParameter("codigo", modelo.FuncCod));
                cmd.Parameters.Add(new MySqlParameter("nome", modelo.FuncNome));
                cmd.Parameters.Add(new MySqlParameter("celular", modelo.FuncCelular));
                cmd.Parameters.Add(new MySqlParameter("email", modelo.FuncEmail));
                cmd.Parameters.Add(new MySqlParameter("endereco", modelo.FuncEndereco));
                cmd.Parameters.Add(new MySqlParameter("rg", modelo.FuncRg));
                cmd.Parameters.Add(new MySqlParameter("cpf", modelo.FuncCpf));

                conexao.Conectar();

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void Excluir(int codigo)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "DELETE FROM funcionario WHERE codigo = ?codigo;";
                cmd.Parameters.Add(new MySqlParameter("codigo", codigo));

                conexao.Conectar();

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public DataTable Localizar(string valor)
        {
            DataTable tabela = new DataTable();

            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM funcionario WHERE nome LIKE '%" + valor + "%'", conexao.StringConexao);

                da.Fill(tabela);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return tabela;
        }


        public DataTable LocalizarTudo()
        {
            DataTable tabela = new DataTable();

            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM funcionario", conexao.StringConexao);

                da.Fill(tabela);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return tabela;
        }
    }
}
