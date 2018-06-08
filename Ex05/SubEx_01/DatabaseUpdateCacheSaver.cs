using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patterns.Ex05.ExternalLibs;

namespace Patterns.Ex05.SubEx_01
{
    class DatabaseUpdateCacheSaver : IDatabaseSaver
    {
        IDatabaseSaver saver;
        CacheUpdater updater;
        public DatabaseUpdateCacheSaver(IDatabaseSaver saver, CacheUpdater updater)
        {
            this.saver = saver;
            this.updater = updater;
        }
        public void SaveData(object data)
        {
            saver.SaveData(data);
            updater.UpdateCache();
        }

    }
}
