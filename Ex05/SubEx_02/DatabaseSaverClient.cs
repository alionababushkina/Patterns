using Patterns.Ex05.ExternalLibs;
using Patterns.Ex05.SubEx_02;
using System;

namespace Patterns.Ex05.SubEx_02
{
    public class DatabaseSaverClient
    {
        public void Main(bool b)
        {
            var databaseSaver = new DatabaseSaverListener(new DatabaseSaver());
            databaseSaver.DataSaved += (sender, args) =>
            {
                var mailSender = new MailSender();
                var cacheUpdater = new CacheUpdater();
                mailSender.Send("email");
                cacheUpdater.UpdateCache();
            };

            DoSmth(databaseSaver);
        }

        private void DoSmth(IDatabaseSaver saver)
        {
            saver.SaveData(null);
        }
    }

    public class DatabaseSaverListener : IDatabaseSaver
    {
        public event EventHandler DataSaved;
        private readonly IDatabaseSaver intDatabaseSaver;

        protected virtual void OnDataSaved()
        {
            DataSaved?.Invoke(this, EventArgs.Empty);
        }

        public DatabaseSaverListener(IDatabaseSaver databaseSaver)
        {
            intDatabaseSaver = databaseSaver;
        }

        public void SaveData(object data)
        {
            intDatabaseSaver.SaveData(data);
            OnDataSaved();
        }
    }
}

