using System;
using System.Collections.Generic;
using System.Text;

namespace nnsMobile1
{
    public interface IMailService
    {
        bool StartMailer(string title, string body, string[] to, string[] cc, string[] bcc, string filePath, ref string err);

    }
}