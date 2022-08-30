using System.Collections.Generic;
using Gobman.CodeKatas.Abstractions.Contracts;

namespace Gobman.CodeKatas.Mvc.Models
{
    public class DefaultModel
    {
        public string IntroText { get; set; }

        public string Message { get; set; }

        public string ErrorMessage { get; set; }

        public IList<PersonCarrier> PersonList { get; set; }
    }
}