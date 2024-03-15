using EnumTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnumTest.ViewModels
{
    public class RegisterViewModel
    {
        public User User { get; set; }
        public IEnumerable<SelectListItem> Gender {  get; set; }
    }
}