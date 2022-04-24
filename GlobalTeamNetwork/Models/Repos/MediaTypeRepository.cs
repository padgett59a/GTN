using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GlobalTeamNetwork.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GlobalTeamNetwork.Models
{
    public class MediaTypeRepository : IMediaTypeRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public MediaTypeRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<MediaType> AllMediaTypes
        {
            get { return _appDbContext.MediaTypes; }
        }

        public IEnumerable<MediaType> AllMediaTypesShortNotes
        {
            get { return GTNCommonRepository.TableShortNotes<MediaType>("MediaTypes", _appDbContext); }
        }

        public MediaType GetMediaTypeById(int id)
        {
            return _appDbContext.MediaTypes.Find(id);
        }

        public int InsertMediaType(List<MediaType> mediaTypeList)
        {
            int addCount = 0;
            foreach (MediaType newItem in mediaTypeList)
            {
                var retVal = _appDbContext.MediaTypes.Add(newItem);
                if (retVal.State == EntityState.Added) { addCount++; }
            }
            _appDbContext.SaveChanges();
            return addCount;
        }

        public int DeleteMediaType(List<int> delItemList)
        {
            int delCount = 0;
            foreach (int delItemId in delItemList)
            {
                MediaType delItem = this.GetMediaTypeById(delItemId);
                var retVal = _appDbContext.MediaTypes.Remove(delItem);
                if (retVal.State == EntityState.Deleted) { delCount++; }
            }
            _appDbContext.SaveChanges();
            return delCount;
        }
        public EntityState UpdateMediaType(MediaType MediaType)
        {
            EntityEntry<MediaType> retVal = _appDbContext.MediaTypes.Update(MediaType);
            EntityState updateState = retVal.State;
            _appDbContext.SaveChanges();
            return updateState;
        }

    }
}
