using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Administracija.Models
{
    public class User
    {
        public int IDWorker { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Email_address { get; set; }
        public DateTime EmploymentDate { get; set; }
        public string Password { get; set; }
        public int UserLevel { get; set; }

        public User(DataRow row)
        {
            IDWorker = (int)row["IDWorker"];
            First_name = row["FirstName"].ToString();
            Last_name = row["LastName"].ToString();
            Email_address = row["EmailAddress"].ToString();
            EmploymentDate = Convert.ToDateTime(row["EmploymentDate"]);
            UserLevel = (int)row["WorkerLevel"];
        }

        public User()
        {

        }

        public override string ToString() => $"{First_name} {Last_name}";

        public static IList<User> GetAllWorkers() => Repo.AllWorkers();
        public static IList<User> GetAllTeamLeaders() => Repo.AllTeamLeaders();


        public static string New(string firstName, string lastName, string email, string date, string password, string userLevel, string usetTeam)
        {
            
            if (String.IsNullOrEmpty(firstName) || String.IsNullOrEmpty(lastName) || String.IsNullOrEmpty(email) || String.IsNullOrEmpty(date) || String.IsNullOrEmpty(password) || String.IsNullOrEmpty(userLevel))
            {
                return Resources.ApiResponse.stringEmptyError;
            }

            if (Repo.AddNewUser(firstName, lastName, email, date, password, userLevel, usetTeam))
            {
                return new Response(ResponseStatus.Success, Resources.ApiResponse.dataSuccess).ToString();
            }
            else
            {
                return new Response(ResponseStatus.Error, Resources.ApiResponse.dataError).ToString();
            }
        }

        internal static string Edit(string userid, string firstName, string lastName, string email, string userLevel)
        {
            if (String.IsNullOrEmpty(userid) || String.IsNullOrEmpty(firstName) || String.IsNullOrEmpty(lastName) || String.IsNullOrEmpty(email) || String.IsNullOrEmpty(userLevel))
            {
                return Resources.ApiResponse.stringEmptyError;
            }

            if (Repo.EditUser(userid, firstName, lastName, email, userLevel))
            {
                return new Response(ResponseStatus.Success, Resources.ApiResponse.dataSuccess).ToString();
            }
            else
            {
                return new Response(ResponseStatus.Error, Resources.ApiResponse.dataError).ToString();
            }
        }

        internal static string Delete(string userid)
        {
            if (String.IsNullOrEmpty(userid))
            {
                return Resources.ApiResponse.stringEmptyError;
            }

            if (Repo.DeleteUser(userid))
            {
                return new Response(ResponseStatus.Success, Resources.ApiResponse.dataSuccess).ToString();
            }
            else
            {
                return new Response(ResponseStatus.Error, Resources.ApiResponse.dataError).ToString();
            }
        }
    }
}