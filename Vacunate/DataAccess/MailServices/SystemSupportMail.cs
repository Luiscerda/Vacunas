using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MailServices
{
    class SystemSupportMail : MasterMailServer
    {
        public SystemSupportMail()
        {
            senderMail = "";
            password = "";
            host = "smtp.gmail.com";
            port = 587;
            ssl = true;
            InitializeSmtpClient();
        }
    }
}
