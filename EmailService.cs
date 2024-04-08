//using LUSCMaintenance.Models;
//using System;
//using System.IO;
//using System.Net;
//using System.Net.Mail;
//using System.Threading.Tasks;

//namespace LUSCMaintenance
//{
//    public class EmailService
//    {
//        private readonly SmtpSettings _smtpSettings;

//        public EmailService(SmtpSettings smtpSettings)
//        {
//            _smtpSettings = smtpSettings;
//        }

//        public async Task SendEmailAsync(IEnumerable<string> recipientEmails, string subject, string body, byte[] attachment)
//        {
//            try
//            {
//                using (MailMessage mail = new MailMessage())
//                {
//                    using (SmtpClient smtpClient = new SmtpClient(_smtpSettings.Server, _smtpSettings.Port))
//                    {
//                        smtpClient.UseDefaultCredentials = false;
//                        smtpClient.Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password);
//                        smtpClient.EnableSsl = true;

//                        mail.From = new MailAddress(_smtpSettings.Username);
//                        foreach (var recipientEmail in recipientEmails)
//                        {
//                            mail.To.Add(recipientEmail);
//                        }
//                        mail.Subject = subject;
//                        mail.Body = body;

//                        // Attach the Excel file
//                        using (MemoryStream ms = new MemoryStream(attachment))
//                        {
//                            mail.Attachments.Add(new Attachment(ms, "MaintenanceReport.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"));

//                            // Send the email
//                            await smtpClient.SendMailAsync(mail);
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                // Log the exception
//                Console.WriteLine($"An error occurred while sending the email: {ex.Message}");
//            }
//        }

//    }
//}
