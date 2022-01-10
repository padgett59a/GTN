using GlobalTeamNetwork.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GlobalTeamNetwork.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace GlobalTeamNetwork.Controllers
{
    public class GTNCommonController : Controller
    {


        private readonly ApplicationDbContext _appDbContext;

        public GTNCommonController(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        [HttpPost]
        //NOTE: FromBody is a REQUIRED attribute for this to retrieve the data from the POST payload
        public JsonResult GetFKTablesJson([FromBody] string tableName)
        {
            List<TableName> retVal = GTNCommonRepository.FindFKTables(tableName, _appDbContext);
            return Json(retVal);
        }


    }
}
