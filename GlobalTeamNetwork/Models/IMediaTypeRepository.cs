using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTeamNetwork.Models
{
    public interface IMediaTypeRepository
    {
        IEnumerable<MediaType> AllMediaTypes { get; }
        MediaType GetMediaTypeById(int langId);
    }
}
