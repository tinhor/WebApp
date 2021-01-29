using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;
using Microsoft.Ajax.Utilities;

namespace Administracija.Models
{
    public class Processes
    {
        public static string SHA512(string input)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);
                var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }
        }

        public static string Log_in (string email, string password)
        {   
            var inputEmail = email;
            var inputPassword = SHA512(password);

            if (Repo.CheckLogin(inputEmail, inputPassword))
            {
                Set_session(inputEmail, inputPassword);
                return new Response("Dashboard").Redirect();
            } else
            {
                return new Response(ResponseStatus.Error, Resources.ApiResponse.errorLogin).ToString();
            }
        }

        public static void Set_session(string email, string password)
        {
            DataTable user = Repo.UserLogin(email, password);
            ActiveSession.Current.ActiveUser = new User(user.Rows[0]);
        }

        public static void Check_login()
        {
            if(ActiveSession.Current.ActiveUser != null)
            {
                HttpContext.Current.Response.Redirect("Dashboard");
            }
        }

        public static void Check_status()
        {
            if (ActiveSession.Current.ActiveUser == null)
            {
                HttpContext.Current.Response.Redirect("/");
            }
        }
    }
}