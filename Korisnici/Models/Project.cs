using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Administracija.Models
{
    public class Project
    {
        public int IDProject { get; set; }
        public string Title { get; set; }
        public Client Client { get; set; }
        public User TeamLeader { get; set; }

        public Project(DataRow row)
        {
            Client tempClient = new Client();
            User tempTeamLeader = new User();

            tempClient.Title = row["Client"].ToString();
            tempTeamLeader.First_name = row["TeamLeaderFirstName"].ToString();
            tempTeamLeader.Last_name = row["TeamLeaderLastName"].ToString();

            IDProject = (int)row["IDProject"];
            Title = row["Title"].ToString();
            Client = tempClient;
            TeamLeader = tempTeamLeader;

        }

        public Project()
        {

        }

        public static IList<Project> GetAll() => Repo.AllProjects();

        internal static string New(string title, int clientID, int teamLeaderID)
        {
            if (String.IsNullOrEmpty(title))
            {
                return Resources.ApiResponse.stringEmptyError;
            }

            if (Repo.AddNewProject(title, clientID, teamLeaderID))
            {
                return new Response(ResponseStatus.Success, Resources.ApiResponse.dataSuccess).ToString();
            }
            else
            {
                return new Response(ResponseStatus.Error, Resources.ApiResponse.dataError).ToString();
            }
        }

        public static IList<Project> GetAllByPersonID(int iDWorker) => Repo.GetAllProjectByPersonID(iDWorker);



        internal static string RemoveUser(string userid)
        {
            if (String.IsNullOrEmpty(userid))
            {
                return Resources.ApiResponse.stringEmptyError;
            }

            if (Repo.RemoveUserFromProject(userid))
            {
                return new Response(ResponseStatus.Success, Resources.ApiResponse.dataSuccess).ToString();
            }
            else
            {
                return new Response(ResponseStatus.Error, Resources.ApiResponse.dataError).ToString();
            }
        }

        internal static string Edit(int projectID, string title)
        {
            if (String.IsNullOrEmpty(title))
            {
                return Resources.ApiResponse.stringEmptyError;
            }

            if (Repo.EditProject(projectID, title))
            {
                return new Response(ResponseStatus.Success, Resources.ApiResponse.dataSuccess).ToString();
            }
            else
            {
                return new Response(ResponseStatus.Error, Resources.ApiResponse.dataError).ToString();
            }
        }

        internal static string AssignUser(int projectID, int userID)
        {

            if (Repo.AssignWorkerToProject(projectID, userID))
            {
                return new Response(ResponseStatus.Success, Resources.ApiResponse.dataSuccess).ToString();
            }
            else
            {
                return new Response(ResponseStatus.Error, Resources.ApiResponse.dataError).ToString();
            }
        }

        internal static string Delete(string projectID)
        {
            if (String.IsNullOrEmpty(projectID))
            {
                return Resources.ApiResponse.stringEmptyError;
            }

            if (Repo.DeleteProject(projectID))
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