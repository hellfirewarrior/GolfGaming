using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;

namespace GolfGamingBL
{

    public enum GolfersByIndex { Phoebe, Mike, Emma, Sam, Misaki, Brad, Chaos, Regis, Maya, Falcon, Renee, Z, Mel, Allan, Tiffany, Kamala, Toni, TBone, Lin, Louise, Zeus,Hubert,Ratchet,Jak}

    public enum GolfCoursesByIndex { Mount_Sakura, Mount_Sakura_BT, Aloha_Beach, Aloha_Beach_BT, Western_Valley,Western_Valley_BT, Bap_Pipe_Classic, Bap_Pipe_Classic_BT, United_Forest, United_Forest_BT, Northern_Fox, Northern_Fox_BT, Day_Dream, Day_Dream_BT, Wild_Green, Wild_Green_BT, Silk_Road_Classic, Silk_Road_Classic_BT, Blue_Lagoon, Blue_Lagoon_BT, Fujizakura, Fujizakura_BT, Kawana_Hotel, Kawana_Hotel_BT
                                      }

    public class GolfRepository
    {
        private List<Golfer> tempGolfers;  //while not using DB store-- populate these in constructor
        private List<GolfCourse> tempGolfCourses; 
        private string connectionString;
        public GolfersByIndex[] GolfersIds = (GolfersByIndex[]) Enum.GetValues(typeof(GolfersByIndex));
        public GolfCoursesByIndex[] GolfCoursesIds = (GolfCoursesByIndex[])Enum.GetValues(typeof(GolfCoursesByIndex));

        public static int CountOfGolfers = 24;
        public static int CountOfGolfCourses = 24;
 
        public List<Golfer> SeasonRoster {
            get
            {
                return tempGolfers;
            }
                
            private set
            {
                ; //not sure what to put here!  no way to set value!
            }
        }

