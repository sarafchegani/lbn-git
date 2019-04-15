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
using System.Data.Common;
using System.Data.Sql;
using System.IO;
using System.Net.Sockets;

namespace SystemTray
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //if the form is minimized
            //hide it from the task bar
            //and show the system tray icon (represented by the NotifyIcon control)
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(1000);
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //notifyIcon.ShowBalloonTip(1000);   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection objConnection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=F:\flexilmt\flexilmt\DATABASE\LMT_BCF.mdf;Integrated Security=True;Connect Timeout=30");
            //  SqlDataReader myReader = objConnection.ExecuteReader();
            string sql = "select * from [dbo].[Table] ORDER BY [bcf],[bts],[trx] ASC ";
            string sql_alm = "select * from [dbo].[Table] WHERE  [ch0_op_state] LIKE '%BL%'  ORDER BY [bcf],[bts],[trx] ASC    ";
            string sql_insert = "INSERT INTO  [dbo].[Table] (bcf,bcf_adm_state,bcf_op_state,bcsu,dch_name,dch_numb) VALUES (@bcf,@bcf_adm_state,@bcf_op_state,@bcsu,@dch_name,@dch_numb)";
            string sql_del = "delete  from [dbo].[Table]  ";
            SqlCommand cmd = new SqlCommand(sql, objConnection);
            SqlCommand cmd_alm = new SqlCommand(sql_alm, objConnection);
            SqlCommand CMD_insert = new SqlCommand(sql_insert, objConnection);
            SqlCommand cmd_del = new SqlCommand(sql_del, objConnection);
            SqlDataAdapter da = new SqlDataAdapter(sql, objConnection);
            SqlDataAdapter da_alm = new SqlDataAdapter(sql_alm, objConnection);
            SqlDataAdapter da_del = new SqlDataAdapter(sql_del, objConnection);
            objConnection.Open();
            //SqlDataReader dr1 = cmd_alm.ExecuteReader();
            //  DataTable dt = new DataTable();
            //   da_alm.Fill(dt);
            //   SqlDataReader dr = cmd.ExecuteReader();
            SqlDataReader dadel = cmd_del.ExecuteReader();
            objConnection.Close();
            objConnection.Open();

            ///    MessageBox.Show("Connection Open  !");


            String path = @"C:\nokia_out\ZEEI_out.txt";

            using (StreamReader sr = File.OpenText(path))
            {
                String s = "";
                string ss = "";
                String m_bcf = "";
                String m_bcf_adm = "";
                String m_bcf_op = "";
                String m_bcsu = "";
                String m_dch_name = "";
                String m_dch_numb = "";
                while ((s = sr.ReadLine()) != null)
                {
                    if (s.Length > 10)
                    {
                        if (s.Substring(0, 3) == "BCF")
                        {
                            ss = s;
                            m_bcf = s.Substring(4, 4);
                            m_bcf_adm = s.Substring(23, 1);
                            m_bcf_op = s.Substring(25, 2);
                            m_bcsu = s.Substring(62, 1);
                            m_dch_name = s.Substring(65, 5);
                            m_dch_numb = s.Substring(71, 2);
                            Console.WriteLine(m_dch_numb);
                            CMD_insert.Parameters.Clear();

                            CMD_insert.Parameters.Add("@bcf", SqlDbType.VarChar);
                            CMD_insert.Parameters["@bcf"].Value = m_bcf;

                            CMD_insert.Parameters.Add("@bcf_adm_state", SqlDbType.VarChar);
                            CMD_insert.Parameters["@bcf_adm_state"].Value = m_bcf_adm;

                            CMD_insert.Parameters.Add("@bcf_op_state", SqlDbType.VarChar);
                            CMD_insert.Parameters["@bcf_op_state"].Value = m_bcf_op;

                            CMD_insert.Parameters.Add("@bcsu", SqlDbType.VarChar);
                            CMD_insert.Parameters["@bcsu"].Value = m_bcsu;

                            CMD_insert.Parameters.Add("@dch_name", SqlDbType.VarChar);
                            CMD_insert.Parameters["@dch_name"].Value = m_dch_name;

                            CMD_insert.Parameters.Add("@dch_numb", SqlDbType.VarChar);
                            CMD_insert.Parameters["@dch_numb"].Value = m_dch_numb;

                            CMD_insert.ExecuteNonQuery();
                        }

                    }
                }
            }

            //  CMD_insert.Parameters.Add("@seg", SqlDbType.VarChar);
            //    CMD_insert.Parameters["@seg"].Value ="2";




            objConnection.Close();




            //  InitializeComponent();

        }
    }
}
