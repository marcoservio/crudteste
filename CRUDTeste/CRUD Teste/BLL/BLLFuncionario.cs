using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CRUD_Teste.BLL
{
    class BLLFuncionario
    {
        private DAL.DALConexao conexao;


        public BLLFuncionario(DAL.DALConexao cx)
        {
            this.conexao = cx;
        }


        public void Salvar(Modelo.ModeloFuncionario modelo)
        {
            try
            {
                if (modelo.FuncNome.Trim().Length == 0)
                {
                    throw new Exception("O nome do funcionario deve ser informado!");
                }
                if(modelo.FuncCpf.Trim().Length == 0)
                {
                    throw new Exception("O CPF do funcionario deve ser informado!");
                }
                if(Ferramentas.Validacao.IsCpf(modelo.FuncCpf) == false)
                {
                    throw new Exception("CPF inválido!");
                }
                if(modelo.FuncRg.Trim().Length == 0)
                {
                    throw new Exception("O RG do funcionario deve ser informado!");
                }
                if(modelo.FuncCelular.Trim().Length == 0)
                {
                    throw new Exception("O telefone do funcionario deve ser informado!");
                }
                if(Ferramentas.Validacao.ValidaEmail(modelo.FuncEmail) == false)
                {
                    throw new Exception("E-mail inválido!");
                }

                DAL.DALFuncionario dalObj = new DAL.DALFuncionario(conexao);

                dalObj.Salvar(modelo);
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
                if(modelo.FuncNome.Trim().Length == 0)
                {
                    throw new Exception("O nome do funcionario deve ser informado!");
                }
                if(modelo.FuncCpf.Trim().Length == 0)
                {
                    throw new Exception("O CPF do funcionario deve ser informado!");
                }
                if(Ferramentas.Validacao.IsCpf(modelo.FuncCpf) == false)
                {
                    throw new Exception("CPF inválido!");
                }
                if(modelo.FuncRg.Trim().Length == 0)
                {
                    throw new Exception("O RG do funcionario deve ser informado!");
                }
                if(Ferramentas.Validacao.ValidaEmail(modelo.FuncEmail) == false)
                {
                    throw new Exception("E-mail inválido!");
                }

                DAL.DALFuncionario dalObj = new DAL.DALFuncionario(conexao);

                dalObj.Alterar(modelo);
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
                if (codigo <= 0)
                {
                    throw new Exception("O codigo deve ser informado!");
                }

                DAL.DALFuncionario dalObj = new DAL.DALFuncionario(conexao);

                dalObj.Excluir(codigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public DataTable Localizar(string valor)
        {
            try
            {
                if (valor == "")
                {
                    throw new Exception("O nome deve ser informado!");
                }

                DAL.DALFuncionario dalObj = new DAL.DALFuncionario(conexao);

                return dalObj.Localizar(valor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public DataTable LocalizarTudo()
        {
            try
            {
                DAL.DALFuncionario dalObj = new DAL.DALFuncionario(conexao);

                return dalObj.LocalizarTudo();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
