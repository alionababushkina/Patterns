using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patterns.Ex05.ExternalLibs;

namespace Patterns.Ex05.SubEx_01
{
    class DatabaseMailSender : IDatabaseSaver
    {
        DatabaseSaver saver;
        MailSender sender;
        string email;

        public DatabaseMailSender(DatabaseSaver saver, MailSender sender)
        {
            this.saver = saver;
            this.sender = sender;
        }

        public void SaveData(object data)
        {
            saver.SaveData(data);
            sender.Send(email);
        }

    }
}
