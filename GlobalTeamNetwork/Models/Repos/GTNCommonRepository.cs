using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GlobalTeamNetwork.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;

namespace GlobalTeamNetwork.Models
{
    public static class GTNCommonRepository
    {

        //generic method for invoking the SP_TableGetNotesShort stored procedure
        //returns a list from the passed table having a short notes field of length GTN_Globals.NotesCharCount
        public static List<T> TableShortNotes<T>(string tableName, ApplicationDbContext dbContext) where T : class
        {

            var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@TableName",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = tableName
                        },
                        new SqlParameter() {
                            ParameterName = "@charCount",
                            SqlDbType =  System.Data.SqlDbType.SmallInt,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = GTN_Globals.NotesCharCount
                        }
            };

            return dbContext.Set<T>().FromSqlRaw("[dbo].[SP_TableGetNotesShort] @TableName, @charCount", param).ToList<T>();
        }

        public static List<TableName> FindFKTables(string tableName, ApplicationDbContext dbContext)
        {
            var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@pktable_name",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = tableName
                        }
            };
            List<TableName> retVal = dbContext.Set<TableName>().FromSqlRaw("[dbo].[SP_FkTables] @pktable_name", param).ToList<TableName>();

            //return distinct values
            return retVal.GroupBy(t => t.KeyedTable)
                         .Select(g => g.First())
                         .ToList();
        }
        public static int LocationCoalesce(Location pLoc, LocationRepository pLocRepo)
        {
            //find locationID. Insert new location if it does not exist
            int retVal = 0;

            //Save any new location, and lookup the locID
            List<Location> locations = pLocRepo.AllLocations.ToList();
            Location locExists = locations.Find(l => l.City == pLoc.City && l.State == pLoc.State && l.Country == pLoc.Country);

            if (locExists == null)
            {
                Location newLoc = new Location();
                newLoc.City = pLoc.City;
                newLoc.State = pLoc.State;
                newLoc.Country = pLoc.Country;
                List<Location> insLocs = new List<Location>();
                insLocs.Add(newLoc);
                pLocRepo.InsertLocations(insLocs);
                locations = pLocRepo.AllLocations.ToList();
                locExists = locations.Find(l => l.City == pLoc.City && l.State == pLoc.State && l.Country == pLoc.Country);
                if (locExists == null) { throw new System.Collections.Generic.KeyNotFoundException($"ConvertOnameToPerson: No location record found for city: {pLoc.City}, state: {pLoc.State} and country: {pLoc.Country}"); }
            }
            retVal = locExists.locID;
            return retVal;

        }
    }
}