        public GolfersByIndex SetCurrentGolferToNext(GolfersByIndex NewCurrentGolferId)
        {
            GolfersByIndex tempGolferIndex;
            //BUSINESS LOGIC:  Repository will ONLY operate on the most current season-- until this is amended, later.

            //  connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;; Data Source =C:\\Golfer_ACCESSDB\\Golfer.accdb;Persist Security Info=False; ";
            //connectionString = "MS_TableConnectionString";
#if DEVELOPMENT
            connectionString = "Data Source=tcp:matstrolia.database.windows.net,1433;Initial Catalog=WalkingDB;User ID=matstrolia;Password=FakePasswordHere"; //
#else
            connectionString = @Environment.GetEnvironmentVariable("SQLAZURECONNSTR_MS_TableConnectionString");
#endif

            // Provide the query string with a parameter placeholder.
            string queryString =
            //       "SELECT Season.CurrentGolfer FROM Season where ID = (select max(ID) from Season); ";
            "UPDATE GolfSeason SET GolfSeason.CurrentGolferId = " + ((int) NewCurrentGolferId).ToString() + " where ID = (select max(ID) from GolfSeason); ";
            
            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            //using (OleDbConnection connection =
            //    new OleDbConnection(connectionString))

            using (SqlConnection connection =
                  new SqlConnection(connectionString))
            {

                // Open the connection in a try/catch block. 
                // Create and execute the DataReader, writing the result
                // set to the console window.
                tempGolferIndex = 0;
                try
                {
                    connection.Open();
                                                          //                    OleDbCommand oLecommand = new OleDbCommand(queryString, connection);
                    SqlCommand sqlCommand = new SqlCommand(queryString, connection);

                    sqlCommand.ExecuteNonQuery();  //oLecommand
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return tempGolferIndex;
            }
        }

        public GolfCoursesByIndex SetCurrentGolfCourseToNext(GolfCoursesByIndex NewCurrentGolfCourseId)
        {
            GolfCoursesByIndex tempGolfCourseIndex;
            //BUSINESS LOGIC:  Repository will ONLY operate on the most current season-- until this is amended, later.

            //  connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;; Data Source =C:\\Golfer_ACCESSDB\\Golfer.accdb;Persist Security Info=False; ";
            //connectionString = "MS_TableConnectionString";
#if DEVELOPMENT
            connectionString = "Data Source=tcp:matstrolia.database.windows.net,1433;Initial Catalog=WalkingDB;User ID=matstrolia;Password=FakePasswordHere"; //
#else
            connectionString = @Environment.GetEnvironmentVariable("SQLAZURECONNSTR_MS_TableConnectionString");
#endif

            // Provide the query string with a parameter placeholder.
            string queryString =
            //       "SELECT Season.CurrentGolfer FROM Season where ID = (select max(ID) from Season); ";
            "UPDATE GolfSeason SET GolfSeason.CurrentGolfCourseId = " + ((int)NewCurrentGolfCourseId).ToString() + " where ID = (select max(ID) from GolfSeason); ";

            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            //using (OleDbConnection connection =
            //    new OleDbConnection(connectionString))

            using (SqlConnection connection =
                  new SqlConnection(connectionString))
            {

                // Open the connection in a try/catch block. 
                // Create and execute the DataReader, writing the result
                // set to the console window.
                tempGolfCourseIndex = 0;
                try
                {
                    connection.Open();
                    //                    OleDbCommand oLecommand = new OleDbCommand(queryString, connection);
                    SqlCommand sqlCommand = new SqlCommand(queryString, connection);

                    sqlCommand.ExecuteNonQuery();  //oLecommand

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return tempGolfCourseIndex;
            }
        }

        public GolfCoursesByIndex RetrieveCurrentGolfCourseID()
        {
            GolfCoursesByIndex tempGolfCoursesIndex;
            //BUSINESS LOGIC:  Repository will ONLY operate on the most current season-- until this is amended, later.

            //  connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;; Data Source =C:\\Golfer_ACCESSDB\\Golfer.accdb;Persist Security Info=False; ";
            //connectionString = "MS_TableConnectionString";
#if DEVELOPMENT
            connectionString = "Data Source=tcp:matstrolia.database.windows.net,1433;Initial Catalog=WalkingDB;User ID=matstrolia;Password=FakePasswordHere"; //
#else
            connectionString = @Environment.GetEnvironmentVariable("SQLAZURECONNSTR_MS_TableConnectionString");
#endif

            // Provide the query string with a parameter placeholder.
            string queryString =
            //       "SELECT Season.CurrentGolfer FROM Season where ID = (select max(ID) from Season); ";
            "SELECT GolfSeason.CurrentGolfCourseId FROM GolfSeason where ID = (select max(ID) from GolfSeason); ";

            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            //using (OleDbConnection connection =
            //    new OleDbConnection(connectionString))

            using (SqlConnection connection =
                  new SqlConnection(connectionString))
            {

                // Open the connection in a try/catch block. 
                // Create and execute the DataReader, writing the result
                // set to the console window.
                tempGolfCoursesIndex = 0;
                try
                {
                    connection.Open();

                    DataSet myDataSet = new DataSet();
                    var myAdaptor = new SqlDataAdapter(); // OleDbDataAdapter();
//                    OleDbCommand oLecommand = new OleDbCommand(queryString, connection);
                    SqlCommand sqlCommand = new SqlCommand(queryString, connection);

                    myAdaptor.SelectCommand = sqlCommand;  //oLecommand
                    myAdaptor.Fill(myDataSet, "GolfSeason");



                    if (myDataSet.Tables[0].Rows[0]["currentGolfCourseId"] != DBNull.Value)    //currentGolfer
                    {
                        tempGolfCoursesIndex = ((int)myDataSet.Tables[0].Rows[0]["currentGolfCourseId"] < CountOfGolfCourses) ? (GolfCoursesByIndex)myDataSet.Tables[0].Rows[0]["currentGolfCourseId"] : 0;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return tempGolfCoursesIndex;
            }

        }

        public GolfersByIndex RetrieveCurrentGolferID()
        {
            GolfersByIndex tempGolferIndex;
            //BUSINESS LOGIC:  Repository will ONLY operate on the most current season-- until this is amended, later.

            //  connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;; Data Source =C:\\Golfer_ACCESSDB\\Golfer.accdb;Persist Security Info=False; ";
            //connectionString = "MS_TableConnectionString";
#if DEVELOPMENT
            connectionString = "Data Source=tcp:matstrolia.database.windows.net,1433;Initial Catalog=WalkingDB;User ID=matstrolia;Password=FakePasswordHere"; //
#else
            connectionString = @Environment.GetEnvironmentVariable("SQLAZURECONNSTR_MS_TableConnectionString");
#endif

            // Provide the query string with a parameter placeholder.
            string queryString =
            //       "SELECT Season.CurrentGolfer FROM Season where ID = (select max(ID) from Season); ";
            "SELECT GolfSeason.CurrentGolferId FROM GolfSeason where ID = (select max(ID) from GolfSeason); ";

            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            //using (OleDbConnection connection =
            //    new OleDbConnection(connectionString))

            using (SqlConnection connection =
                  new SqlConnection(connectionString))
            {

                // Open the connection in a try/catch block. 
                // Create and execute the DataReader, writing the result
                // set to the console window.
                tempGolferIndex = 0;
                try
                {
                    connection.Open();

                    DataSet myDataSet = new DataSet();
                    var myAdaptor = new SqlDataAdapter(); // OleDbDataAdapter();
                                                          //                    OleDbCommand oLecommand = new OleDbCommand(queryString, connection);
                    SqlCommand sqlCommand = new SqlCommand(queryString, connection);

                    myAdaptor.SelectCommand = sqlCommand;  //oLecommand
                    myAdaptor.Fill(myDataSet, "GolfSeason");



                    if (myDataSet.Tables[0].Rows[0]["currentGolferId"] != DBNull.Value)    //currentGolfCourse
                    {
                        tempGolferIndex = ((int)myDataSet.Tables[0].Rows[0]["currentGolferId"] < CountOfGolfers) ? (GolfersByIndex)myDataSet.Tables[0].Rows[0]["currentGolferId"] : 0;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return tempGolferIndex;
            }

        }

        public List<GolfCourse> RetrieveCourses()
        {
            if (tempGolfCourses == null)
            {
                tempGolfCourses = new List<GolfCourse>();
                tempGolfCourses.Add(new GolfCourse() { Name = "Mount_Sakura", SeasonClosedDate = DateTime.MaxValue });   //e.g.  new DateTime(2018, 02, 28)
                tempGolfCourses.Add(new GolfCourse() { Name = "Mount_Sakura_BT", SeasonClosedDate = DateTime.MaxValue });
                tempGolfCourses.Add(new GolfCourse() { Name = "Aloha_Beach", SeasonClosedDate = DateTime.MaxValue });
                tempGolfCourses.Add(new GolfCourse() { Name = "Aloha_Beach_BT", SeasonClosedDate = DateTime.MaxValue });
                tempGolfCourses.Add(new GolfCourse() { Name = "Western_Valley", SeasonClosedDate = DateTime.MaxValue });
                tempGolfCourses.Add(new GolfCourse() { Name = "Western_Valley_BT", SeasonClosedDate = DateTime.MaxValue });
                tempGolfCourses.Add(new GolfCourse() { Name = "Bap_Pipe_Classic", SeasonClosedDate = DateTime.MaxValue });
                tempGolfCourses.Add(new GolfCourse() { Name = "Bap_Pipe_Classic_BT", SeasonClosedDate = DateTime.MaxValue });
                tempGolfCourses.Add(new GolfCourse() { Name = "United_Forest", SeasonClosedDate = DateTime.MaxValue });
                tempGolfCourses.Add(new GolfCourse() { Name = "United_Forest_BT", SeasonClosedDate = DateTime.MaxValue });
                tempGolfCourses.Add(new GolfCourse() { Name = "Northern_Fox", SeasonClosedDate = DateTime.MaxValue });
                tempGolfCourses.Add(new GolfCourse() { Name = "Northern_Fox_BT", SeasonClosedDate = DateTime.MaxValue });
                tempGolfCourses.Add(new GolfCourse() { Name = "Day_Dream", SeasonClosedDate = DateTime.MaxValue });
                tempGolfCourses.Add(new GolfCourse() { Name = "Day_Dream_BT", SeasonClosedDate = DateTime.MaxValue });
                tempGolfCourses.Add(new GolfCourse() { Name = "Wild_Green", SeasonClosedDate = DateTime.MaxValue });
                tempGolfCourses.Add(new GolfCourse() { Name = "Wild_Green_BT", SeasonClosedDate = DateTime.MaxValue });
                tempGolfCourses.Add(new GolfCourse() { Name = "Silk_Road_Classic", SeasonClosedDate = DateTime.MaxValue });
                tempGolfCourses.Add(new GolfCourse() { Name = "Silk_Road_Classic_BT", SeasonClosedDate = DateTime.MaxValue });
                tempGolfCourses.Add(new GolfCourse() { Name = "Blue_Lagoon", SeasonClosedDate = DateTime.MaxValue });
                tempGolfCourses.Add(new GolfCourse() { Name = "Blue_Lagoon_BT", SeasonClosedDate = DateTime.MaxValue });
                tempGolfCourses.Add(new GolfCourse() { Name = "Fujizakura", SeasonClosedDate = DateTime.MaxValue });
                tempGolfCourses.Add(new GolfCourse() { Name = "Fujizakura_BT", SeasonClosedDate = DateTime.MaxValue });
                tempGolfCourses.Add(new GolfCourse() { Name = "Kawana_Hotel", SeasonClosedDate = DateTime.MaxValue });
                tempGolfCourses.Add(new GolfCourse() { Name = "Kawana_Hotel_BT", SeasonClosedDate = DateTime.MaxValue });

                Console.WriteLine(tempGolfers);
            }

            return tempGolfCourses;

        }

        public List<Golfer> Retrieve()
        {
            if (tempGolfers == null)
            {
                tempGolfers = new List<Golfer>();

                tempGolfers.Add(new Golfer() { Name = "Phoebe", SeasonRetiredDate = DateTime.MaxValue });
                tempGolfers.Add(new Golfer() { Name = "Mike", SeasonRetiredDate = DateTime.MaxValue });
                tempGolfers.Add(new Golfer() { Name = "Emma", SeasonRetiredDate = DateTime.MaxValue });
                tempGolfers.Add(new Golfer() { Name = "Sam", SeasonRetiredDate = DateTime.MaxValue });
                tempGolfers.Add(new Golfer() { Name = "Misaki", SeasonRetiredDate = DateTime.MaxValue });
                tempGolfers.Add(new Golfer() { Name = "Brad", SeasonRetiredDate = DateTime.MaxValue });
                tempGolfers.Add(new Golfer() { Name = "Chaos", SeasonRetiredDate = DateTime.MaxValue });
                tempGolfers.Add(new Golfer() { Name = "Regis", SeasonRetiredDate = DateTime.MaxValue });
                tempGolfers.Add(new Golfer() { Name = "Maya", SeasonRetiredDate = DateTime.MaxValue });
                tempGolfers.Add(new Golfer() { Name = "Falcon", SeasonRetiredDate = DateTime.MaxValue });
                tempGolfers.Add(new Golfer() { Name = "Renee", SeasonRetiredDate = DateTime.MaxValue });
                tempGolfers.Add(new Golfer() { Name = "Z", SeasonRetiredDate = DateTime.MaxValue });
                tempGolfers.Add(new Golfer() { Name = "Mel", SeasonRetiredDate = DateTime.MaxValue });
                tempGolfers.Add(new Golfer() { Name = "Allan", SeasonRetiredDate = DateTime.MaxValue });
                tempGolfers.Add(new Golfer() { Name = "Tiffany", SeasonRetiredDate = DateTime.MaxValue });
                tempGolfers.Add(new Golfer() { Name = "Kamala", SeasonRetiredDate = DateTime.MaxValue });
                tempGolfers.Add(new Golfer() { Name = "Toni", SeasonRetiredDate = DateTime.MaxValue });
                tempGolfers.Add(new Golfer() { Name = "T-Bone", SeasonRetiredDate = DateTime.MaxValue });
                tempGolfers.Add(new Golfer() { Name = "Lin", SeasonRetiredDate = DateTime.MaxValue });
                tempGolfers.Add(new Golfer() { Name = "Louise", SeasonRetiredDate = DateTime.MaxValue });
                tempGolfers.Add(new Golfer() { Name = "Zeus", SeasonRetiredDate = DateTime.MaxValue });
                tempGolfers.Add(new Golfer() { Name = "Hubert", SeasonRetiredDate = DateTime.MaxValue });
                tempGolfers.Add(new Golfer() { Name = "Ratchet", SeasonRetiredDate = DateTime.MaxValue });
                tempGolfers.Add(new Golfer() { Name = "Jak", SeasonRetiredDate = DateTime.MaxValue });

                Console.WriteLine(tempGolfers);
            }

            return tempGolfers;
        }


    }
}
