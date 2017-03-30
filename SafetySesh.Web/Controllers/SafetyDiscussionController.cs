using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using SafetySesh.Web.Data;
using SafetySesh.Web.Models;

namespace SafetySesh.Web.Controllers
{
    public class SafetyDiscussionController : Controller
    {
        private ApplicationUserManager UserManager
            => HttpContext?.GetOwinContext().GetUserManager<ApplicationUserManager>();
        private ApplicationSignInManager SignInManager
            => HttpContext?.GetOwinContext().Get<ApplicationSignInManager>();

        // GET: SafetyDiscussion
        public async Task<ActionResult> Index()
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            var model = new List<SafetyDiscussion>();
            using (var context = new SafetySeshContext())
            {
                model = context.SafetyDiscussions
                    .Where(s => s.UserId == userId)
                    .ToList();
            }

            return View(model);
        }

        public ActionResult Add()
        {
            var model = new SafetyDiscussion();

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Add(SafetyDiscussion model)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            var user = await UserManager.FindByIdAsync(userId);

            model.UserId = userId;
            model.Observer = user?.Email;
            model.Date = DateTime.Now;

            using (var context = new SafetySeshContext())
            {
                context.SafetyDiscussions.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}