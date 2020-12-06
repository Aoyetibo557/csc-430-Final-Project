using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Web.Security;

namespace BMI_Web_API__ASP.NET_FRAMEWORK_
{
    public partial class Dashboard : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|BmiDB.mdf;Integrated Security=True;MultipleActiveResultSets=true;");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();

            retrieveAccountData();
            loadFriendList();

            //To prevent page from going back to dashboard after logout
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
        }

        public void retrieveAccountData()
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["UsernameValue"] != null && Request.QueryString["UsernameValue"] != string.Empty)
                {
                    usernameTextBox.Text = Request.QueryString["UsernameValue"];
                    SqlDataReader rdr = null;
                    //Query DB FOR THE ACCOUNT INFORMATION
                    using (SqlCommand accountCommand = new SqlCommand("SELECT firstname, lastname, height, weight, BMI, BMI_goal from userAccounts where username like @username", conn))
                    {
                        //To prevent SQL Injections
                        SqlParameter username_param = accountCommand.Parameters.Add("@username", SqlDbType.Text, 100);
                        username_param.Value = Request.QueryString["UsernameValue"];

                        accountCommand.Prepare();

                        SqlDataAdapter da = new SqlDataAdapter(accountCommand);
                        DataTable ds = new DataTable();
                        da.Fill(ds);

                        rdr = accountCommand.ExecuteReader();

                        foreach (DataRow row in ds.Rows)
                        {
                            string firstname = row["firstname"].ToString();
                            string lastname = row["lastname"].ToString();
                            fullnameTextBox.Text = firstname + " " + lastname;
                            string newHeight = row["height"].ToString();
                            heightTextBox.Text = newHeight + "CM";

                            string newWeight = row["weight"].ToString();
                            weightTextBox.Text = newWeight + "LB";

                            string newBmi = row["BMI"].ToString();
                            bmiTextBox.Text = newBmi;

                            string newGaol_Bmi = row["BMI_goal"].ToString();
                            goalBmiTextBox.Text = newGaol_Bmi;
                        }

                        //Show date
                        getDate();
                        //Other Functions
                        other_funcs();


                    }

                }


            }
        }

        public void getDate()
        {
            string[] dayArr = { "MON", "TUES", "WED", "THUR", "FRI", "SAT", "SUN" };
            string[] monthArr = { "JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC" };

            //Print Current Date Time
            DateTime dateTime = DateTime.UtcNow.Date;
            int day = dateTime.Day;
            int month = dateTime.Month;
            int yr = dateTime.Year;

            //dateTimeLabel.Text = day + " " + month + " " + yr;
            //dateTimeLabel.Text = monthArr[month-1] + " - " + dayArr[day-1] + " - " + yr;
            dayTextBox.Text = dayArr[day];
            monthTextBox.Text = monthArr[month - 1] + " " + day.ToString();
            yearTextBox.Text = yr.ToString();
            timeTextBox.Text = dateTime.ToString("h:mm:ss tt");
        }

        public void other_funcs()
        {
            int n;
            n = new Random().Next(1000, 5000);
            stepsTextBox.Text = n.ToString() + " Total Steps";

            int lvl;
            lvl = new Random().Next(1, 10);
            levelTextBox.Text = "Level " + lvl.ToString();
        }

        protected void logoutMethod(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                Session.Clear();
                Session.Remove("UsernameValue");
                Request.Cookies.Clear();
                FormsAuthentication.SignOut();
                Response.Redirect("~/Login.aspx", true);
            }


        }


        protected void findFriendMethod(object sender, EventArgs e)
        {

            using (SqlCommand findFriendCommand = new SqlCommand("SELECT user_d, firstname, lastname, BMI, BMI_goal from userAccounts where username like @username", conn))
            {
                SqlParameter friendname_param = findFriendCommand.Parameters.Add("@username", SqlDbType.Text, 100);
                friendname_param.Value = friendUsernameTextBox.Text;

                findFriendCommand.Prepare();


                SqlDataAdapter friendList = new SqlDataAdapter(findFriendCommand);
                DataTable friendListTable = new DataTable();
                friendList.Fill(friendListTable);

                //testGridView.DataSource = friendListTable;
                //testGridView.DataBind();


                foreach (DataRow row in friendListTable.Rows)
                {
                    string id = row["user_d"].ToString();
                    //userIdLable.Text = id;

                    ///insert user_id into friend list with a delimeter
                    insertNewFriend(id);
                }

                friendUsernameTextBox.Text = "";
            }

            loadFriendList();

        }


        private void insertNewFriend(string _id)
        {
            try
            {
                using (SqlCommand insertFriendCommand = new SqlCommand("UPDATE userAccounts SET friendList = friendList + ':' + CONVERT(VARCHAR, @friend_list) WHERE username like @username", conn))
                {

                    SqlParameter insertId_param = insertFriendCommand.Parameters.Add("@friend_list", SqlDbType.Text, 100);
                    insertId_param.Value = _id;

                    SqlParameter user_param = insertFriendCommand.Parameters.Add("@username", SqlDbType.Text, 100);
                    user_param.Value = Request.QueryString["UsernameValue"];

                    insertFriendCommand.Prepare();
                    insertFriendCommand.ExecuteNonQuery();
                }
                alertLabel.Text = "New Friend Added";
            }
            catch (Exception)
            {
                alertLabel.Text = "Error Adding Friend";
            }
        }


        private void loadFriendList()
        {
            using (SqlCommand loadFriendListCommand = new SqlCommand("SELECT friendList FROM userAccounts WHERE username like @username", conn))
            {

                SqlParameter user_param = loadFriendListCommand.Parameters.Add("@username", SqlDbType.Text, 100);
                user_param.Value = Request.QueryString["UsernameValue"];

                loadFriendListCommand.Prepare();

                SqlDataAdapter user_friendList = new SqlDataAdapter(loadFriendListCommand);
                DataTable user_friendListTable = new DataTable();
                user_friendList.Fill(user_friendListTable);

                
                DataTable friend_Table = new DataTable();

                foreach (DataRow row in user_friendListTable.Rows)
                {
                    string ls = row["friendList"].ToString();
                    string[] nl = ls.Split(':');

                    //remove duplicate in the array
                    string[] dist = nl.Distinct().ToArray();
                    int len = dist.Length - 1;

                    //Loop to print out all the friends in the DB
                    for(int i = 1; i <= len ; i++)
                    {
                        //Converting to int
                        int temp = Int32.Parse(dist[i]);
                        using (SqlCommand loadTableCommand = new SqlCommand("SELECT firstname, lastname, BMI, BMI_goal FROM userAccounts WHERE user_d = @userId ", conn))
                        {

                            SqlParameter user_ID_param = loadTableCommand.Parameters.Add("@userId", SqlDbType.Int, 100);
                            user_ID_param.Value = temp;

                            loadTableCommand.Prepare();

                            SqlDataAdapter fList = new SqlDataAdapter(loadTableCommand);

                            fList.Fill(friend_Table);

                            test1GridView.DataSource = friend_Table;
                            test1GridView.DataBind();

                        }
                    }

                
                }

            }
        }
    }
}