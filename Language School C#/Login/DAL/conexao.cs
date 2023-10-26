using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login.DAL
{
    public class conexao
    {
        SqlConnection con = new SqlConnection();
            public conexao()
        {
            con.ConnectionString = @"Server=tcp:bd-pim.database.windows.net,1433;Initial Catalog=Language_school_pim;Persist Security Info=False;User ID=Guilherme;Password=13042002.Gui;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            
        }

        public SqlConnection conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed) 
            {
                con.Open();
            }
            return con;
        }

        public void desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }

        }
    }

}
