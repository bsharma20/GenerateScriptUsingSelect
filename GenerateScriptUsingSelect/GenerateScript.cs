namespace GenerateScriptUsingSelect
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Data.SqlClient;
   

    public class GenerateScript
    {
        private static string ApplicationId = "";

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter Application Id : ");
            ApplicationId = Console.ReadLine();
            Console.WriteLine("Application Id : " + ApplicationId);
            Console.WriteLine("Please press enter to proceed");
            Console.ReadLine();
            ExecuteReader();
        }

        public static void ExecuteReader()
        {
            var myConnection = new SqlConnection("Data Source=echannel-nudquoteappcms-sy-sql.via.novonet;Initial Catalog=NUDQuoteAppCMS_SY;Integrated Security=SSPI;user id= SQLQuoteAppUser; password = y0g1834r;");
            try
            {
                myConnection.Open();
                TblCMSSectionsScript(myConnection);
                TblFieldsScript(myConnection);
                TblCMSFieldsScript(myConnection);
                TblCMSPagesScript(myConnection);
                TblCMSApplicationsScript(myConnection);
                SelectDataFromTables();
                
            }
            catch (Exception ex)
            {
                myConnection.Close();
                Console.WriteLine("Exception Message : - " + ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
           
        }

        private static void TblCMSSectionsScript(SqlConnection myConnection)
        {
            if (myConnection.State != System.Data.ConnectionState.Open)
            {
                myConnection.Open();
            }

            var myCommand = new SqlCommand("Select * from [tblCMSSections] WHERE [ApplicationId] = 'MyPolicy' and PageId NOT IN ('GeneralMotor', 'MotorHelp', 'AddDriver', 'VehEditHelp')", myConnection);
            SqlDataReader myReader = myCommand.ExecuteReader();

            StreamWriter wr = new StreamWriter("c:\\out.txt", false);

            wr.WriteLine("\n");
            wr.WriteLine("-- Starts of tblCMSSections Insert Script -- ");
            wr.WriteLine("\n");
            string deleteCommand = " DELETE FROM [NUDQuoteAppCMS_SY].[dbo].[tblCMSSections] WHERE [ApplicationId] = '" + ApplicationId + "'";
            wr.WriteLine(deleteCommand);
            wr.WriteLine("\n");
            while (myReader.Read())
            {
                string insertCommand =
                    " INSERT INTO [NUDQuoteAppCMS_SY].[dbo].[tblCMSSections]([ApplicationID],[PageID],[SectionID],[SectionDesc],[SectionOrder]) VALUES ('" + ApplicationId + "','" + myReader[1].ToString().Trim().Replace("'", "''") + "','" + myReader[2].ToString().Trim().Replace("'", "''") + "','" + myReader[3].ToString().Trim().Replace("'", "''") + "'," + myReader[4].ToString().Trim().Replace("'", "''") + ");";

                wr.WriteLine(insertCommand);
                Console.WriteLine(insertCommand);
            }
            wr.WriteLine("\n");            
            wr.WriteLine("-------- Ends of tblCMSSections Insert Script -- ");
            wr.Close();
            myReader.Close();
        }

        private static void TblFieldsScript(SqlConnection myConnection)
        {
            if (myConnection.State != System.Data.ConnectionState.Open)
            {
                myConnection.Open();
            }

            var myCommand = new SqlCommand("Select * from [tblFields] WHERE [ApplicationId] = 'MyPolicy' and PageId NOT IN ('GeneralMotor', 'MotorHelp', 'AddDriver', 'VehEditHelp')", myConnection);
            SqlDataReader myReader = myCommand.ExecuteReader();

            StreamWriter wr = new StreamWriter("c:\\out.txt", true);

            wr.WriteLine("\n");
            wr.WriteLine(" -------- Starts of tblFields Insert Script -- ");
            wr.WriteLine("\n");
            string deleteCommand = " DELETE FROM [NUDQuoteAppCMS_SY].[dbo].[tblFields] WHERE [ApplicationId] = '" + ApplicationId + "'";
            wr.WriteLine(deleteCommand);
            wr.WriteLine("\n");
            while (myReader.Read())
            {
                string insertCommand =
                    " INSERT INTO [NUDQuoteAppCMS_SY].[dbo].[tblFields]([FieldId],[PageId],[ApplicationId],[Label],[Text],[HelpId]) VALUES ('" + myReader[0].ToString().Trim().Replace("'", "''") + "','" + myReader[1].ToString().Trim().Replace("'", "''") + "','" + ApplicationId + "','" + myReader[3].ToString().Trim().Replace("'", "''") + "','" + myReader[4].ToString().Trim().Replace("'", "''") + "','" + myReader[5].ToString().Trim().Replace("'", "''") + "');";

                wr.WriteLine(insertCommand);
                Console.WriteLine(insertCommand);
            }
            wr.WriteLine("\n");            
            wr.WriteLine("----- Ends of tblFields Insert Script -- ");
            wr.Close();
            myReader.Close();
        }

        private static void TblCMSFieldsScript(SqlConnection myConnection)
        {
            if (myConnection.State != System.Data.ConnectionState.Open)
            {
                myConnection.Open();
            }

            var myCommand = new SqlCommand("Select * from [tblCMSFields] WHERE [ApplicationId] = 'MyPolicy' and PageId NOT IN ('GeneralMotor', 'MotorHelp', 'AddDriver', 'VehEditHelp')", myConnection);
            SqlDataReader myReader = myCommand.ExecuteReader();

            StreamWriter wr = new StreamWriter("c:\\out.txt", true);

            wr.WriteLine("\n");
            wr.WriteLine("------- Starts of tblCMSFields Insert Script -- ");
            wr.WriteLine("\n");
            string deleteCommand = " DELETE FROM [NUDQuoteAppCMS_SY].[dbo].[tblCMSFields] WHERE [ApplicationId] = '" + ApplicationId + "'";
            wr.WriteLine(deleteCommand);
            wr.WriteLine("\n");
            while (myReader.Read())
            {
                string insertCommand =
                    " INSERT INTO [NUDQuoteAppCMS_SY].[dbo].[tblCMSFields]([ApplicationID],[PageID],[SectionID],[FieldID],[FieldDesc],[FieldOrder],[HasLabel],[HasHelpLink],[HasText],[IsHeading],[IsMessage],[IsHTML]) VALUES ('" + ApplicationId + "','" + myReader[1].ToString().Trim().Replace("'", "''") + "','" + myReader[2].ToString().Trim().Replace("'", "''") + "','" + myReader[3].ToString().Trim().Replace("'", "''") + "','" + myReader[4].ToString().Trim().Replace("'", "''") + "'," + myReader[5].ToString().Trim().Replace("'", "''") + ",'" + myReader[6].ToString().Trim().Replace("'", "''") + "','" + myReader[7].ToString().Trim().Replace("'", "''") + "','" + myReader[8].ToString().Trim().Replace("'", "''") + "','" + myReader[9].ToString().Trim().Replace("'", "''") + "','" + myReader[10].ToString().Trim().Replace("'", "''") + "','" + myReader[11].ToString().Trim().Replace("'", "''") + "');";

                wr.WriteLine(insertCommand);
                Console.WriteLine(insertCommand);
            }
            wr.WriteLine("\n");            
            wr.WriteLine("--------- Ends of tblCMSFields Insert Script -- ");
            wr.Close();
            myReader.Close();
        }

        private static void TblCMSPagesScript(SqlConnection myConnection)
        {
            if (myConnection.State != System.Data.ConnectionState.Open)
            {
                myConnection.Open();
            }

            var myCommand = new SqlCommand("Select * from [tblCMSPages] WHERE [ApplicationId] = 'MyPolicy' and PageId NOT IN ('GeneralMotor', 'MotorHelp', 'AddDriver', 'VehEditHelp')", myConnection);
            SqlDataReader myReader = myCommand.ExecuteReader();

            StreamWriter wr = new StreamWriter("c:\\out.txt", true);

            wr.WriteLine("\n");
            wr.WriteLine("------- Starts of tblCMSPages Insert Script -- ");
            wr.WriteLine("\n");
            string deleteCommand = " DELETE FROM [NUDQuoteAppCMS_SY].[dbo].[tblCMSPages] WHERE [ApplicationId] = '" + ApplicationId + "'";
            wr.WriteLine(deleteCommand);
            wr.WriteLine("\n");
            while (myReader.Read())
            {
                string insertCommand =
                    " INSERT INTO [NUDQuoteAppCMS_SY].[dbo].[tblCMSPages]([ApplicationID],[PageID],[PageDesc],[PageOrder]) VALUES ('" + ApplicationId + "','" + myReader[1].ToString().Trim().Replace("'", "''") + "','" + myReader[2].ToString().Trim().Replace("'", "''") + "'," + myReader[3].ToString().Trim().Replace("'", "''") + ");";

                wr.WriteLine(insertCommand);
                Console.WriteLine(insertCommand);
            }
            wr.WriteLine("\n");
            wr.WriteLine("--------- Ends of tblCMSPages Insert Script -- ");
            wr.Close();
            myReader.Close();
        }

        private static void TblCMSApplicationsScript(SqlConnection myConnection)
        {
            if (myConnection.State != System.Data.ConnectionState.Open)
            {
                myConnection.Open();
            }

            var myCommand = new SqlCommand("Select * from [tblCMSApplications] WHERE [ApplicationId] = 'MyPolicy'", myConnection);
            SqlDataReader myReader = myCommand.ExecuteReader();

            StreamWriter wr = new StreamWriter("c:\\out.txt", true);

            wr.WriteLine("\n");
            wr.WriteLine("------- Starts of tblCMSApplications Insert Script -- ");
            wr.WriteLine("\n");
            string deleteCommand = " DELETE FROM [NUDQuoteAppCMS_SY].[dbo].[tblCMSApplications] WHERE [ApplicationId] = '" + ApplicationId + "'";
            wr.WriteLine(deleteCommand);
            wr.WriteLine("\n");
            while (myReader.Read())
            {
                string insertCommand =
                    " INSERT INTO [NUDQuoteAppCMS_SY].[dbo].[tblCMSApplications]([ApplicationID],[ApplicationDesc]) VALUES ('" + ApplicationId + "','" + myReader[1].ToString().Trim().Replace("'", "''") + "');";

                wr.WriteLine(insertCommand);
                Console.WriteLine(insertCommand);
            }
            wr.WriteLine("\n");
            wr.WriteLine("--------- Ends of tblCMSApplications Insert Script -- ");
            wr.Close();
            myReader.Close();
        }

        private static void SelectDataFromTables()
        {
            StreamWriter wr = new StreamWriter("c:\\out.txt", true);
            wr.WriteLine("\n");
            wr.WriteLine("------- Select statement script  from table -- ");
            wr.WriteLine("\n");
            wr.WriteLine(" SELECT * FROM [NUDQuoteAppCMS_SY].[dbo].[tblFields] WHERE [ApplicationId] = '" + ApplicationId + "'");
            wr.WriteLine(" SELECT * FROM [NUDQuoteAppCMS_SY].[dbo].[tblCMSFields] WHERE [ApplicationId] = '" + ApplicationId + "'");
            wr.WriteLine(" SELECT * FROM [NUDQuoteAppCMS_SY].[dbo].[tblCMSPages] WHERE [ApplicationId] = '" + ApplicationId + "'");
            wr.WriteLine(" SELECT * FROM [NUDQuoteAppCMS_SY].[dbo].[tblCMSSections] WHERE [ApplicationId] = '" + ApplicationId + "'");
            wr.WriteLine(" SELECT * FROM [NUDQuoteAppCMS_SY].[dbo].[tblCMSApplications] WHERE [ApplicationId] = '" + ApplicationId + "'");
            wr.WriteLine("\n");
            wr.WriteLine("--------- Ends of select statements script-- ");
            wr.Close();
        }
    }
}
