using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace TDMT_DOAN.Models
{
    public class LoginCode
    {
        public bool CheckEmail(string Email)  //Check Email exist or not
        {
            TcpClient tClient = new TcpClient("gmail-smtp-in.l.google.com", 25);
            string CRLF = "\r\n";
            byte[] dataBuffer;
            string ResponseString;
            NetworkStream netStream = tClient.GetStream();
            StreamReader reader = new StreamReader(netStream);
            ResponseString = reader.ReadLine();
            /* Perform HELO to SMTP Server and get Response */
            dataBuffer = BytesFromString("HELO KirtanHere" + CRLF);
            netStream.Write(dataBuffer, 0, dataBuffer.Length);
            ResponseString = reader.ReadLine();
            dataBuffer = BytesFromString("MAIL FROM:<YourGmailIDHere@gmail.com>" + CRLF);
            netStream.Write(dataBuffer, 0, dataBuffer.Length);
            ResponseString = reader.ReadLine();
            /* Read Response of the RCPT TO Message to know from google if it exist or not */
            dataBuffer = BytesFromString("RCPT TO:<" + Email.Trim() + ">" + CRLF);
            netStream.Write(dataBuffer, 0, dataBuffer.Length);
            ResponseString = reader.ReadLine();
            if (GetResponseCode(ResponseString) == 550)
            {
                return false;
            }
            /* QUITE CONNECTION */
            dataBuffer = BytesFromString("QUITE" + CRLF);
            netStream.Write(dataBuffer, 0, dataBuffer.Length);
            tClient.Close();
            return true;
        }
        public string encryptSHA(string data)   // Encode password
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] hashedBytes;
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            hashedBytes = sha.ComputeHash(encoder.GetBytes(data));
            return System.Text.Encoding.UTF8.GetString(hashedBytes);
        }

        private byte[] BytesFromString(string str)
        {
            return Encoding.ASCII.GetBytes(str);  // Convert string to byte
        }

        private int GetResponseCode(string ResponseString)
        {
            return int.Parse(ResponseString.Substring(0, 3));
        }

        public string RandomPass(int maxSize)  // Random string
        {
            char[] chars = new char[62];
            chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[1];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetNonZeroBytes(data);
                data = new byte[maxSize];
                crypto.GetNonZeroBytes(data);
            }
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        public bool SendPasswordResetEmail(string ToEmail, string NewPassword)  // Get password from Email
        {
            try
            {
                // MailMessage class is present is System.Net.Mail namespace
                MailMessage mailMessage = new MailMessage("namy.web.shop@gmail.com", ToEmail);


                // StringBuilder class is present in System.Text namespace
                StringBuilder sbEmailBody = new StringBuilder();
                sbEmailBody.Append("Dear sir,<br/><br/>");
                sbEmailBody.Append("Your new password is :");
                sbEmailBody.Append("<br/>");
                sbEmailBody.Append(NewPassword);
                sbEmailBody.Append("<br/><br/>");
                sbEmailBody.Append("<b> Technologies</b>");

                mailMessage.IsBodyHtml = true;

                mailMessage.Body = sbEmailBody.ToString();
                mailMessage.Subject = "Reset Your Password";
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

                smtpClient.Credentials = new System.Net.NetworkCredential()
                {
                    UserName = "namy.web.shop@gmail.com",
                    Password = "Khtn1212111"
                };

                smtpClient.EnableSsl = true;
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

    }
}