﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReDpett.Service
{
    public interface ISaveDataService
    {
        void InsertOfflineDB();
        Task<ListAppDataService> GetDataFromOfflineDB();
    }
}
