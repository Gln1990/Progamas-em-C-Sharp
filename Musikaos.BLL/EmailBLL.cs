using Musikaos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Musikaos.BLL
{
    public class EmailBLL
    {
        public void Enviar(EmailDTO obj)
        {
            //configurar o email
            MailMessage email = new MailMessage();
            //remetente
            email.From = new MailAddress(obj.EmailRemetente, obj.NomeRemetente);
            //destinatário
            email.To.Add(new MailAddress(obj.EmailDestinatario, obj.NomeDestinatario));
            //assunto
            email.Subject = obj.Assunto;
            //corpo do e-mail
            email.Body = obj.Mensagem;


            //configurar o SMTPClient
            SmtpClient smtp = new SmtpClient();

            //dados do servidor (gmail)
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("profronicosta@gmail.com", "fqomdzryovntysnh");

            try
            {
                //envia o e-mail
                smtp.Send(email);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao enviar e-mail! " + ex.Message);
            }

        }
    }
}
