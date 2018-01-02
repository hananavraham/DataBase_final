
/// Name:Hanan Avraham  Id:062844881

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace DB_FinalProject
{
    class sqlCommandsManager
    {
        public static string connString = "Server=localhost;Port=3306;Database=db_project;Uid=root;password=1307;";
        public static MySqlConnection conn = new MySqlConnection(connString);
        public static void createDBdata()
        {
            createTable("Engineer (id int, first_name varchar(15), last_name varchar(15), address varchar(50), birth date, age int, PRIMARY KEY(id));");
            createTable("Works (engineer_id int,project_id int, PRIMARY KEY(engineer_id,project_id));");
            createTable("Belongs (engineer_id int,software_area_id int, PRIMARY KEY(engineer_id,software_area_id));");
            createTable("Software_Area (id int, name varchar(50),expertise varchar(50) ,PRIMARY KEY(id));");
            createTable("Project (id int, name varchar(50) ,costumer varchar(50) ,start_date varchar(7), description varchar(50),PRIMARY KEY(id));");
            createTable("Milestones (project_id int, date varchar(7), description varchar(50), incoming_cash double, PRIMARY KEY(description),foreign key(project_id) references Project(id) ON DELETE CASCADE);");
            createTable("phones (engineer_id int,phone varchar(50), PRIMARY KEY(phone) ,foreign key(engineer_id) references engineer(id) ON DELETE CASCADE);");       // one to many relationship                     
            createTable("grade(month varchar(7),engineer_id int, project_id int, grade int, PRIMARY KEY (month,engineer_id,project_id));");
            createTable("stage(stage_name varchar(30),PRIMARY KEY(stage_name));");
            createTable("stage_tool(tool_name varchar(50), PRIMARY KEY(tool_name));");
            createTable("stage_in_project(project_id int,stage_name varchar(30),PRIMARY KEY(project_id,stage_name));");
            createTable("tool_in_stage(tool_name varchar(50),stage_name varchar(30),PRIMARY KEY(tool_name,stage_name));");
            ////////// engineer
            insertData("Engineer values(62844881, 'Hanan', 'Avraham', 'Jerusalem','1982-10-1',35)");
            insertData("Engineer values(12345543, 'Yossi', 'Moshe', 'Haifa','1984-11-11',33)");
            insertData("Engineer values(23892349, 'Liat', 'Harel', 'Tel Aviv','1983-9-11',34)");
            insertData("Engineer values(53409834, 'Avi', 'Levi', 'Jerusalem','1992-4-11',26)");
            insertData("Engineer values(43262723, 'Meir', 'Maimon', 'Bat Yam','1990-6-6',28)");
            insertData("Engineer values(36423721, 'Eli', 'Belisha', 'Bet Shemesh','1987-4-6',30)");
            insertData("Engineer values(15373912, 'Yoav', 'Iluz', 'Holon','1987-7-12',30)");
            insertData("Engineer values(94749192, 'Mali', 'Dahan', 'Hadera','1985-12-12',33)");
            insertData("Engineer values(74888164, 'Oshrat', 'Menashe', 'Tel Aviv','1986-12-12',32)");
            insertData("Engineer values(66472818, 'Menachem', 'Levi', 'Herzelia','1982-10-10',35)");
            ////////// software area
            insertData("Software_Area values (354,'automation','tools')");
            insertData("Software_Area values (322,'Games','Ios')");
            insertData("Software_Area values (133,'Algorithm','KMP')");
            insertData("Software_Area values (754,'Mobile','Apps')");
            insertData("Software_Area values (636,'HTML','PHP')");
            insertData("Software_Area values (155,'Backend','DB')");
            insertData("Software_Area values (322,'Servers','Java')");
            insertData("Software_Area values (175,'RT','Emb')");
            insertData("Software_Area values (369,'Web','Jquery')");
            insertData("Software_Area values (720,'DevOps','Architector')");
            ///////// project
            insertData("Project values (123,'factory','amd', 'Nov-17','create new tool')");
            insertData("Project values (456,'debug','ness', 'Dec-17','debug tests')");
            insertData("Project values (789,'Analysis','Xcode', 'Feb-18','code analysis')");
            insertData("Project values (112,'Data Mining','Microsoft', 'Feb-18','Popularity Analysis')");
            insertData("Project values (344,'Dot Net','Google', 'Mar-18','HR Management System')");
            insertData("Project values (156,'Biometrics','Loto', 'Dec-18','Fingerprint Authenticated')");
            insertData("Project values (766,'Cloud Computing','Facebook', 'Nov-19','Secure Text Transfer')");
            insertData("Project values (830,'Matlab','IDF', 'Apr-18','Signature Verification System')");
            insertData("Project values (223,'iOS','Apple', 'Nov-18','Personal Health Tracker')");
            insertData("Project values (552,'Cloud Storage','Dok', 'Jan-18','Secure File Storage')");
            ///////// works
            insertData("Works  values (62844881,123)");
            insertData("Works  values (15373912,123)");
            insertData("Works  values (66472818,123)");
            insertData("Works  values (62844881,456)");
            insertData("Works  values (62844881,789)");
            insertData("Works  values (12345543,456)");
            insertData("Works  values (23892349,456)");
            insertData("Works  values (53409834,456)");
            insertData("Works  values (36423721,456)");
            insertData("Works  values (23892349,552)");
            insertData("Works  values (23892349,223)");
            insertData("Works  values (53409834,223)");
            insertData("Works  values (62844881,830)");
            insertData("Works  values (74888164,776)");
            //////// Belongs
            insertData("Belongs values (62844881,354)");
            insertData("Belongs values (12345543,354)");
            insertData("Belongs values (23892349,322)");
            insertData("Belongs values (53409834,133)");
            insertData("Belongs values (43262723,754)");
            insertData("Belongs values (36423721,354)");
            insertData("Belongs values (15373912,636)");
            insertData("Belongs values (94749192,155)");
            insertData("Belongs values (74888164,155)");
            insertData("Belongs values (66472818,175)");
            //////// Grade
            insertData("grade values ('Aug-17',62844881,456,7)");
            insertData("grade values ('Aug-17',23892349,456,9)");
            insertData("grade values ('Aug-17',53409834,456,1)");
            insertData("grade values ('Aug-17',36423721,456,5)");
            insertData("grade values ('Aug-17',62844881,123,9)");
            insertData("grade values ('Aug-17',15373912,456,9)");
            insertData("grade values ('Aug-17',66472818,456,9)");
            //////// Stage
            insertData("stage values ('Design')");
            insertData("stage values ('Encoding')");
            insertData("stage values ('QA')");
            insertData("stage values ('Configuration Management')");
            insertData("stage values ('Create Server')");
            insertData("stage values ('Machine Learning')");
            insertData("stage values ('App Store')");
            insertData("stage values ('GitHub')");
            insertData("stage values ('Touch Card')");
            insertData("stage values ('Check Video')");
            //////// stage tool
            insertData("stage_tool values ('visualStudio')");
            insertData("stage_tool values ('office')");
            insertData("stage_tool values ('Aptana')");
            insertData("stage_tool values ('Java')");
            insertData("stage_tool values ('Python')");
            insertData("stage_tool values ('HTML5')");
            insertData("stage_tool values ('Java Script')");
            insertData("stage_tool values ('JUnit')");
            insertData("stage_tool values ('Appium')");
            insertData("stage_tool values ('Research')");
            insertData("stage_tool values ('Pv4')");
            //////// milestone
            insertData("Milestones values (123,'DEC-17','update db',1542.12)");
            insertData("Milestones values (123,'FEB-18','create UI',1542.12)");
            insertData("Milestones values (123,'FEB-18','New Server',10000)");
            insertData("Milestones values (456,'DEC-17','new automation tool',1500.15)");
            insertData("Milestones values (456,'DEC-17','new DB',1542.12)");
            insertData("Milestones values (456,'JAN-18','upgrade security',154000)");
            insertData("Milestones values (223,'Mar-18','First App review',15000)");
            insertData("Milestones values (112,'Apr-18','new Data view',200000)");
            insertData("Milestones values (344,'JAN-18','data in Github',1500)");
            insertData("Milestones values (766,'Jun-18','Cloud Storage',75000)");
            //////// phone
            insertData("phones values (62844881,'0545449173')");
            insertData("phones values (62844881,'0545423677')");
            //////// stage in project
            insertData("stage_in_project values(123,'Design')");
            insertData("stage_in_project values(123,'Encoding')");
            insertData("stage_in_project values(456,'Encoding')");
            insertData("stage_in_project values(456,'Design')");
            insertData("stage_in_project values(456,'QA')");
            insertData("stage_in_project values(156,'GitHub')");
            insertData("stage_in_project values(766,'QA')");
            insertData("stage_in_project values(156,'Touch Card')");
            insertData("stage_in_project values(223,'QA')");
            insertData("stage_in_project values(552,'App Store')");
            insertData("stage_in_project values(223,'App Store')");
            insertData("stage_in_project values(123,'App Store')");
            insertData("stage_in_project values(344,'GitHub')");
            insertData("stage_in_project values(344,'Touch Card')");
            insertData("stage_in_project values(112,'Create Server')");
            //////// tool in stage
            insertData("tool_in_stage values('visualStudio','Encoding')");
            insertData("tool_in_stage values('Java','Encoding')");
            insertData("tool_in_stage values('Python','Encoding')");
            insertData("tool_in_stage values('Aptana','Design')");
            insertData("tool_in_stage values('HTML5','Design')");
            insertData("tool_in_stage values('Java Script','Design')");
            insertData("tool_in_stage values('Appium','QA')");
            insertData("tool_in_stage values('JUnit','QA')");
            insertData("tool_in_stage values('3D printer','Touch Card')");
            insertData("tool_in_stage values('Git','GiThub')");
            insertData("tool_in_stage values('3D printer','Touch Card')");
            insertData("tool_in_stage values('3D printer','Touch Card')");
        }
        
        //create triggers
        public static void createTriggers()
        {
            MySqlCommand command = conn.CreateCommand();
            List<string> commands = new List<string>();
            commands.Add("CREATE TRIGGER delete_stage AFTER DELETE ON project FOR EACH ROW BEGIN DELETE FROM stage_in_project where OLD.id=project_id;DELETE FROM grade where OLD.id=project_id;END");
            commands.Add("CREATE TRIGGER delete_eng_details AFTER DELETE ON engineer FOR EACH ROW BEGIN DELETE FROM belongs where OLD.id=engineer_id;DELETE FROM works where OLD.id = engineer_id;DELETE FROM grade where OLD.id = engineer_id;END");
            foreach (string s in commands)
            {
                command.CommandText = s;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch { }
            }
            
           

        }
        
        //create connection
        public static MySqlConnection createConnection()
        {
            MySqlCommand command = conn.CreateCommand();

            try
            {
                conn.Open();
            }
            catch { }
            return conn;
        }

        //close connection
        public static void closeConnection()
        {
            try
            {
                conn.Close();
            }
            catch { }
        }

        //create table
        public static void createTable(string data)
        {
            try
            {
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "CREATE TABLE if not exists " + data;
                command.ExecuteNonQuery();      // running insert command
            }
            catch { }
        }

        //insert data to table
        public static void insertData(string data)
        {
            try
            {
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "Insert INTO " + data;
                command.ExecuteNonQuery();      // running insert command
                MessageBox.Show("Insert Data success");
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
            }
        }

        //remove data from table
        public static void removeData(string table,string id)
        {
            try
            {
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = $"DELETE FROM {table} WHERE id={id}";
                command.ExecuteNonQuery();      // running insert command
                MessageBox.Show("Remove Data success");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //remove engineer from project
        public static void removeEngineerFromProject(string table, string pro_id, string eng_id)
        {
            try
            {
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = $"DELETE FROM {table} WHERE project_id={pro_id} and engineer_id={eng_id}";
                command.ExecuteNonQuery();      // running insert command
                MessageBox.Show("Remove Data success");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //remove engineer phone
        public static void removeEngineerPhone(string table, string eng_id, string phone)
        {
            try
            {
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = $"DELETE FROM {table} WHERE engineer_id={eng_id} and phone={phone}";
                command.ExecuteNonQuery();      // running insert command
                MessageBox.Show("Remove Data success");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //remove stage from project
        public static void removeStageFromProject(string table,string pro_id,string stage_name)
        {
            try 
            {
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = $"DELETE FROM {table} WHERE project_id={pro_id} and stage_name='{stage_name}'";
                command.ExecuteNonQuery();      // running insert command
                MessageBox.Show("Remove Data success");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }


        public static void readData(string requestData, MySqlConnection conn)
        {
            try
            {
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = requestData;
                MySqlDataReader reader = command.ExecuteReader();       //read data
            }
            catch { }
        }

        //update engineer details
        public static void updateEngineerDetails(string table, List<string> keys, List<string> values)
        {
            string id = "";
            for (int i = 0; i < keys.Count; ++i)
            {
                if (keys[i].Equals("id"))
                {
                    id = values[i];
                    break;
                }
            }
            try
            {
                MySqlCommand command = conn.CreateCommand();
                for (int i =0; i < keys.Count; ++i)
                {
                    if (keys[i].Equals("id"))
                    {
                        continue;
                    }
                    command.CommandText = $"update {table} set {keys[i]}='{values[i]}' where id={id}";
                    command.ExecuteNonQuery(); 
                }

                MessageBox.Show("Update Data success");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //update engineer software area
        public static void updateEngineerSoftware(string table,string id, string value)
        {
            try 
            {
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = $"update {table} set software_area_id='{value}' where engineer_id={id}";
                command.ExecuteNonQuery();
                MessageBox.Show("Update Data success");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //update project details
        public static void updateProjectDetails(string table, List<string> keys, List<string> values)
        {
            string id = "";
            for (int i = 0; i < keys.Count; ++i)
            {
                if (keys[i].Equals("project_id"))
                {
                    id = values[i];
                    break;
                }
            }
            try
            {
                MySqlCommand command = conn.CreateCommand();
                for (int i = 0; i < keys.Count; ++i)
                {
                    if (keys[i].Equals("project_id"))
                    {
                        continue;
                    }
                    command.CommandText = $"update {table} set {keys[i]}='{values[i]}' where id={id}";
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Update Data success");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //update software area details
        public static void updateSoftwareDetails(string table, List<string> keys, List<string> values)
        {
            string id = "";
            for (int i = 0; i < keys.Count; ++i)
            {
                if (keys[i].Equals("software_id"))
                {
                    id = values[i];
                    break;
                }
            }
            try
            {
                MySqlCommand command = conn.CreateCommand();
                for (int i = 0; i < keys.Count; ++i)
                {
                    if (keys[i].Equals("software_id"))
                    {
                        continue;
                    }
                    if (keys[i].Equals("software_name"))
                    {
                        //create transaction
                        command.CommandText = $"BEGIN WORK;SELECT id FROM {table} WHERE id = {id} for update;ROLLBACK;UPDATE software_area SET name = '{values[i]}' WHERE id = {id};commit;";
                        command.ExecuteNonQuery();
                    }
                    else 
                    {                       
                        //create transaction
                        command.CommandText = $"BEGIN WORK;SELECT id FROM {table} WHERE id = {id} for update;ROLLBACK;UPDATE software_area SET {keys[i]}='{values[i]}' WHERE id = {id};commit;";
                        command.ExecuteNonQuery();
                    }
                    
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //remove milestone from project
        public static void removeMilestoneFromProject(string table,string proj_id,string milestonte)
        {
            try
            {
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = $"DELETE FROM {table} WHERE project_id={proj_id} and description='{milestonte}'";
                command.ExecuteNonQuery();      // running insert command
                MessageBox.Show("Remove Data success");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
