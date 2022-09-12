using System;
using System.Web;
using System.Web.Mvc;
using Gobman.CodeKatas.Abstractions.Contracts;
using Gobman.CodeKatas.Abstractions.Services;
using Gobman.CodeKatas.Database;
using Gobman.CodeKatas.Mvc.Models;

namespace Gobman.CodeKatas.Mvc.Controllers
{
    public class DefaultController: Controller
    {
        private readonly IPersonService _personService;

        public DefaultController(IPersonService personService)
        {
            _personService = personService;
        }

        [Route]
        [HttpGet]
        public ActionResult Index(string message = "")
        {
            var model = new DefaultModel
            {
                IntroText = "MVC Demo",
                PersonList = _personService.GetAll(),
                Message = message
            };

            return View(model);
        }


        [Route("Person/Edit")]
        [HttpGet]
        public ActionResult EditPerson(Guid personId)
        {
            var person = _personService.Get(personId);

            var model = new PersonModel
            {
                PersonId = personId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                PhoneNumber = person.PhoneNumber
            };

            return View(model);
        }


        [HttpPost]
        [Route("Person/Edit")]
        public ActionResult EditPerson(PersonCarrier model)
        {
            try
            {
                _personService.Update(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Route("Person/Create")]
        [HttpGet]
        public ActionResult CreatePerson(Guid personId)
        { 
            return View();
        }


        [Route("Person/Create")]
        [HttpPost]
        public ActionResult CreatePerson([Bind] PersonCarrier model)
        {
            try
            {
                _personService.Create(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        [Route("Person/Delete")]
        [HttpGet]
        public ActionResult DeletePerson(Guid personId)
        {
            var person = _personService.Get(personId);

            var model = new PersonModel
            {
                PersonId = personId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                PhoneNumber = person.PhoneNumber
            };
            return View(model);
        }


        [Route("Person/Delete")]
        [HttpPost]
        public ActionResult Delete(Guid personId)
        {
            try
            {
                var person = _personService;
                person.Delete(personId);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }



        [Route("Footer")]
        [ChildActionOnly]
        public ActionResult Footer(string pageName)
        {
            var model = new FooterModel
            {
                CopyrightText = $"{HttpUtility.HtmlEncode('©')} {DateTime.Now.Year}",
                PageName = pageName
            };

            return PartialView(model);
        }
    }
}