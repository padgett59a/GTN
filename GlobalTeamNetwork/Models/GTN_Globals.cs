using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using GlobalTeamNetwork.Data;


namespace GlobalTeamNetwork.Models
{

    
    public static class GTN_Globals
    {
        public const int CUSTOMERTYPE = 1;
        public const int ADMINTYPE = 2;
        public const int TRANSLATORTYPE = 3;
        public const int MASTERERTYPE = 4;
        public const int ARCHIVERTYPE = 5;
        public const int INSTRUCTORTYPE = 6;
        public static Int16 NotesCharCount = 50;
    }

    public static class GTN_SQL_ERR
    {
        public static string REF_KEY_VIOLATION = "The DELETE statement conflicted with the REFERENCE constraint";
        public static Int16 RKEY_VIOL = -2;
        public static Int16 SQL_ERROR = -99;
    }
}
