
/// Name:Hanan Avraham  Id:062844881

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
using System.Data.SqlClient;

namespace DB_FinalProject
{
    public partial class Form1 : Form
    {
        public string connString = "Server=localhost;Port=3306;Database=db_project;Uid=root;password=1307;";
        MySqlCommand command;
        public Form1()
        {
            MySqlConnection conn = sqlCommandsManager.createConnection();
            InitializeComponent();
         
            command = conn.CreateCommand();
            sqlCommandsManager.createDBdata();
            sqlCommandsManager.createTriggers();
            command = new MySqlCommand("select * from engineer", conn);
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            dataGridView1.DataSource = dt;
            sqlCommandsManager.closeConnection();        //closing connection
        }

          private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = sqlCommandsManager.createConnection();
                command = new MySqlCommand("SELECT id,name FROM software_area", conn);
                DataTable dt = new DataTable();
                dt.Load(command.ExecuteReader());
                comboBox1.DataSource = dt.DefaultView;
                comboBox1.DisplayMember = "name";
                comboBox1.ValueMember = "id";
                comboBox1.SelectedIndex = -1;
            }
            catch { } 
        }

        public void clearText(GroupBox g)
        {
            foreach (Control c in g.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }
        }

        public void refreshDataGridView(string tabType)
        {
            switch (tabType) 
            {
                case "engineer":
                    command = new MySqlCommand("select * from engineer", sqlCommandsManager.conn);
                    showTable(dataGridView2, command);
                    break;
                case "project":
                    command = new MySqlCommand("select * from project", sqlCommandsManager.conn);
                    showTable(dataGridView1, command);
                    break;
                case "software":
                    command = new MySqlCommand("select * from software_area", sqlCommandsManager.conn);
                    showTable(dataGridView3, command);
                    break;
            }
        }

        public void showTable(DataGridView grid, MySqlCommand command)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(command.ExecuteReader());
                grid.DataSource = dt;
                grid.Visible = true;
            }
            catch { }
            
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[0].Value = "remove";
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGridView2.Rows[e.RowIndex].Cells[0].Value = "remove";
        }

        private void dataGridView3_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGridView3.Rows[e.RowIndex].Cells[0].Value = "remove";
        }

 
        private void tabControl1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            int a = tabControl1.SelectedIndex;
            switch (a)
            {
                case 0:
                    command = new MySqlCommand("select * from engineer", sqlCommandsManager.conn);            
                    dt.Load(command.ExecuteReader());
                    dataGridView2.DataSource = dt;
                    break;

                case 1:
                    command = new MySqlCommand("select * from project", sqlCommandsManager.conn);
                    dt.Load(command.ExecuteReader());
                    dataGridView1.DataSource = dt;
                    break;

                case 2:
                    command = new MySqlCommand("select * from software_area", sqlCommandsManager.conn);
                    dt.Load(command.ExecuteReader());
                    dataGridView3.DataSource = dt;
                    break;
            }  
            
        }

        //project table
        private void tabControl2_Click(object sender, EventArgs e)
        {
            command = new MySqlCommand("select * from project", sqlCommandsManager.conn);
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            dataGridView2.DataSource = dt;
        }

        //remove project
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            string id = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            sqlCommandsManager.removeData("project", id);
            refreshDataGridView("project");
        }

        //remove engineer
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataGridView2.Rows[rowIndex];
            string id = dataGridView2.Rows[rowIndex].Cells[1].Value.ToString();
            sqlCommandsManager.removeData("engineer", id);
            refreshDataGridView("engineer");
        }

        //remove Software area
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataGridView3.Rows[rowIndex];
            string id = dataGridView3.Rows[rowIndex].Cells[1].Value.ToString();
            sqlCommandsManager.removeData("software_area", id);
            refreshDataGridView("software");
        }

        //add Engineer
        private void button1_Click_1(object sender, EventArgs e)
        {
            sqlCommandsManager.insertData($"Engineer values('{id.Text}', '{first_name.Text}', '{last_name.Text}', '{address.Text}','{date.Text}','{age.Text}')");
            sqlCommandsManager.insertData($"Belongs values ('{id.Text}','{comboBox1.SelectedValue}')");
            clearText(groupBox2);
            comboBox1.SelectedIndex = -1;
            refreshDataGridView("engineer");          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            command = new MySqlCommand("select * from software_area", sqlCommandsManager.conn);
            dt.Load(command.ExecuteReader());    
        }

        //add project
        private void button3_Click(object sender, EventArgs e)
        {
            sqlCommandsManager.insertData($"Project values('{project_id.Text}', '{name.Text}', '{costumer.Text}', '{start_date.Text}','{description.Text}')");
            clearText(groupBox3);
            refreshDataGridView("project");
        }

        //add software_area
        private void button2_Click(object sender, EventArgs e)
        {
            sqlCommandsManager.insertData($"Software_Area values('{software_id.Text}', '{software_name.Text}', '{expertise.Text}')");
            clearText(groupBox1);
            refreshDataGridView("software");
        }

        //Show project's engineers
        private void button5_Click(object sender, EventArgs e)
        {
            //SELECT id AS project_id ,T12.engineer_id, software_area_id FROM(Select id, engineer_id FROM project AS T1 JOIN works AS T2 ON T1.id = T2.project_id WHERE T1.id = {textBox17.Text}) AS T12 JOIN belongs AS T3 ON T12.engineer_id = T3.engineer_id ORDER BY software_area_id DESC;
            command = new MySqlCommand($"SELECT id AS project_id ,T12.engineer_id, software_area_id FROM(Select id,engineer_id FROM project AS T1 JOIN works AS T2 ON T1.id=T2.project_id WHERE T1.id={textBox17.Text}) AS T12 JOIN belongs AS T3 ON T12.engineer_id=T3.engineer_id",sqlCommandsManager.conn);
            showTable(dataGridView4, command);
            dataGridView4.Sort(dataGridView4.Columns["software_area_id"],System.ComponentModel.ListSortDirection.Descending);
        }

        //show engineer's projects
        private void button6_Click(object sender, EventArgs e)
        {
            command = new MySqlCommand($"select project_id from works WHERE engineer_id ={textBox18.Text}", sqlCommandsManager.conn);
            showTable(dataGridView5, command);
        }

        //show engineer's software area
        private void button7_Click(object sender, EventArgs e)
        {
            command = new MySqlCommand($"select software_area_id,name from belongs,software_area WHERE engineer_id={textBox19.Text} and belongs.software_area_id =software_area.id ", sqlCommandsManager.conn);
            showTable(dataGridView5, command);
        }

        //show engineer's phones
        private void button8_Click(object sender, EventArgs e)
        {
            command = new MySqlCommand($"select phones.phone from phones,engineer WHERE engineer.id ={textBox20.Text} and phones.engineer_id=engineer.id", sqlCommandsManager.conn);
            showTable(dataGridView5, command);
        }

        //add engineer phone
        private void button9_Click(object sender, EventArgs e)
        {
            sqlCommandsManager.insertData($"phones values ('{textBox21.Text}', '{textBox22.Text}')");
            clearText(groupBox9);
        }

         //add engineer to project
        private void button14_Click(object sender, EventArgs e)
        {
            sqlCommandsManager.insertData($"works values ('{comboBox5.SelectedValue}', '{textBox23.Text}')");
            clearText(groupBox10);
        }

        //remove Engineer from project
        private void button15_Click(object sender, EventArgs e)
        {
            sqlCommandsManager.removeEngineerFromProject("works",textBox23.Text, comboBox5.SelectedValue.ToString());
            clearText(groupBox10);
        }

        //remove engineer phone
        private void button13_Click(object sender, EventArgs e)
        {
            sqlCommandsManager.removeEngineerPhone("phones", textBox21.Text, textBox22.Text);
            clearText(groupBox9);
        }

        //show software_area's engineer
        private void button16_Click(object sender, EventArgs e)
        {
            command = new MySqlCommand($"select engineer_id,software_area_id FROM belongs WHERE (software_area_id) in (SELECT id FROM software_area where id = {textBox25.Text}); ", sqlCommandsManager.conn);
            showTable(dataGridView6, command);
        }

        //update engineer details
        private void button10_Click(object sender, EventArgs e)
        {
            List<string> keys = new List<string>();
            List<string> values = new List<string>();
            foreach (Control c in groupBox2.Controls)
            {
                if (c is TextBox && c.Text !="")
                {
                    keys.Add(c.Name);
                    values.Add(c.Text);                   
                }
            }
            sqlCommandsManager.updateEngineerDetails("engineer", keys,values);
            if (comboBox1.SelectedValue != null)
                sqlCommandsManager.updateEngineerSoftware("belongs", id.Text, comboBox1.SelectedValue.ToString());
            clearText(groupBox2);
            comboBox1.SelectedIndex = -1;
            refreshDataGridView("engineer");
        }

        //update project details
        private void button11_Click(object sender, EventArgs e)
        {
            List<string> keys = new List<string>();
            List<string> values = new List<string>();
            foreach (Control c in groupBox3.Controls)
            {
                if (c is TextBox && c.Text != "" || c is DateTimePicker)
                {
                    keys.Add(c.Name);
                    values.Add(c.Text);
                    
                }
            }
            sqlCommandsManager.updateProjectDetails("project", keys, values);
            clearText(groupBox3);
            refreshDataGridView("project");
        }

        //update software_area detalis
        private void button12_Click(object sender, EventArgs e)
        {
            List<string> keys = new List<string>();
            List<string> values = new List<string>();
            foreach (Control c in groupBox1.Controls)
            {
                if (c is TextBox && c.Text != "")
                {
                    keys.Add(c.Name);
                    values.Add(c.Text);
                }
            }
            sqlCommandsManager.updateSoftwareDetails("software_area", keys, values);
            clearText(groupBox1);
            refreshDataGridView("software");
        }


        // add Grade to project
        private void button18_Click(object sender, EventArgs e)
        {
            sqlCommandsManager.insertData($"grade values ('{dateTimePicker1.Text}', '{textBox1.Text}','{comboBox3.SelectedValue}','{comboBox2.SelectedItem}')");
            clearText(groupBox12);
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;

        }

        //show milestones
        private void button19_Click(object sender, EventArgs e)
        {
            command = new MySqlCommand($"select * FROM milestones WHERE project_id = {textBox3.Text} ORDER BY date", sqlCommandsManager.conn);
            showTable(dataGridView4, command);
        }

        //show top 3 popular projects
        private void button20_Click(object sender, EventArgs e)
        {
            command = new MySqlCommand($"SELECT project.id,project.name,AVG(grade.grade) AS avg_grade FROM project INNER JOIN grade ON grade.project_id =project.id GROUP BY project.id, project.name ORDER BY AVG(grade.grade) desc limit 3", sqlCommandsManager.conn);
            showTable(dataGridView4, command);
        }

        //show less 3 popular projects
        private void button21_Click(object sender, EventArgs e)
        {
            command = new MySqlCommand($"SELECT project.id,project.name,AVG(grade.grade) AS avg_grade FROM project INNER JOIN grade ON grade.project_id =project.id GROUP BY project.id, project.name ORDER BY avg_grade limit 3", sqlCommandsManager.conn);
            showTable(dataGridView4, command);
        }

        // show project stages
        private void button22_Click(object sender, EventArgs e)
        {
            command = new MySqlCommand($"select project_id,stage_name FROM stage_in_project WHERE project_id = {textBox4.Text}", sqlCommandsManager.conn);
            showTable(dataGridView4, command);
            label34.Visible = true;
            textBox5.Visible = true;
            button23.Visible = true;
        }

        //show stage tools
        private void button23_Click(object sender, EventArgs e)
        {
            command = new MySqlCommand($"select stage_name,tool_name FROM tool_in_stage WHERE stage_name = '{textBox5.Text}'", sqlCommandsManager.conn);
            showTable(dataGridView4, command);
        }

        //show close month milestones
        private void button4_Click(object sender, EventArgs e)
        {
            string d = DateTime.Now.ToString("MMM-yy"); 
            command = new MySqlCommand($"select project_id,date,sum(incoming_cash) FROM milestones WHERE project_id = {textBox3.Text} and date='{d}'", sqlCommandsManager.conn);
            showTable(dataGridView4, command);
        }

        //add Milestones to project
        private void button24_Click(object sender, EventArgs e)
        {
            sqlCommandsManager.insertData($"milestones values ('{textBox6.Text}', '{dateTimePicker2.Text}','{textBox7.Text}','{incomingCash.Value}')");
            clearText(groupBox4);
        }

         //remove milestone
        private void button17_Click(object sender, EventArgs e)
        {
            sqlCommandsManager.removeMilestoneFromProject("Milestones", textBox6.Text, textBox7.Text);
            clearText(groupBox4);
        }

        //calculate engineer age
        private void date_ValueChanged(object sender, EventArgs e)
        {
            int currentYear = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
            int birthYear = Convert.ToInt32(date.Text.Substring(0,4));
            age.Text = (currentYear - birthYear).ToString();
        }

       
        //add stage to project
        private void button26_Click(object sender, EventArgs e)
        {
            sqlCommandsManager.insertData($"stage_in_project values('{textBox2.Text}', '{comboBox4.SelectedValue}')");
            clearText(groupBox18);
        }

        //remove stage to project
        private void button27_Click(object sender, EventArgs e)
        {
            
            sqlCommandsManager.removeStageFromProject("stage_in_project", textBox2.Text, comboBox4.SelectedValue.ToString());
            refreshDataGridView("project");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            command = new MySqlCommand($"SELECT stage_name FROM stage", sqlCommandsManager.conn);
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            comboBox4.DataSource = dt.DefaultView;
            comboBox4.DisplayMember = "name";
            comboBox4.ValueMember = "stage_name";
            comboBox4.SelectedIndex = -1;
        }

        //show busy engineers
        private void button25_Click_1(object sender, EventArgs e)
        {
            command = new MySqlCommand("SELECT e.id, e.first_name ,e.last_name FROM engineer as e INNER JOIN works as w ON e.id = w.engineer_id INNER JOIN project as p ON p.id = w.project_id GROUP BY e.id, e.first_name, e.last_name HAVING COUNT(w.project_id) = (SELECT COUNT(id) FROM project);", sqlCommandsManager.conn);
            showTable(dataGridView5, command);
        }

        // projects in specific engineer list for comboBox3
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                command = new MySqlCommand($"SELECT project_id FROM works WHERE engineer_id = {textBox1.Text}", sqlCommandsManager.conn);
                DataTable dt = new DataTable();
                dt.Load(command.ExecuteReader());
                comboBox3.DataSource = dt.DefaultView;
                comboBox3.DisplayMember = "name";
                comboBox3.ValueMember = "project_id";
                comboBox3.SelectedIndex = -1;
            }
        }

        //engineers in specific project list for comboBox5
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox23.Text))
            {
                command = new MySqlCommand($"SELECT engineer_id FROM works WHERE project_id = {textBox23.Text}", sqlCommandsManager.conn);
                DataTable dt = new DataTable();
                dt.Load(command.ExecuteReader());
                comboBox5.DataSource = dt.DefaultView;
                comboBox5.DisplayMember = "name";
                comboBox5.ValueMember = "engineer_id";
                comboBox5.SelectedIndex = -1;
            }
        }
    }
}
