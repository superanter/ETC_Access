﻿using System;
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
            OleDbDataAdapter thisAdapter4 = new OleDbDataAdapter("Select * From A004 Order by c_ID", con);
            OleDbDataAdapter thisAdapter5 = new OleDbDataAdapter("Select * From A005 Order by c_ID", con);
            OleDbDataAdapter thisAdapter6 = new OleDbDataAdapter("Select * From A006 Order by c_ID", con);
            OleDbDataAdapter thisAdapter7 = new OleDbDataAdapter("Select * From A007 Order by c_ID", con);
            string temp1 = "Select A007.c_ID as 序号,";
            temp1 += "A007.c_Name as 名称,";
            temp1 += "FORMAT(A007.c_Lng/100,'000°00′00.00″') as 精度,";
            temp1 += "FORMAT(A007.c_Lat/100,'00°00′00.00″') as 纬度,";
            temp1 += "A007.c_Text as 备注,";
            temp1 += "A003.c_Name as 高速,";
            temp1 += "A004.c_Name as 已核对,";
            temp1 += "A005.c_Name as 出口标记类型,";
            temp1 += "A006.c_Name as 省份";
            temp1 += " From A003,A004,A005,A006,A007";
            temp1 += " Where A003.c_ID = A007.c_A003_ID";
            temp1 += " and A004.c_ID = A007.c_A004_ID";
            temp1 += " and A005.c_ID = A007.c_A005_ID";
            temp1 += " and A006.c_ID = A007.c_A006_ID";
            temp1 += " Order by A007.c_ID";
            OleDbDataAdapter thisAdapterB2 = new OleDbDataAdapter(temp1, con);

            thisAdapter1.Fill(thisDataSet, "A001");
            thisAdapter2.Fill(thisDataSet, "A002");
            thisAdapter3.Fill(thisDataSet, "A003");
            thisAdapter4.Fill(thisDataSet, "A004");
            thisAdapter5.Fill(thisDataSet, "A005");
            thisAdapter6.Fill(thisDataSet, "A006");
            thisAdapter7.Fill(thisDataSet, "A007");
            thisAdapterB2.Fill(thisDataSet, "B002");

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

            thisDataSet.Tables["A007"].Columns["c_ID"].AutoIncrement = true;

            DataRelation thisA004toA007 = thisDataSet.Relations.Add("A004toA007",
                thisDataSet.Tables["A004"].Columns["c_ID"],
                thisDataSet.Tables["A007"].Columns["c_A004_ID"]);

            DataRelation thisA0054toA007 = thisDataSet.Relations.Add("A005toA007",
                thisDataSet.Tables["A005"].Columns["c_ID"],
                thisDataSet.Tables["A007"].Columns["c_A005_ID"]);

            DataRelation thisA006toA007 = thisDataSet.Relations.Add("A006toA007",
                thisDataSet.Tables["A006"].Columns["c_ID"],
                thisDataSet.Tables["A007"].Columns["c_A006_ID"]);

            DataRelation thisA003toA007 = thisDataSet.Relations.Add("A003toA007",
             thisDataSet.Tables["A003"].Columns["c_ID"],
                thisDataSet.Tables["A007"].Columns["c_A003_ID"]);
            /*
            thisDataSet.Tables.Add("B002");
            thisDataSet.Tables["B002"].Columns.Add("序号");
            thisDataSet.Tables["B002"].Columns.Add("名称");
            thisDataSet.Tables["B002"].Columns.Add("经度");
            thisDataSet.Tables["B002"].Columns.Add("纬度");
            thisDataSet.Tables["B002"].Columns.Add("备注");
            thisDataSet.Tables["B002"].Columns.Add("高速公路");
            thisDataSet.Tables["B002"].Columns.Add("名称核对");
            thisDataSet.Tables["B002"].Columns.Add("出入口标识类型");
            thisDataSet.Tables["B002"].Columns.Add("省份");
            */
            con.Close();

            DataTable thisDataTable1 = thisDataSet.Tables["B001"];
            dataGridView1.DataSource = thisDataTable1;
            dataGridView1.Columns[0].Width = 55;
            dataGridView1.Columns[1].Width = 80;
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 125;


            DataTable thisDataTable2 = thisDataSet.Tables["B002"];
            dataGridView2.DataSource = thisDataTable2;
            dataGridView2.Columns[0].Width = 55;
            dataGridView2.Columns[1].Width = 80;
            dataGridView2.Columns[2].Width = 110;
            dataGridView2.Columns[3].Width = 100;
            dataGridView2.Columns[4].Width = 110;
            dataGridView2.Columns[5].Width = 120;
            dataGridView2.Columns[6].Width = 80;
            dataGridView2.Columns[7].Width = 110;
            dataGridView2.Columns[8].Width = 70;
        }

        private void SeachNomberB001(string strString)
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

        private void SeachNomberB002(string strString)
        {
            
            thisDataSet.Tables["B002"].Clear();

            foreach (DataRow x_B002 in thisDataSet.Tables["B002"].Rows)
            {
               if (strString == "" || x_B002["c_Name"].ToString().StartsWith(strString.ToString()))
                {
                    object[] rowVals = new object[2]
                    {
                                x_B002["c_ID"],
                                x_B002["c_Name"]
                                /*
                                x_B002["c_Lng"].ToString().Insert(9,"\"").Insert(7,".").Insert(5,"\'").Insert(3,"°"),
                                x_B002["c_Lat"].ToString().Insert(8,"\"").Insert(6,".").Insert(4,"\'").Insert(2,"°"),
                                x_A007["c_Text"],
                                x_A003["c_Name"],
                                x_A007["c_A004_ID"],
                                x_A007["c_A005_ID"],
                                x_A007["c_A006_ID"]
                                */
                    };

                    thisDataSet.Tables["B002"].Rows.Add(rowVals);
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
                SeachNomberB001("");

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
            SeachNomberB001("");
            //SeachNomberB002("");

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SeachNomberB001(textBox1.Text.ToString());
        }
    }
}
