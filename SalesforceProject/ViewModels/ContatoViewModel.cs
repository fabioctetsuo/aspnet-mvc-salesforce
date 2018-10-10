using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SalesforceProject.Models;

namespace SalesforceProject.ViewModels
{
    public class ContatoViewModel
    {
        public IEnumerable<Newsletter> Newsletters{ get; set; }
        public Newsletter Newsletter { get; set; }
    }
}