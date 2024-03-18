using LoginDemo1.ApiModel;
using LoginDemo1.DataContext;
using LoginDemo1.Model;
using LoginDemo1.OtherOperation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoginDemo1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChangePasswordController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ChangePasswordController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult ChangePassword([FromBody]ChangePassword changePassword)
        {
            ChangePasswordMessage changePasswordMessage;
            if (_context.User.Any(user=>user.Email==changePassword.Email))
            {
                User olduser = _context.User.Where(s => s.Email == changePassword.Email).FirstOrDefault()!;
                if (olduser.Password== SHA256Encrypt.ComputePasswordToSha256Hash(changePassword.OldPassword))
                {
                    User updateduser = new User()
                    {
                        UserId = olduser.UserId,
                        UserName = olduser.UserName,
                        Email = olduser.Email,
                        Password = SHA256Encrypt.ComputePasswordToSha256Hash(changePassword.NewPassword),
                        MobileNumber = olduser.MobileNumber,
                        LockoutEnabled = olduser.LockoutEnabled,
                        LockoutEnd = olduser.LockoutEnd,
                        AccessFailedCount = 0
                    };
                    _context.Entry(olduser).State = EntityState.Detached;
                    _context.User.Update(updateduser);
                    _context.SaveChanges();
                    changePasswordMessage = new ChangePasswordMessage()
                    {
                        EmailExists = true,
                        Passcheck = true
                    };
                    return Ok(changePasswordMessage);
                }
                else
                {
                    changePasswordMessage = new ChangePasswordMessage()
                    {
                        EmailExists = true,
                        Passcheck = false
                    };
                    return Ok(changePasswordMessage);
                }
               
            }
            else
            {
                changePasswordMessage = new ChangePasswordMessage()
                {
                    EmailExists = false,
                    Passcheck = false
                };
                return Ok(changePasswordMessage);
            }
            
        }
    }
}
