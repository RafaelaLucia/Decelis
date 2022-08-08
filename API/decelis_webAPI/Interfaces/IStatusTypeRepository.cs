using decelis_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace decelis_webAPI.Interfaces
{
    public interface IStatusTypeRepository
    {
        List<StatusType> GetAll();
        StatusType SearchStatus(int idStatus);
        void PostStatus(StatusType newStatus);
        void DeleteStatus(int idStatus);
    }
}
