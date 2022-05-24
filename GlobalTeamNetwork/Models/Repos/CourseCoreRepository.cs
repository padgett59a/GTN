using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GlobalTeamNetwork.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GlobalTeamNetwork.Models
{
    public class CourseCoreRepository : ICourseCoreRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public CourseCoreRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<CourseCore> AllCourseCores
        {
            //get { return _appDbContext.CourseCores; }
            get
            {
                return _appDbContext.CourseCores;
            }
        }
        public IEnumerable<CourseCore> AllCourseCoreShortNotes
        {
            get
            {
                return GTNCommonRepository.TableShortNotes<CourseCore>("CourseCores", _appDbContext);
            }
        }

        public CourseCore GetCourseCoreById(int CourseCode)
        {
            //may need to replace with paramaterized call to SP
            return _appDbContext.CourseCores.Find(CourseCode);
        }
        public EntityEntry<CourseCore> InsertCourseCore(CourseCore CourseCore)
        {
            //may need to replace with paramaterized call to SP
            return _appDbContext.CourseCores.Add(CourseCore);
        }

        //This takes a CourseCore list and coverts it to a CourseCoreSName list 
        public List<CourseCoreSName> ConvertCoursesToSNames(List<CourseCore> CourseCores)
        {
            //Converts Semester Code to SemesterName and Instructor.personID to Instructor Name for easy display
            List<CourseCoreSName> CourseCnameList = new List<CourseCoreSName>();
            CurriculumRepository currRepo = new CurriculumRepository(_appDbContext);
            SemesterCoreRepository semesterRepo = new SemesterCoreRepository(_appDbContext);
            PersonsRepository personsRepo = new PersonsRepository(_appDbContext);

            IEnumerable<SemesterCore> semesterList = semesterRepo.AllSemesterCores.ToList();
            IEnumerable<Person> personsList = personsRepo.AllPersons.ToList();

            foreach (CourseCore Course in CourseCores) {
                CourseCoreSName newSemCname = new CourseCoreSName();
                newSemCname.CourseCoreID = Course.CourseCoreID;
                newSemCname.CourseName = Course.CourseName;
                //SemesterName 
                newSemCname.SemesterName = semesterList.First(s => s.SemesterCode == Course.SemesterCode).SemesterName;
                newSemCname.CourseLetterCode = Course.CourseLetterCode;
                newSemCname.CourseNumberCode = Course.CourseNumberCode;
                newSemCname.HasWorkbook = Course.HasWorkbook;
                newSemCname.HasVideoText = Course.HasVideoText;
                //Instructor Name
                newSemCname.InstructorName = personsList.First(p => p.personID == Course.InstructorID).FullName;
                newSemCname.VideosInHand = Course.VideosInHand;
                newSemCname.MasteringFilesInHand = Course.MasteringFilesInHand;
                newSemCname.TextFilesInHand = Course.TextFilesInHand;
                newSemCname.Notes = Course.Notes;

                CourseCnameList.Add(newSemCname);
            }
            return CourseCnameList;
        }

        //This takes a CourseCore list having curriculum names (rather than curriculumID). The SP makes the conversion to curriculumID (if it can)
        public int InsertCourses(List<CourseCore> CourseCores)
        {
            int addCount = 0;
            foreach (CourseCore newCourse in CourseCores)
            {
                var retVal = _appDbContext.CourseCores.Add(newCourse);
                if (retVal.State == EntityState.Added) { addCount++; }
            }
            _appDbContext.SaveChanges();
            return addCount;
        }
        public int DeleteCourses(List<int> delItemList)
        {
            int delCount = 0;
            //CourseCore delItem;
            foreach (int delItemId in delItemList)
            {
                CourseCore delCourse = this.GetCourseCoreById(delItemId);
                var retVal = _appDbContext.CourseCores.Remove(delCourse);
                if (retVal.State == EntityState.Deleted) {delCount++;}
            }
            _appDbContext.SaveChanges();
            return delCount;
        }

        public EntityState UpdateCourseCore(CourseCore Course)
        {
            EntityEntry<CourseCore> retVal = _appDbContext.CourseCores.Update(Course);
            EntityState updateState = retVal.State;
            _appDbContext.SaveChanges();
            return updateState;
        }


    }
}
