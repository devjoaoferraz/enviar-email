using System.Net.Mail;
using System.Web.Mvc;

namespace EnviarEmail.Controllers
{
    public class SendMailerController : Controller
    {
        // GET: SendMailer
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Index(Models.MailModel _objModelMail)
        {
            if (ModelState.IsValid)
            {
                //Instância classe email
                MailMessage mail = new MailMessage();
                mail.To.Add(_objModelMail.To);
                mail.From = new MailAddress(_objModelMail.From);
                mail.Subject = _objModelMail.Subject;
                string Body = _objModelMail.Body;
                mail.Body = Body;
                mail.IsBodyHtml = true;

                //Instância smtp do servidor, neste caso o gmail.
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                ("joaoqi@gmail.com", "Segredo2");// Login e senha do e-mail.
                smtp.EnableSsl = true;
                smtp.Send(mail);
                ModelState.Clear();
                return View();
            }
            else
            {
                return View();
            }
        }
    }
}