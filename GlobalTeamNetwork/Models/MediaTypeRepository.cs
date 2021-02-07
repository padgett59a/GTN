using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GlobalTeamNetwork.Data;

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

        public MediaType GetMediaTypeById(int id)
        {
            return _appDbContext.MediaTypes.Find(id);
        }
    }
}
