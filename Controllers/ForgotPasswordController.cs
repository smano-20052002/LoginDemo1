using LoginDemo1.DataContext;
using LoginDemo1.OtherOperation;
using LoginDemo1.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoginDemo1.ApiModel;
namespace LoginDemo1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ForgotPasswordController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ForgotPasswordController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult SendMailForPassword([FromBody]string Mail)
        {
            ForgetPasswordMessage message = null;
            if (!_context.User.Any(s=>s.Email==Mail))
            {
                message = new ForgetPasswordMessage
                {
                    EmailExists = false,
                    SendMail=false
                };
                return NotFound(message);
            }
            string Password = RandomPasswordGeneration.RandomPasswordGenerator();
            User olduser = _context.User.Where(s => s.Email == Mail).FirstOrDefault()!;
            //User updateduser = new User()
            //{
            //    UserId = olduser.UserId,
            //    UserName = olduser.UserName,
            //    Email = olduser.Email,
            //    Password = SHA256Encrypt.ComputePasswordToSha256Hash(Password),
            //    MobileNumber = olduser.MobileNumber,
            //    LockoutEnabled = olduser.LockoutEnabled,
            //    LockoutEnd= olduser.LockoutEnd,
            //    AccessFailedCount= 0
            //};
            olduser.Password = SHA256Encrypt.ComputePasswordToSha256Hash(Password);
            //_context.Entry(olduser).State = EntityState.Detached;
            _context.User.Update(olduser);
            _context.SaveChangesAsync();
            if (EmailGenerator.SendEmail(olduser.UserName, olduser.Email, Password))
            {
                message = new ForgetPasswordMessage
                {
                    EmailExists = true,
                    SendMail = true
                };
                return Ok(message);
            }
            else
            {

                message = new ForgetPasswordMessage
                {
                    EmailExists = true,
                    SendMail = false
                };
                return BadRequest(message);
            }
        }
    }
}
