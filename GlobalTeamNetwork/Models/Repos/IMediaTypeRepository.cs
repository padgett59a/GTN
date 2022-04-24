using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTeamNetwork.Models
{
    public interface IMediaTypeRepository
    {
        IEnumerable<MediaType> AllMediaTypes { get; }
        IEnumerable<MediaType> AllMediaTypesShortNotes { get; }
        MediaType GetMediaTypeById(int langId);
        int InsertMediaType(List<MediaType> mediaTypeList);
        int DeleteMediaType(List<int> delItemList);
        EntityState UpdateMediaType(MediaType MediaType);
    }
}
