using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Administracija.Models
{
    public class Client
    {
        public int IDClient { get; set; }
        public string Title { get; set; }

        public Client(DataRow row)
        {
            IDClient = (int)row["IDClient"];
            Title = row["Title"].ToString();
        }

        public Client()
        {

        }

        public override string ToString() => $"{Title}";

        public static IList<Client> GetAll() => Repo.AllClients();

        internal static string New(string title)
        {
            if (String.IsNullOrEmpty(title))
            {
                return Resources.ApiResponse.stringEmptyError;
            }

            if (Repo.AddNewClient(title))
            {
                return new Response(ResponseStatus.Success, Resources.ApiResponse.dataSuccess).ToString();
            }
            else
            {
                return new Response(ResponseStatus.Error, Resources.ApiResponse.dataError).ToString();
            }
        }

        internal static string Edit(string userid, string title)
        {
            if (String.IsNullOrEmpty(userid) || String.IsNullOrEmpty(title))
            {
                return Resources.ApiResponse.stringEmptyError;
            }

            if (Repo.EditClient(userid, title))
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

            if (Repo.DeleteClient(userid))
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