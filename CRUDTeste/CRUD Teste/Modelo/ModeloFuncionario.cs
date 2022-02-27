using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Teste.Modelo
{
    class ModeloFuncionario
    {
        #region //Construtores

        public ModeloFuncionario()
        {
            this.FuncCod = 0;
            this.FuncNome = "";
            this.FuncCelular = "";
            this.FuncEmail = "";
            this.FuncEndereco = "";
            this.FuncRg = "";
            this.FuncCpf = "";
        }


        public ModeloFuncionario(int cod,  string nome, string celular, string email, string endereco,
                                 string rg, string cpf)
        {
            this.FuncCod = cod;
            this.FuncNome = nome;
            this.FuncCelular = celular;
            this.FuncEmail = email;
            this.FuncEndereco = endereco;
            this.FuncRg = rg;
            this.FuncCpf = cpf;
        }

        #endregion


        #region //Variaveis

        private int func_cod;
        private string func_nome;
        private string func_celular;
        private string func_email;
        private string func_endereco;
        private string func_rg;
        private string func_cpf;

        #endregion


        public int FuncCod
        {
            get { return func_cod; }
            set { func_cod = value; }
        }
        public string FuncNome
        {
            get { return func_nome; }
            set { func_nome = value; }
        }
        public string FuncCelular
        {
            get { return func_celular; }
            set { func_celular = value; }
        }
        public string FuncEmail
        {
            get { return func_email; }
            set { func_email = value; }
        }
        public string FuncEndereco
        {
            get { return func_endereco; }
            set { func_endereco = value; }
        }
        public string FuncRg
        {
            get { return func_rg; }
            set { func_rg = value; }
        }
        public string FuncCpf
        {
            get { return func_cpf; }
            set { func_cpf = value; }
        }
    }
}
