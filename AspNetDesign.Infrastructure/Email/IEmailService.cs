﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Infrastructure.Email
{
    public interface IEmailService
    {
        void SendMail(string from, string to, string subject, string body);
    }
}
