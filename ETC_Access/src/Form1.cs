using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ETC_Access
{
    public partial class Form1 : Form
    {
        DataSet thisDataSet = new DataSet();
        OleDbConnection con = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = \".\\mdb\\EtcAccess.mdb\"");
        int[][] Temp = new int[3][];

        public Form1()
        {
            InitializeComponent();
        }

        private void DataConnect()
        {

            thisDataSet.Reset();

            OleDbDataAdapter thisAdapter1 = new OleDbDataAdapter("Select * From A001 Order by c_ID", con);
            OleDbDataAdapter thisAdapter2 = new OleDbDataAdapter("Select * From A002 Order by c_ID", con);
            OleDbDataAdapter thisAdapter3 = new OleDbDataAdapter("Select * From A003 Order by c_ID", con);

            thisAdapter1.Fill(thisDataSet, "A001");
            thisAdapter2.Fill(thisDataSet, "A002");
            thisAdapter3.Fill(thisDataSet, "A003");

            thisDataSet.Tables["A003"].Columns["c_ID"].AutoIncrement = true;

            DataRelation thisA001toA002 = thisDataSet.Relations.Add("A001toA002",
                thisDataSet.Tables["A001"].Columns["c_ID"],
                thisDataSet.Tables["A002"].Columns["c_A001_ID"]);

            DataRelation thisA002toA003 = thisDataSet.Relations.Add("A002toA003",
                thisDataSet.Tables["A002"].Columns["c_ID"],
                thisDataSet.Tables["A003"].Columns["c_A002_ID"]);

            thisDataSet.Tables.Add("B001");
            thisDataSet.Tables["B001"].Columns.Add("序号");
            thisDataSet.Tables["B001"].Columns.Add("高速级别");
            thisDataSet.Tables["B001"].Columns.Add("高速分类");
            thisDataSet.Tables["B001"].Columns.Add("高速编号");
            thisDataSet.Tables["B001"].Columns.Add("高速名称");

            con.Close();

            DataTable thisDataTable = thisDataSet.Tables["B001"];
            dataGridView1.DataSource = thisDataTable;
        }

        private void SeachNomber(string strString)
        {
            thisDataSet.Tables["B001"].Clear();

            foreach (DataRow x_A001 in thisDataSet.Tables["A001"].Rows)
            {
                foreach (DataRow x_A002 in x_A001.GetChildRows(thisDataSet.Relations["A001toA002"]))
                {
                    foreach (DataRow x_A003 in x_A002.GetChildRows(thisDataSet.Relations["A002toA003"]))
                    {
                        if (strString == "" || x_A003["c_Nomber"].ToString().StartsWith(strString.ToString()))
                        {
                            object[] rowVals = new object[5]
                            {
                                x_A003["c_ID"],
                                x_A001["c_Name"],
                                x_A002["c_Name"],
                                x_A003["c_Nomber"],
                                x_A003["c_Name"]
                            };

                            thisDataSet.Tables["B001"].Rows.Add(rowVals);
                        }
                    }
                }
            }
        }

        private void btnAddRount_Click(object sender, EventArgs e)
        {
            if (txtA003_2.Text != "" && txtA003_3.Text != "")
            {
                string sql = "INSERT into A003 (c_A002_ID,c_Nomber,c_Name) VALUES ('" + Temp[1][comboBox1.SelectedIndex].ToString() + "','" + txtA003_2.Text.ToString() + "','" + txtA003_3.Text.ToString() + "')";
                OleDbCommand cmd = new OleDbCommand(sql, con);
                con.Open();
                int aaa = cmd.ExecuteNonQuery();
                con.Close();

                DataConnect();
                SeachNomber("");

                txtA003_2.Text = "";
                txtA003_3.Text = "";
                MessageBox.Show("添加成功");
            }
            else
            {
                MessageBox.Show("无数据");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataConnect();
            SeachNomber("");

            object[] strTemp = new object[thisDataSet.Tables["A002"].Rows.Count];
            Temp[1] = new int[thisDataSet.Tables["A002"].Rows.Count];
            int t = 0;
            foreach (DataRow x_A002 in thisDataSet.Tables["A002"].Rows)
            {
                strTemp[t] = x_A002[2];
                Temp[1][t] = (int)x_A002[0];
                t++;
            }
            comboBox1.DataSource = strTemp;
        }
    }
}
