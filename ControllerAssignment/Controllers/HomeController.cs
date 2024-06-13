using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ControllerAssignment.Models
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Welcome()
        {
            return Content("Welcome to the best bank");
        }
        [Route("account-details")]
        public IActionResult AccountDetails()
        {
            var person = new Class()
            {
                AccountNo = 2,
                AccountHolderName="mohith",
                AccountBalence=5000

            };
            return Json(person);
        }

        [Route("account-statement")]
        public IActionResult AccountStatement()
        {
            return File("form.pdf","application/pdf");
        }

        [Route("get-current-balance/{accountNumber:int=0}")]
        public IActionResult AccountBalence()
        {
            var person = new Class()
            {
                AccountNo = 1100,
                AccountHolderName = "mohith",
                AccountBalence = 5000

            };
            int accountNumber = Convert.ToInt32(Request.RouteValues["accountNumber"]);
            if (accountNumber == 1100)
            {
                int balence = Convert.ToInt32(person.AccountBalence);
                return Content($"{balence}");
            }
            else if(accountNumber == 0) 
            {
                Response.StatusCode=404;
                return Content("account number should be supplid");
            }

            else
            {
                Response.StatusCode = 400;
                return Content("account number should be 1100");
            }
            
        }
        
    }
}
