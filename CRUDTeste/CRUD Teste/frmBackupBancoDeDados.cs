using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CRUD_Teste.DAL;

using Ferramentas;

namespace CRUD_Teste
{
    public partial class frmBackupBancoDeDados : Form
    {
        public frmBackupBancoDeDados()
        {
            InitializeComponent();
        }


        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog d = new SaveFileDialog();
                d.Filter = "Backup Files|*.bak";
                d.ShowDialog();

                if (d.FileName != "")
                {
                    string nomeBanco = DAL.DadosConexao.banco;
                    string conexao = "SERVER=" + DAL.DadosConexao.servidor + ";DATABASE=" + DAL.DadosConexao.banco + ";UID=" + DAL.DadosConexao.usuario + ";PASSWORD=" + DAL.DadosConexao.senha + ";";

                    Ferramentas.MySqlBackupBancoDados.BackupDataBase(conexao, d.FileName);

                    MessageBox.Show("Backup realizado com sucesso!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Ferramentas.Validacao.MensagemErro());
            }
        }


        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog d = new OpenFileDialog();
                d.Filter = "Backup Files|*.bak";
                d.ShowDialog();
                if (d.FileName != "")
                {
                    string nomeBanco = DAL.DadosConexao.banco;
                    string conexao = "SERVER=" + DAL.DadosConexao.servidor + ";DATABASE=" + DAL.DadosConexao.banco + ";UID=" + DAL.DadosConexao.usuario + ";PASSWORD=" + DAL.DadosConexao.senha + ";";
                    MySqlBackupBancoDados.RestauraDatabase(conexao, d.FileName);
                    MessageBox.Show("Backup restaurado com sucesso!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Validacao.MensagemErro());
            }
        }
    }
}
