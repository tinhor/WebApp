using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Administracija.Models
{
    public class Response
    {
        private ResponseStatus Status { get; set; }
        private string Content { get; set; }
        private string GeneratedMessage { get; set; }

        public Response(string site)
        {
            Content = site;
        }

        public Response(ResponseStatus status, string message)
        {
            Status = status;
            Content = message;
            
            if(Status == ResponseStatus.Success)
            {
                GeneratedMessage += "<div class='alert alert-success' role='alert'>";
            } else if(Status == ResponseStatus.Warning)
            {
                GeneratedMessage += "<div class='alert alert-warning' role='alert'>";
            } else
            {
                GeneratedMessage += "<div class='alert alert-danger' role='alert'>";
            }

            GeneratedMessage += Content;
            GeneratedMessage += "</div>";
        }

        public string Redirect()
        {
            HttpContext.Current.Response.Redirect(Content);
            return "Success";
        }

        public override string ToString() => GeneratedMessage;
    }
}