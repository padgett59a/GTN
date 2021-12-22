using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GlobalTeamNetwork.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GlobalTeamNetwork.Models
{
    public class SessionCoreRepository : ISessionCoreRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public SessionCoreRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<SessionCore> AllSessionCores
        {
            //get { return _appDbContext.SessionCores; }
            get
            {
                return _appDbContext.SessionCores;
            }
        }

        public SessionCore GetSessionCoreById(int SessionCode)
        {
            //may need to replace with paramaterized call to SP
            return _appDbContext.SessionCores.Find(SessionCode);
        }
        public EntityEntry<SessionCore> InsertSessionCore(SessionCore SessionCore)
        {
            //may need to replace with paramaterized call to SP
            return _appDbContext.SessionCores.Add(SessionCore);
        }

        //This takes a SessionCore list and coverts it to a SessionCoreCName list 
        public List<SessionCoreCName> ConvertSessionsToCNames(List<SessionCore> SessionCores)
        {
            //Converts courseID to courseName for easy display
            List<SessionCoreCName> SessionCnameList = new List<SessionCoreCName>();
            CourseCoreRepository courseRepo = new CourseCoreRepository(_appDbContext);
            PersonsRepository personsRepo = new PersonsRepository(_appDbContext);

            IEnumerable<CourseCore> courseList = courseRepo.AllCourseCores.ToList();
            IEnumerable<Person> personsList = personsRepo.AllPersons.ToList();

            foreach (SessionCore Session in SessionCores) {
                SessionCoreCName newSessionCname = new SessionCoreCName();
                newSessionCname.SessionCoreID = Session.SessionCoreID;
                //CourseName 
                newSessionCname.CourseName = courseList.First(c => c.CourseCoreID == Session.CourseCoreID).CourseName;
                newSessionCname.SessionName = Session.SessionName;
                newSessionCname.SessionCode = Session.SessionCode;
                newSessionCname.Notes = Session.Notes;
                SessionCnameList.Add(newSessionCname);
            }
            return SessionCnameList;
        }

        //This takes a SessionCore list having curriculum names (rather than curriculumID). The SP makes the conversion to curriculumID (if it can)
        public int InsertSessions(List<SessionCore> SessionCores)
        {
            int addCount = 0;
            foreach (SessionCore newSession in SessionCores)
            {
                var retVal = _appDbContext.SessionCores.Add(newSession);
                if (retVal.State == EntityState.Added) { addCount++; }
            }
            _appDbContext.SaveChanges();
            return addCount;
        }
        public int DeleteSessions(List<int> delItemList)
        {
            int delCount = 0;
            //SessionCore delItem;
            foreach (int delItemId in delItemList)
            {
                SessionCore delSession = this.GetSessionCoreById(delItemId);
                var retVal = _appDbContext.SessionCores.Remove(delSession);
                if (retVal.State == EntityState.Deleted) {delCount++;}
            }
            _appDbContext.SaveChanges();
            return delCount;
        }

        public EntityState UpdateSessionCore(SessionCore Session)
        {
            EntityEntry<SessionCore> retVal = _appDbContext.SessionCores.Update(Session);
            EntityState updateState = retVal.State;
            _appDbContext.SaveChanges();
            return updateState;
        }


    }
}
