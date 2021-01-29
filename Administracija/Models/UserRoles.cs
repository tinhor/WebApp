using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Administracija.Models
{
    public static class UserRoles
    {
        public static Dictionary<int, string> State = new Dictionary<int, string>() {
            {1, Resources.ApiResponse.fullTimeWorker },
            {2, Resources.ApiResponse.partTimeWorker },
            {3, Resources.ApiResponse.studentWorker },
            {4, Resources.ApiResponse.teamLeaderWorker },
            {5, Resources.ApiResponse.executiveWorker }
        };


    }
}