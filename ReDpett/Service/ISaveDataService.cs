using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReDpett.Service
{
    public interface ISaveDataService
    {
        string InsertOfflineDB();
        void CreateOfflineDB();
    }
}
