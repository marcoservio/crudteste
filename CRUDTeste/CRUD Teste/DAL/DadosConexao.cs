using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Teste.DAL
{
    class DadosConexao
    {
        public static string servidor = "127.0.0.1";
        public static string banco = "crud";
        public static string usuario = "root";
        public static string senha = "";

        //static public string strConn = "server=" + servidor + "; User Id=" + usuario + "; database=" + bancoDados + "; password=" + senha;

        //static public string strConn = $"server{servidor};User Id={usuario};database={bancoDados};password={senha}";

        public static string StringDeConexao
        {
            get { return "SERVER=" + servidor + ";DATABASE=" + banco + ";UID=" + usuario + ";PASSWORD=" + senha + ";"; }
        }
    }
}
