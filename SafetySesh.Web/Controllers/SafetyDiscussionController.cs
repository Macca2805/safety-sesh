using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SafetySesh.Web.Data;
using SafetySesh.Web.Models;

namespace SafetySesh.Web.Controllers
{
    public class SafetyDiscussionController : Controller
    {
        private ApplicationUserManager UserManager
            => HttpContext?.GetOwinContext().GetUserManager<ApplicationUserManager>();

        // GET: SafetyDiscussion
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
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
            var userId = User.Identity.GetUserId();
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

        public async Task<ActionResult> View(Guid id)
        {
            using (var context = new SafetySeshContext())
            {
                var model = await context.SafetyDiscussions.FindAsync(id);
                return View(model);
            }
        }
    }
}