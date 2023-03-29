using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace CRUD_POO2
{
    class Cliente
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string celular { get; set; }
        public string email { get; set; }
        public string cidade { get; set; }

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Programas\\CRUD_POOTDS09\\DbLoja.mdf;Integrated Security=True");

        public List<Cliente> listacliente()
        {
            List<Cliente> li = new List<Cliente>();
            string sql = "SELECT * FROM Cliente";
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Cliente cli = new Cliente();
                cli.Id = (int)dr["Id"];
                cli.nome = dr["nome"].ToString();
                cli.celular = dr["celular"].ToString();
                cli.email = dr["email"].ToString();
                cli.cidade = dr["cidade"].ToString();
                li.Add(cli);
            }
            return li; 
        }

        public void Inserir(string nome, string celular, string email, string cidade)
        {
            string sql = "INSERT INTO Cliente(nome, celular, email, cidade) VALUES ('" + nome + "','" + celular + "','" + email + "','" + cidade + "')";
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Localiza(int Id)
        {
            string sql = "SELECT * FROM Cliente WHERE Id = '"+Id+"'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                nome = dr["nome"].ToString();
                celular = dr["celular"].ToString();
                email = dr["email"].ToString();
                cidade = dr["cidade"].ToString();
            }
            con.Close();
        }

        public void Atualizar(int Id, string nome, string celular, string email, string cidade)
        {
            string sql = "UPDATE Cliente SET nome='"+nome+"', celular='"+celular+"', email='"+email+"', cidade='"+cidade+"' WHERE Id='"+Id+"'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Excluir(int Id)
        {
            string sql = "DELETE FROM Cliente WHERE Id = '"+Id+"'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
