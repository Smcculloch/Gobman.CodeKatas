using System;
using System.Web;
using System.Web.Mvc;
using Gobman.CodeKatas.Abstractions.Services;
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