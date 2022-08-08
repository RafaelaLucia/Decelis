using decelis_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace decelis_webAPI.Interfaces
{
    public interface ITimeClassRepository
    {
        List<TimeClass> GetAll();
        TimeClass SearchTime(int idTime);
        void PostTime(TimeClass newTime);
        void DeleteTime(int idTime);
        void UpdateTimeId(int idTime, TimeClass timeUptodate);
    }
}
