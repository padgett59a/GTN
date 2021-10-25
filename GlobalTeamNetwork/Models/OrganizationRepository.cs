using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GlobalTeamNetwork.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GlobalTeamNetwork.Models
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public OrganizationRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Organization> AllOrganizations
        {
            get
            {
                return _appDbContext.Organizations;
            }
        }

        public Organization GetOrganizationById(int orgID)
        {
            //may need to replace with paramaterized call to SP
            return _appDbContext.Organizations.Find(orgID);
        }
        public EntityEntry<Organization> AddOrg (Organization organization)
        {
            //may need to replace with paramaterized call to SP
            return _appDbContext.Organizations.Add(organization);
        }
        public EntityState UpdateOrg(Organization organization)
        {
            //may need to replace with paramaterized call to SP
            EntityEntry<Organization> retVal = _appDbContext.Organizations.Update(organization);
            EntityState updateState = retVal.State;
            _appDbContext.SaveChanges();
            return updateState;
        }
        public int AddOrgs(List<Organization> newOrgList)
        {
            int addCount = 0;
            foreach (Organization newOrg in newOrgList)
            {
                _appDbContext.Organizations.Add(newOrg);
                addCount++;
            }
            _appDbContext.SaveChanges();
            return addCount;
        }
        public int DeleteOrgs(List<int> delOrgList)
        {
            int delCount = 0;
            Organization delOrg;
            foreach (int delOrgId in delOrgList)
            {
                delOrg = _appDbContext.Organizations.Find(delOrgId);
                _appDbContext.Organizations.Remove(delOrg);
                delCount++;
            }
            _appDbContext.SaveChanges();
            return delCount;
        }
    }
}
