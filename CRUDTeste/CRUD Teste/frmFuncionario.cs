using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CRUD_Teste
{
    public partial class addFuncionario : Form
    {
        #region //Variaveis

        public string operacao;

        #endregion


        public void AlteraTxt(int op)
        {
            txtCodigo.Enabled = false;
            txtNome.Enabled = false;
            txtCelular.Enabled = false;
            txtEmail.Enabled = false;
            txtEndereco.Enabled = false;
            txtRg.Enabled = false;
            txtCpf.Enabled = false;
            txtPesquisaNome.Enabled = false;

            lblValorIncorreto.Visible = false;
            lblEmailIncorreto.Visible = false;

            dtgFuncionario.ReadOnly = true;

            switch(op)
            {

                case 1:
                    {
                        txtPesquisaNome.Enabled = true;

                        break;
                    }
                case 2:
                    {
                        txtNome.Enabled = true;
                        txtCelular.Enabled = true;
                        txtEmail.Enabled = true;
                        txtEndereco.Enabled = true;
                        txtRg.Enabled = true;
                        txtCpf.Enabled = true;

                        dtgFuncionario.ReadOnly = false;

                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }


        public void AlteraBotoes(int op)
        {
            // op = Operações que são feitas com os botões.
            // 1 = Preparar para inserir e localizar.
            // 2 = Preparar para inserir/alterar um registro.
            // 3 = Preparar para excluir ou alterar.

            try
            {
                btnInserir.Enabled = false;
                btnPesquisar.Enabled = false;
                btnAlterar.Enabled = false;
                btnSalvar.Enabled = false;
                btnExcluir.Enabled = false;
                btnCancelar.Enabled = false;

                lblValorIncorreto.Visible = false;
                lblEmailIncorreto.Visible = false;

                switch(op)
                {
                    case 1:
                        {
                            btnInserir.Enabled = true;
                            btnPesquisar.Enabled = true;

                            break;
                        }
                    case 2:
                        {
                            btnSalvar.Enabled = true;
                            btnCancelar.Enabled = true;

                            dtgFuncionario.ReadOnly = false;

                            break;
                        }
                    case 3:
                        {
                            btnSalvar.Enabled = true;
                            btnAlterar.Enabled = true;
                            btnExcluir.Enabled = true;
                            btnCancelar.Enabled = true;

                            break;
                        }
                    case 4:
                        {
                            btnAlterar.Enabled = true;
                            btnCancelar.Enabled = true;

                            break;
                        }
                    case 5:
                        {
                            btnAlterar.Enabled = true;
                            btnExcluir.Enabled = true;
                            btnCancelar.Enabled = true;

                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            catch(Exception)
            {
                MessageBox.Show(Ferramentas.Validacao.MensagemErro());
            }
        }


        public void LayoutDataGrid()
        {
            dtgFuncionario.Columns[0].HeaderText = "Código";
            dtgFuncionario.Columns[0].Width = 50;
            dtgFuncionario.Columns[1].HeaderText = "Nome";
            dtgFuncionario.Columns[1].Width = 250;
            dtgFuncionario.Columns[2].HeaderText = "Celular";
            dtgFuncionario.Columns[2].Width = 100;
            dtgFuncionario.Columns[3].HeaderText = "E-mail";
            dtgFuncionario.Columns[3].Width = 200;
            dtgFuncionario.Columns[4].HeaderText = "Endereço";
            dtgFuncionario.Columns[4].Width = 300;
            dtgFuncionario.Columns[5].HeaderText = "RG";
            dtgFuncionario.Columns[5].Width = 70;
            dtgFuncionario.Columns[6].HeaderText = "CPF";
            dtgFuncionario.Columns[6].Width = 90;
        }


        public void PreencherGrid()
        {

        }


        public enum Campo
        {
            CPF = 1,
            CELULAR = 2,
            RG = 3,
        }


        public addFuncionario()
        {
            InitializeComponent();

            this.AlteraBotoes(1);

            this.AlteraTxt(2);
        }


        public void Formatar(Campo valor, TextBox txtTexto)
        {
            try
            {
                switch(valor)
                {
                    case Campo.CPF:
                        {
                            txtTexto.MaxLength = 14;

                            if(txtTexto.Text.Length == 3)
                            {
                                txtTexto.Text = txtTexto.Text + ".";
                                txtTexto.SelectionStart = txtTexto.Text.Length + 1;
                            }
                            else if(txtTexto.Text.Length == 7)
                            {
                                txtTexto.Text = txtTexto.Text + ".";
                                txtTexto.SelectionStart = txtTexto.Text.Length + 1;
                            }
                            else if(txtTexto.Text.Length == 11)
                            {
                                txtTexto.Text = txtTexto.Text + "-";
                                txtTexto.SelectionStart = txtTexto.Text.Length + 1;
                            }

                            break;
                        }
                    case Campo.CELULAR:
                        {
                            txtTexto.MaxLength = 14;

                            if(txtTexto.Text.Length == 0)
                            {
                                txtTexto.Text = txtTexto.Text + "(";
                                txtTexto.SelectionStart = txtTexto.Text.Length + 1;
                            }
                            if(txtTexto.Text.Length == 3)
                            {
                                txtTexto.Text = txtTexto.Text + ")";
                                txtTexto.SelectionStart = txtTexto.Text.Length + 1;
                            }
                            if(txtTexto.Text.Length == 9)
                            {
                                txtTexto.Text = txtTexto.Text + "-";
                                txtTexto.SelectionStart = txtTexto.Text.Length + 1;
                            }

                            break;
                        }
                    case Campo.RG:
                        {
                            txtTexto.MaxLength = 10;

                            if(txtTexto.Text.Length == 2)
                            {
                                txtTexto.Text = txtTexto.Text + ".";
                                txtTexto.SelectionStart = txtTexto.Text.Length + 1;
                            }
                            else if(txtTexto.Text.Length == 6)
                            {
                                txtTexto.Text = txtTexto.Text + ".";
                                txtTexto.SelectionStart = txtTexto.Text.Length + 1;
                            }

                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void LimpaTela()
        {
            txtCodigo.Clear();
            txtPesquisaNome.Clear();
            txtNome.Clear();
            txtCelular.Clear();
            txtEmail.Clear();
            txtEndereco.Clear();
            txtRg.Clear();
            txtCpf.Clear();

            dtgFuncionario.DataSource = null;
            dtgFuncionario.Refresh();
        }


        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if(lblEmailIncorreto.Visible == false || lblValorIncorreto.Visible == false)
                {


                    Modelo.ModeloFuncionario modelo = new Modelo.ModeloFuncionario();

                    modelo.FuncNome = txtNome.Text;
                    modelo.FuncCelular = txtCelular.Text;
                    modelo.FuncEmail = txtEmail.Text;
                    modelo.FuncEndereco = txtEndereco.Text;
                    modelo.FuncRg = txtRg.Text;
                    modelo.FuncCpf = txtCpf.Text;

                    DAL.DALConexao conexao = new DAL.DALConexao(DAL.DadosConexao.StringDeConexao);
                    BLL.BLLFuncionario bll = new BLL.BLLFuncionario(conexao);

                    if(this.operacao.Equals("inserir"))
                    {
                        bll.Salvar(modelo);

                        MessageBox.Show("Cadastro efetuado com sucesso!");
                    }
                    else
                    {
                        modelo.FuncCod = Convert.ToInt32(txtCodigo.Text);

                        bll.Alterar(modelo);

                        MessageBox.Show("Cadastro alterado com sucesso!");
                    }

                    this.LimpaTela();
                    this.AlteraBotoes(1);
                    this.AlteraTxt(1);
                    addFuncionario_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Erro ao Salvar! Verificar os campos com observações");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
                //MessageBox.Show(Ferramentas.Validacao.MensagemErro());
            }
        }


        private void btnInserir_Click(object sender, EventArgs e)
        {
            this.operacao = "inserir";
            this.AlteraBotoes(2);
            this.AlteraTxt(2);
        }


        private void btnAlterar_Click(object sender, EventArgs e)
        {
            this.operacao = "alterar";
            btnSalvar_Click(sender, e);
        }


        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("Deseja excluir o registro?", "Aviso", MessageBoxButtons.YesNo);

                if(d.ToString() == "Yes")
                {
                    DAL.DALConexao conexao = new DAL.DALConexao(DAL.DadosConexao.StringDeConexao);
                    BLL.BLLFuncionario bll = new BLL.BLLFuncionario(conexao);

                    bll.Excluir(Convert.ToInt32(txtCodigo.Text));

                    MessageBox.Show("Exclusão efetuada com sucesso!");

                    this.LimpaTela();
                    this.AlteraBotoes(1);
                    this.AlteraTxt(1);
                    addFuncionario_Load(sender, e);
                }
            }
            catch(Exception)
            {
                this.AlteraBotoes(3);
                MessageBox.Show(Ferramentas.Validacao.MensagemErro());
            }
        }


        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                DAL.DALConexao conexao = new DAL.DALConexao(DAL.DadosConexao.StringDeConexao);
                BLL.BLLFuncionario bll = new BLL.BLLFuncionario(conexao);

                dtgFuncionario.DataSource = bll.Localizar(txtPesquisaNome.Text);

                LayoutDataGrid();

                dtgFuncionario.ReadOnly = false;
            }
            catch(Exception)
            {
                MessageBox.Show(Ferramentas.Validacao.MensagemErro());
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.AlteraTxt(1);
            this.LimpaTela();
            this.AlteraBotoes(1);
            addFuncionario_Load(sender, e);
        }


        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if(e.KeyChar != (char) 8)
                {
                    Campo edit = Campo.CELULAR;

                    Formatar(edit, txtCelular);
                }
            }
            catch(Exception)
            {
                MessageBox.Show(Ferramentas.Validacao.MensagemErro());
            }
        }


        private void txtRg_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if(e.KeyChar != (char) 8)
                {
                    Campo edit = Campo.RG;

                    Formatar(edit, txtRg);
                }
            }
            catch(Exception)
            {
                MessageBox.Show(Ferramentas.Validacao.MensagemErro());
            }
        }


        private void txtCpf_Leave(object sender, EventArgs e)
        {
            try
            {
                lblValorIncorreto.Visible = false;

                if(Ferramentas.Validacao.IsCpf(txtCpf.Text) == false)
                {
                    lblValorIncorreto.Visible = true;
                }
            }
            catch(Exception)
            {
                MessageBox.Show(Ferramentas.Validacao.MensagemErro());
            }
        }


        private void txtEmail_Leave(object sender, EventArgs e)
        {
            try
            {
                string email = txtEmail.Text;

                lblEmailIncorreto.Visible = false;

                if(!Ferramentas.Validacao.ValidaEmail(email))
                {
                    lblEmailIncorreto.Visible = true;
                }
            }
            catch(Exception)
            {
                MessageBox.Show(Ferramentas.Validacao.MensagemErro());
            }
        }


        private void txtCpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if(e.KeyChar != (char) 8)
                {
                    Campo edit = Campo.CPF;

                    Formatar(edit, txtCpf);
                }
            }
            catch(Exception)
            {
                MessageBox.Show(Ferramentas.Validacao.MensagemErro());
            }
        }


        private void dtgFuncionario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(dtgFuncionario.ReadOnly == true)
                {
                    AlteraBotoes(1);
                }
                else
                {
                    if(e.RowIndex >= 0)
                    {
                        txtCodigo.Text = dtgFuncionario.Rows[e.RowIndex].Cells[0].Value.ToString();
                        txtNome.Text = dtgFuncionario.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtCelular.Text = dtgFuncionario.Rows[e.RowIndex].Cells[2].Value.ToString();
                        txtEmail.Text = dtgFuncionario.Rows[e.RowIndex].Cells[3].Value.ToString();
                        txtEndereco.Text = dtgFuncionario.Rows[e.RowIndex].Cells[4].Value.ToString();
                        txtRg.Text = dtgFuncionario.Rows[e.RowIndex].Cells[5].Value.ToString();
                        txtCpf.Text = dtgFuncionario.Rows[e.RowIndex].Cells[6].Value.ToString();

                        AlteraBotoes(5);
                        AlteraTxt(2);
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show(Ferramentas.Validacao.MensagemErro());
            }
        }


        private void addFuncionario_Load(object sender, EventArgs e)
        {
            try
            {
                DAL.DALConexao conexao = new DAL.DALConexao(DAL.DadosConexao.StringDeConexao);
                BLL.BLLFuncionario bll = new BLL.BLLFuncionario(conexao);

                dtgFuncionario.DataSource = bll.LocalizarTudo();

                LayoutDataGrid();

                AlteraTxt(1);
                AlteraBotoes(1);
            }
            catch(Exception)
            {
                MessageBox.Show(Ferramentas.Validacao.MensagemErro());
            }
        }
    }
}
