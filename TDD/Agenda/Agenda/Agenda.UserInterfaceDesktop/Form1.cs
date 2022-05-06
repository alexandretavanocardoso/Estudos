using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Agenda.UserInterfaceDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtContatoNovo.Text;

            string conexao = @"Data Source=.\SQLEXPRESS; Initial Catalog=Agenda; Integrated Security= True";
            string id = Guid.NewGuid().ToString();

            SqlConnection con = new SqlConnection(conexao);
            con.Open();

            string sql = String.Format("INSERT INTO CONTATO(ID, NOME) VALUES('{0}', '{1}');", id, nome);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            sql = String.Format("SELECT NOME FROM CONTATO WHERE ID='{0}'", id);
            cmd = new SqlCommand(sql, con);
            txtContatoSalvo.Text = cmd.ExecuteScalar().ToString();

            con.Close();
        }
    }
}
