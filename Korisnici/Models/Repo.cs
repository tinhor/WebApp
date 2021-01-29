using Microsoft.ApplicationBlocks.Data;
using Korisnici.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace Administracija.Models
{
    public class Repo
    {
        private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        public static DataTable UserLogin(string email, string password) => SqlHelper.ExecuteDataset(cs, "CheckLogin", email, password).Tables[0];

        public static User GetUser(int id) => new User(SqlHelper.ExecuteDataset(cs, "GetWorker", id).Tables[0].Rows[0]);

        internal static IList<Tracker> AllHoursByStatusID(int statusID)
        {
            IList<Tracker> allHours = new List<Tracker>();
            var tblHours = SqlHelper.ExecuteDataset(cs, "AllHoursByStatusID", statusID).Tables[0];

            foreach (DataRow row in tblHours.Rows)
            {
                allHours.Add(new Tracker(row));
            }

            return allHours;
        }

        public static Project GetProject(int id) => new Project(SqlHelper.ExecuteDataset(cs, "GetProject", id).Tables[0].Rows[0]);

        internal static User WorkerByID(int id)
        {
            User tempPerson = new User();
            try
            {
                tempPerson = new User(SqlHelper.ExecuteDataset(cs, "GetWorkerByID", id).Tables[0].Rows[0]);
            }
            catch (Exception)
            {

            }

            return tempPerson;
        }

        internal static IList<Hour> AllHours()
        {
            IList<Hour> allHours = new List<Hour>();
            var tblHours = SqlHelper.ExecuteDataset(cs, "GetHours").Tables[0];

            foreach (DataRow row in tblHours.Rows)
            {
                allHours.Add(new Hour(row));
            }

            return allHours;
        }

        internal static bool UpdateHours(Hour item)
        {
            var value = SqlHelper.ExecuteNonQuery(cs, "UpdateHours", item.Date.ToString("yyyy-MM-dd"), item.Person.IDWorker, item.Project.IDProject, item.Worktime.ToString(), item.Overtime.ToString(), item.Status);

            if (value != -1)
                return true;

            return false;
        }

        internal static IList<Hour> AllHoursByUserID()
        {
            IList<Hour> allHours = new List<Hour>();
            var tblHours = SqlHelper.ExecuteDataset(cs, "AllHoursByUserID", Administracija.Models.ActiveSession.Current.ActiveUser.IDWorker).Tables[0];

            foreach (DataRow row in tblHours.Rows)
            {
                allHours.Add(new Hour(row));
            }

            return allHours;
        }

        internal static IList<Hour> AllHoursByDate(string date, int userID, string v)
        {
            IList<Hour> allHours = new List<Hour>();
            var tblHours = SqlHelper.ExecuteDataset(cs, "AllHoursByDate", date, userID, v).Tables[0];

            foreach (DataRow row in tblHours.Rows)
            {
                allHours.Add(new Hour(row));
            }

            return allHours;
        }

 
        internal static Client GetClient(int id) => new Client(SqlHelper.ExecuteDataset(cs, "GetClient", id).Tables[0].Rows[0]);

        internal static IList<Project> GetAllProjectByPersonID(int iDWorker)
        {
            IList<Project> allProject = new List<Project>();
            var tblProject = SqlHelper.ExecuteDataset(cs, "GetAllProjectByPersonID", iDWorker).Tables[0];

            foreach (DataRow row in tblProject.Rows)
            {
                allProject.Add(new Project(row));
            }

            return allProject;
        }

        public static bool CheckLogin(string email, string password) => UserLogin(email, password).Rows.Count == 0 ? false : true;
        internal static IList<Team> AllTeams()
        {
            IList<Team> allTeams = new List<Team>();
            var tblTeams = SqlHelper.ExecuteDataset(cs, "GetTeams").Tables[0];

            foreach (DataRow row in tblTeams.Rows)
            {
                allTeams.Add(new Team(row));
            }

            return allTeams;
        }

        internal static IList<User> AllUsersOnProject(int projectID)
        {
            IList<User> workerList = new List<User>();
            var tblWorkers = SqlHelper.ExecuteDataset(cs, "GetWorkersByProject", projectID).Tables[0];

            foreach (DataRow row in tblWorkers.Rows)
            {
                workerList.Add(new User(row));
            }

            return workerList;
        }

        public static bool AddNewUser(string firstName, string lastName, string email, string date, string password, string userLevel, string usetTeam)
        {

            var value = SqlHelper.ExecuteNonQuery(cs, "AddNewWorker", firstName, lastName, email, date, password, int.Parse(userLevel), int.Parse(usetTeam));
            if (value != -1)
                return true;

            return false;
        }

        internal static bool AddNewProject(string title, int clientID, int teamLeaderID)
        {
            var value = SqlHelper.ExecuteNonQuery(cs, "AddNewProject", title, clientID, teamLeaderID);
            if (value != -1)
                return true;

            return false;
        }

        internal static bool RemoveUserFromProject(string userid)
        {
            var value = SqlHelper.ExecuteNonQuery(cs, "RemoveUserFromProject", int.Parse(userid));
            if (value != -1)
                return true;

            return false;
        }

        internal static bool AddNewClient(string title)
        {
            var value = SqlHelper.ExecuteNonQuery(cs, "AddNewClient", title);
            if (value != -1)
                return true;

            return false;
        }

        internal static bool AssignWorkerToProject(int projectID, int userID)
        {
            var value = SqlHelper.ExecuteNonQuery(cs, "AssignWorkerToProject", projectID, userID);
            if (value != -1)
                return true;

            return false;
        }

        internal static bool EditProject(int projectID, string title)
        {
            var value = SqlHelper.ExecuteNonQuery(cs, "EditProject", projectID, title);
            if (value != -1)
                return true;

            return false;
        }

        internal static bool EditClient(string userid, string title)
        {
            var value = SqlHelper.ExecuteNonQuery(cs, "EditClient", int.Parse(userid), title);
            if (value != -1)
                return true;

            return false;
        }

        internal static bool DeleteClient(string userid)
        {
            var value = SqlHelper.ExecuteNonQuery(cs, "DeleteClient", int.Parse(userid));
            if (value != -1)
                return true;

            return false;
        }

        internal static bool DeleteProject(string projectID)
        {
            var value = SqlHelper.ExecuteNonQuery(cs, "DeleteProject", int.Parse(projectID));
            if (value != -1)
                return true;

            return false;
        }

        internal static IList<Client> AllClients()
        {
            IList<Client> clientList = new List<Client>();
            var tblClients = SqlHelper.ExecuteDataset(cs, "GetClients").Tables[0];

            foreach (DataRow row in tblClients.Rows)
            {
                clientList.Add(new Client(row));
            }

            return clientList;
        }        
        
        internal static IList<Project> AllProjects()
        {
            IList<Project> projectList = new List<Project>();
            var tblProjects = SqlHelper.ExecuteDataset(cs, "GetProjects").Tables[0];

            foreach (DataRow row in tblProjects.Rows)
            {
                projectList.Add(new Project(row));
            }

            return projectList;
        }

        internal static IList<User> AllTeamLeaders()
        {
            IList<User> workerList = new List<User>();
            var tblWorkers = SqlHelper.ExecuteDataset(cs, "GetTeamLeaders").Tables[0];

            foreach (DataRow row in tblWorkers.Rows)
            {
                workerList.Add(new User(row));
            }

            return workerList;
        }

        public static IList<User> AllWorkers()
        {
            IList<User> workerList = new List<User>();
            var tblWorkers = SqlHelper.ExecuteDataset(cs, "GetWorkers").Tables[0];

            foreach (DataRow row in tblWorkers.Rows)
            {
                workerList.Add(new User(row));
            }

            return workerList;
        }

        public static IList<User> AllWorkersNotAssignedToProject(int projectID)
        {
            IList<User> workerList = new List<User>();
            var tblWorkers = SqlHelper.ExecuteDataset(cs, "GetWorkersNotAssignedToProject", projectID).Tables[0];

            foreach (DataRow row in tblWorkers.Rows)
            {
                workerList.Add(new User(row));
            }

            return workerList;
        }

        internal static bool EditUser(string userid, string firstName, string lastName, string email, string userLevel)
        {
            var value = SqlHelper.ExecuteNonQuery(cs, "EditWorker", int.Parse(userid), firstName, lastName, email, int.Parse(userLevel));
            if (value != -1)
                return true;

            return false;
        }

        internal static bool DeleteUser(string userid)
        {
            var value = SqlHelper.ExecuteNonQuery(cs, "DeleteWorker", int.Parse(userid));
            if (value != -1)
                return true;

            return false;
        }
    }
}