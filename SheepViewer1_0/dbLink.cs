using System;
using System.IO;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SheepViewer1_0
{
    class dbLink
    {
        private static string getConnectionString()
        {
            return "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\\sheepDB.mdf; Integrated Security = True; Connect Timeout = 30";
        }

        private static string getProgramFolder()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        private static void logProcess(string process)
        {
            logWriter("_\n" + DateTime.Now.ToString() + "\n" + process);
        }

        private static void logProcessSuccess(bool success, string moreInfo)
        {
            logWriter(success.ToString() + " - " + moreInfo);
        }

        private static void logWriter(string logEntry)
        {
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(getProgramFolder(), "processLog.txt"), true))
            {
                outputFile.WriteLine(logEntry);
            }
        }

        private static string fixOwned(string ownedInput)
        {
            if (ownedInput == "True")
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

        private static string fixDate(string dateInput)
        {
            if(dateInput.Length == 10)
            {
                return Convert.ToDateTime(dateInput).ToString("yyyy-MM-dd");
            }
            else
            {
                return dateInput + "-01-01";
            }
        }

        public static int saveSheep(string tagNo, string owned, string name, string sire, string dam, string dob, string sex)
        {
            using (SqlConnection connection = new SqlConnection(getConnectionString()))
            {
                int rowsAffected = 0;
                try
                {
                    owned = fixOwned(owned);
                    dob = fixDate(dob);

                    string sqlQuery = string.Format("INSERT INTO sheep (tagNo, owned, name, sire, dam, dob, sex) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", tagNo, owned, name, sire, dam, dob, sex);

                    logProcess(sqlQuery);

                    //connection open
                    connection.Open();
                    
                    SqlCommand command = new SqlCommand(sqlQuery, connection);

                    rowsAffected = command.ExecuteNonQuery();

                    //close sql  connection
                    connection.Close();

                    logProcessSuccess(true, rowsAffected.ToString());
                }
                catch (Exception ex)
                {
                    logProcessSuccess(false, ex.ToString());
                    MessageBox.Show(ex + "");
                }
                return rowsAffected;
            }
        }

        public static int editSheep(string tagNo, string owned, string name, string sire, string dam, string dob, string sex)
        {
            using (SqlConnection connection = new SqlConnection(getConnectionString()))
            {
                int rowsAffected = 0;
                try
                {
                    owned = fixOwned(owned);
                    dob = fixDate(dob);

                    string sqlQuery = string.Format("UPDATE sheep SET owned = '{1}', name = '{2}', sire = '{3}', dam = '{4}', dob = '{5}', sex = '{6}' WHERE tagNo = '{0}'", tagNo, owned, name, sire, dam, dob, sex);

                    logProcess(sqlQuery);

                    //connection open
                    connection.Open();
                    
                    SqlCommand command = new SqlCommand(sqlQuery, connection);
                    
                    rowsAffected = command.ExecuteNonQuery();
                    
                    //close sql  connection
                    connection.Close();

                    logProcessSuccess(true, rowsAffected.ToString());
                }
                catch (Exception ex)
                {
                    logProcessSuccess(false, ex.ToString());
                    MessageBox.Show(ex + "");
                }
                return rowsAffected;
            }
        }

        public static List<string> viewSheep(string tagNo)
        {
            using (SqlConnection connection = new SqlConnection(getConnectionString()))
            {
                List<string> sheepInfo = new List<string>();
                string sqlQuery = string.Format("SELECT * FROM sheep WHERE tagNo = '" + tagNo + "'");
                try
                {
                    //connection open
                    connection.Open();
                    
                    SqlCommand command = new SqlCommand(sqlQuery, connection);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string owned = (string)reader["owned"].ToString().Trim(); string name = (string)reader["name"].ToString().Trim(); string sire = (string)reader["sire"].ToString().Trim(); string dam = (string)reader["dam"].ToString().Trim(); string dob = (string)reader["dob"].ToString(); string sex = (string)reader["sex"].ToString().Trim();
                        sheepInfo.Add(tagNo); sheepInfo.Add(owned); sheepInfo.Add(name); sheepInfo.Add(sire); sheepInfo.Add(dam); sheepInfo.Add(dob); sheepInfo.Add(sex);
                    }

                    //close sql  connection
                    connection.Close();
                }
                catch (Exception ex)
                {
                    logProcess(sqlQuery);
                    logProcessSuccess(false, ex.ToString());
                    MessageBox.Show(ex + "");
                }
                return sheepInfo;
            }
        }

        public static int deleteSheep(string tagNo)
        {
            string sqlQuery = string.Format("DELETE FROM sheep WHERE tagNo = '" + tagNo + "'");
            
            logProcess(sqlQuery);

            using (SqlConnection connection = new SqlConnection(getConnectionString()))
            {
                int rowsAffected = 0;
                try
                {
                    //connection open
                    connection.Open();

                    SqlCommand command = new SqlCommand(sqlQuery, connection);

                    rowsAffected = command.ExecuteNonQuery();

                    //close sql  connection
                    connection.Close();

                    logProcessSuccess(true, null);
                }
                catch (Exception ex)
                {
                    logProcessSuccess(false, ex.ToString());
                    MessageBox.Show(ex + "");
                }
                return rowsAffected;
            }
        }

        public static int saveLambing(string tagNo, string lambingDate, string lambTagNo)
        {
            using (SqlConnection connection = new SqlConnection(getConnectionString()))
            {
                int rowsAffected = 0;
                try
                {
                    lambingDate = fixDate(lambingDate);

                    string sqlQuery = string.Format("INSERT INTO lambing (tagNo, lambingDate, lambTagNo) VALUES('{0}','{1}','{2}')", tagNo, lambingDate, lambTagNo);

                    logProcess(sqlQuery);

                    //connection open
                    connection.Open();

                    SqlCommand command = new SqlCommand(sqlQuery, connection);

                    rowsAffected = command.ExecuteNonQuery();

                    //close sql  connection
                    connection.Close();

                    logProcessSuccess(true, rowsAffected.ToString());
                }
                catch (Exception ex)
                {
                    logProcessSuccess(false, ex.ToString());
                    MessageBox.Show(ex + "");
                }
                return rowsAffected;
            }
        }

        public static int deleteLambing(string tagNo, string lambingDate)
        {
            lambingDate = fixDate(lambingDate);

            string sqlQuery = string.Format("DELETE FROM lambing WHERE tagNo = '" + tagNo + "' AND lambingDate = '" + lambingDate + "'");
            
            logProcess(sqlQuery);

            using (SqlConnection connection = new SqlConnection(getConnectionString()))
            {
                int rowsAffected = 0;
                try
                {
                    //connection open
                    connection.Open();

                    SqlCommand command = new SqlCommand(sqlQuery, connection);

                    rowsAffected = command.ExecuteNonQuery();

                    //close sql  connection
                    connection.Close();

                    logProcessSuccess(true, null);
                }
                catch (Exception ex)
                {
                    logProcessSuccess(false, ex.ToString());
                    MessageBox.Show(ex + "");
                }
                return rowsAffected;
            }
        }

        public static List<string> viewLambing(string tagNo, string lambingDate)
        {
            using (SqlConnection connection = new SqlConnection(getConnectionString()))
            {
                List<string> lambingList = new List<string>();

                try
                {
                    //connection open
                    connection.Open();

                    string sqlQuery = null;

                    lambingDate = fixDate(lambingDate);
                    
                    sqlQuery = string.Format("SELECT * FROM lambing WHERE tagNo = '" + tagNo + "' AND lambingDate = '" + lambingDate + "'");

                    logProcess(sqlQuery);

                    SqlCommand command = new SqlCommand(sqlQuery, connection);

                    SqlDataReader reader = command.ExecuteReader();

                    lambingList.Add(tagNo);
                    lambingList.Add(lambingDate);

                    while (reader.Read())
                    {
                        lambingList.Add((string)reader["lambTagNo"].ToString().Trim());
                    }

                    //close sql  connection
                    connection.Close();
                }
                catch (Exception ex)
                {
                    logProcessSuccess(false, ex.ToString());
                    MessageBox.Show("There was a problem retreiving the information from the file, please try again.\n\nDetails:\n" + ex);
                }

                return lambingList;
            }
        }

        //public static List<List<string>> viewLambing()
        //{
        //    using (SqlConnection connection = new SqlConnection(getConnectionString()))
        //    {
        //        List<List<string>> lambingList = new List<List<string>>();

        //        try
        //        {
        //            //connection open
        //            connection.Open();

        //            string sqlQuery = null;

        //            sqlQuery = string.Format("SELECT * FROM lambing");

        //            logProcess(sqlQuery);

        //            SqlCommand command = new SqlCommand(sqlQuery, connection);

        //            SqlDataReader reader = command.ExecuteReader();
                    
        //            while (reader.Read())
        //            {
        //                tempLambingList.Add(())
        //                lambingList.Add((string)reader["lambTagNo"].ToString().Trim());
        //            }

        //            //close sql  connection
        //            connection.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            logProcessSuccess(false, ex.ToString());
        //            MessageBox.Show("There was a problem retreiving the information from the file, please try again.\n\nDetails:\n" + ex);
        //        }

        //        return lambingList;
        //    }
        //}
    }
}
