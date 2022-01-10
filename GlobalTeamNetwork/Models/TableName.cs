using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTeamNetwork.Models
{
    public class TableName
    {
        [Key]
        public string KeyedTable { get; set; }
    }
}
