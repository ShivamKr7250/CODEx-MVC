using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODEx.Utility
{
    public class EmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //logic to send email
            return Task.CompletedTask;
        }
    }
}
