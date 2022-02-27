using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CRUD_Teste
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }


        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conexao = new MySqlConnection();
                conexao.ConnectionString = DAL.DadosConexao.StringDeConexao;
                conexao.Open();
                conexao.Close();
            }
            catch (MySqlException)
            {
                MessageBox.Show(Ferramentas.Validacao.MensagemErroSQL());
            }
            catch (Exception)
            {
                MessageBox.Show(Ferramentas.Validacao.MensagemErro());
            }
        }


        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            addFuncionario add = new addFuncionario();
            add.ShowDialog();
            add.Dispose();
        }


        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void backupBancoDeDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBackupBancoDeDados backup = new frmBackupBancoDeDados();
            backup.ShowDialog();
            backup.Dispose();
        }
    }
}
