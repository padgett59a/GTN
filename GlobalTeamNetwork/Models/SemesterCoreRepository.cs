using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GlobalTeamNetwork.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GlobalTeamNetwork.Models
{
    public class SemesterCoreRepository : ISemesterCoreRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public SemesterCoreRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<SemesterCore> AllSemesterCores
        {
            //get { return _appDbContext.SemesterCores; }
            get
            {
                return _appDbContext.SemesterCores;
            }
        }
        public IEnumerable<SemesterCore> AllSemesterCoresShortNotes
        {
            get {return GTNCommonRepository.TableShortNotes<SemesterCore>("SemesterCores", _appDbContext); }
        }

        public SemesterCore GetSemesterCoreById(string semesterCode)
        {
            //may need to replace with paramaterized call to SP
            return _appDbContext.SemesterCores.Find(semesterCode);
        }
        public EntityEntry<SemesterCore> InsertSemesterCore(SemesterCore SemesterCore)
        {
            //may need to replace with paramaterized call to SP
            return _appDbContext.SemesterCores.Add(SemesterCore);
        }

        //This takes a SemesterCore list and coverts it to a SemesterCoreCName list 
        public List<SemesterCoreCName> ConvertToCNames(List<SemesterCore> SemesterCores)
        {
            List<SemesterCoreCName> semesterCnameList = new List<SemesterCoreCName>();
            CurriculumRepository currRepo = new CurriculumRepository(_appDbContext);
            IEnumerable<Curriculum> currList = currRepo.AllCurriculum.ToList();

            foreach (SemesterCore semester in SemesterCores) {
                SemesterCoreCName newSemCname = new SemesterCoreCName();
                newSemCname.SemesterCode = semester.SemesterCode;
                newSemCname.SemesterName = semester.SemesterName;
                newSemCname.CurriculumName = currList.First(i => i.CurriculumID == semester.CurriculumID).CurriculumName;
                newSemCname.NumberOfVideoSessions= semester.NumberOfVideoSessions;
                newSemCname.Notes = semester.Notes;

                semesterCnameList.Add(newSemCname);
            }

            return semesterCnameList;
        }

        //This takes a SemesterCore list having curriculum names (rather than curriculumID). The SP makes the conversion to curriculumID (if it can)
        public int InsertSemesters(List<SemesterCore> SemesterCores)
        {
            int addCount = 0;
            foreach (SemesterCore newSemester in SemesterCores)
            {
                var retVal = _appDbContext.SemesterCores.Add(newSemester);
                if (retVal.State == EntityState.Added) { addCount++; }
            }
            _appDbContext.SaveChanges();
            return addCount;
        }
        public int DeleteSemesters(List<string> delItemList)
        {
            int delCount = 0;
            //SemesterCore delItem;
            foreach (string delItemId in delItemList)
            {
                SemesterCore delSemester = this.GetSemesterCoreById(delItemId);
                var retVal = _appDbContext.SemesterCores.Remove(delSemester);
                if (retVal.State == EntityState.Deleted) {delCount++;}
            }
            _appDbContext.SaveChanges();
            return delCount;
        }

        public EntityState UpdateSemesterCore(SemesterCore semester)
        {
            EntityEntry<SemesterCore> retVal = _appDbContext.SemesterCores.Update(semester);
            EntityState updateState = retVal.State;
            _appDbContext.SaveChanges();
            return updateState;
        }


    }
}
