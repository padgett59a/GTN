using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using GlobalTeamNetwork.Data;
using Microsoft.EntityFrameworkCore;

namespace GlobalTeamNetwork.Models
{
    public interface IOrganizationRepository
    {
        IEnumerable<Organization> AllOrganizations { get; }
        IEnumerable<Organization> AllOrganizationsShortNotes { get; }
        Organization GetOrganizationById(int orgID);
        EntityEntry<Organization> AddOrg(Organization organization);
        EntityState UpdateOrg(Organization organization);
        int AddOrgs(List<Organization> newOrgs);
        int DeleteOrgs(List<int> delOrgs);
    }
}
