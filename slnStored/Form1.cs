using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace slnStored
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {  try
            {
                string str = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\Programas\\aulaStoredProcedures\\slnStored\\slnStored\\BDAlunos.mdf;Integrated Security=True;Connect Timeout=30";
                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Procurar";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", this.txtID.Text);
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    txtID.Text = rd["id"].ToString();
                    txtNome.Text = rd["nome"].ToString();
                    txtIdade.Text = rd["idade"].ToString();
                }
                else
                {
                    MessageBox.Show("Registro não encontrado");
                }
           }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\Programas\\aulaStoredProcedures\\slnStored\\slnStored\\BDAlunos.mdf;Integrated Security=True;Connect Timeout=30";
                string query = "select * from Aluno ";
                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                DataSet ds = new DataSet();
                MessageBox.Show("Conectado com Sucesso!");
                con.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\Programas\\aulaStoredProcedures\\slnStored\\slnStored\\BDAlunos.mdf;Integrated Security=True;Connect Timeout=30";
                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Inserir";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@idade", txtIdade.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Registro atualizado com sucesso!");
                con.Close();
                txtNome.Text = null;
                txtIdade.Text = null;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\Programas\\aulaStoredProcedures\\slnStored\\slnStored\\BDAlunos.mdf;Integrated Security=True;Connect Timeout=30";
                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Editar";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", this.txtID.Text);
                cmd.Parameters.AddWithValue("@nome", this.txtNome.Text);
                cmd.Parameters.AddWithValue("@idade", this.txtIdade.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Registro atualizado com sucesso!");
                con.Close();
                txtNome.Text = null;
                txtIdade.Text = null;
                txtID.Text = null;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\Programas\\aulaStoredProcedures\\slnStored\\slnStored\\BDAlunos.mdf;Integrated Security=True;Connect Timeout=30";
                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Excluir";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", this.txtID.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Registro excluido com sucesso!");
                con.Close();
                txtNome.Text = null;
                txtIdade.Text = null;
                txtID.Text = null;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
    }
}
