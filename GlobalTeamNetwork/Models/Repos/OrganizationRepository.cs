using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GlobalTeamNetwork.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data;

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
        public IEnumerable<OrgLoc> AllOrgLocsShortNotes
        {
            get
            {
                //IEnumerable<OrgLoc> retVal = _appDbContext.OrgLocs;
                //return retVal;
                return GTNCommonRepository.TableShortNotes<OrgLoc>("OrgLocs", _appDbContext);
            }
        }
        public IEnumerable<Organization> AllOrganizationsShortNotes
        {
            get { return GTNCommonRepository.TableShortNotes<Organization>("Organizations", _appDbContext); }
        }

        public Organization GetOrganizationById(int orgID)
        {
            //may need to replace with paramaterized call to SP
            return _appDbContext.Organizations.Find(orgID);
        }
        public EntityEntry<Organization> AddOrg(Organization organization)
        {
            //may need to replace with paramaterized call to SP
            return _appDbContext.Organizations.Add(organization);
        }
        public EntityState UpdateOrg(OrgLoc orgLoc)
        {
            //Resolve location
            LocationRepository locRepo = new LocationRepository(_appDbContext);
            Location loc = new Location();
            loc.City = orgLoc.City;
            loc.State = orgLoc.State;
            loc.Country = orgLoc.Country;
            Organization org = new Organization
            {
                locID = GTNCommonRepository.LocationCoalesce(loc, locRepo),
                orgID = orgLoc.orgID,
                OrgName = orgLoc.OrgName
            };
            EntityEntry<Organization> retVal = _appDbContext.Organizations.Update(org);
            EntityState updateState = retVal.State;
            _appDbContext.SaveChanges();
            return updateState;
        }
        public int AddOrgs(List<OrgLoc> newOrgList)
        {
            int addCount = 0;
            LocationRepository locRepo = new LocationRepository(_appDbContext);
            foreach (OrgLoc newOrg in newOrgList)
            {
                Location loc = new Location
                {
                    City = newOrg.City,
                    State = newOrg.State,
                    Country = newOrg.Country
                };
                Organization org = new Organization
                {
                    locID = GTNCommonRepository.LocationCoalesce(loc, locRepo),
                    orgID = newOrg.orgID,
                    OrgName = newOrg.OrgName
                };

                _appDbContext.Organizations.Add(org);
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
            }
            try
            {
                _appDbContext.SaveChanges();
            }
            catch (Exception e)
            {
                if (e.InnerException.Message.Contains(GTN_SQL_ERR.REF_KEY_VIOLATION)) {
                    return GTN_SQL_ERR.RKEY_VIOL;
                }
                else
                {
                    return GTN_SQL_ERR.SQL_ERROR;
                }
            }
            delCount++;
            return delCount;
        }
    }
}
