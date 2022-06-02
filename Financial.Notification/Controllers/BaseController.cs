using Financial.Application.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Financial.Notification.Controller
{ 
    public class BaseController : ControllerBase
    {
        private readonly IBaseNotification _baseNotification;
        public ProblemDetailsFactory ProblemDetails => HttpContext?.RequestServices?.GetRequiredService<ProblemDetailsFactory>();

        public BaseController(IBaseNotification baseNotification)
        {
            _baseNotification = baseNotification;
        }

        protected IActionResult CreatedOrBadRequest(object result = null)
        {
            if (_baseNotification.IsValid) return Created(string.Empty, result);

            return BadRequestBase();
        }

        protected IActionResult BadRequestBase()
        {
            var problemDetails = ProblemDetails.CreateProblemDetails(HttpContext, (int)HttpStatusCode.BadRequest, "Bad request");
            var notifications = _baseNotification.Notifications.Select(notification => new { name = notification.Key, reason = notification.Message });

            problemDetails.Extensions.Add("invalid-params", notifications);
            return BadRequest(problemDetails);
        }

    }
}
