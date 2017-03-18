using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Devallish.SportsClub.Data;
using System;

namespace Devallish.SportsClub.Api.Controllers
{
    // public abstract class BaseController<T> : Controller where T : BaseEntity, new()
    public abstract class BaseController : Controller
    {
        //protected readonly IRepository _repository;
        private readonly ILogger _logger;

        // public BaseController(IRepository repository, ILogger logger)
        // {
        //     _repository = repository;
        //     _logger = logger;
        // }

        public BaseController(ILogger logger)
        {
            _logger = logger;
        }
        // [HttpGet("{id}")]
        // public async Task<IActionResult> GetById(int id)
        //     => await TakeActionJson<T>(() =>
        //          _repository.Set<T>().FirstOrDefault(e => e.Id == id));

        // [HttpGet("first")]
        // public async Task<IActionResult> GetFirst()
        //     => await TakeActionJson<T>(() =>
        //         _repository.Set<T>().FirstOrDefault());

        // [HttpGet("last")]
        // public async Task<IActionResult> GetLast()
        //     => await TakeActionJson<T>(() =>
        //         _repository.Set<T>().LastOrDefault());

        // [HttpGet("empty")]
        // public async Task<IActionResult> GetEmpty() => await TakeActionJson<T>(() => new T());

        // [HttpPost]
        // public IActionResult Post([FromBody]T data) => TakeAction(() => _repository.Add(data));

        // [HttpDelete("{id}")]
        // public IActionResult Delete(int id) => TakeAction(() => _repository.Delete<T>(id));


        // [HttpPut]
        // public IActionResult Put([FromBody]T data) => TakeAction(() => _repository.Update(data));

        [HttpGet("test")]
        public IActionResult GetTest(){
            return Json($"Test actioned at: {DateTime.Now}");
        }
        protected async Task<IActionResult> TakeActionJson<TReturnType>(
            Task<TReturnType> action,
            [CallerMemberName] string callerMemberName = "")
        {

            IActionResult result;
            try
            {
                LogInformation(ControllerEventIds.TakeAction,
                    "Invoking action in BaseController.TakeActionJson",
                    callerMemberName);

                var data = await action;
                result = Json(data);
            }
            catch (Exception ex)
            {
                LogError(ControllerEventIds.TakeActionException, ex,
                    "Exception caught in BaseController.TakenActionJson()",
                    callerMemberName);
                result = StatusCode(500, $"Sorry, unable to {callerMemberName} due to a problem on the server.");
            }
            return result;
        }


        // TODO: Can the above and below be merged in some way?
        //    It would seem that there are minimal differences.

        protected async Task<IActionResult> TakeAction(
            Task action,
            [CallerMemberName] string callerMemberName = "")
        {

            IActionResult result;
            try
            {
                LogInformation(ControllerEventIds.TakeAction,
                    "Invoking action in BaseController.TakeAction",
                    callerMemberName);

                await action;
                result = Ok();
            }
            catch (Exception ex)
            {
                LogError(ControllerEventIds.TakeActionException, ex,
                    "Exception caught in BaseController.TakenAction()",
                    callerMemberName);
                result = StatusCode(500, $"Sorry, unable to {callerMemberName} due to a problem on the server.");
            }
            return result;
        }

        private void LogError(int eventId, Exception ex, string message, string rootMethodName)
        {
            _logger.LogError(eventId, ex, CreateLogMessage(message, rootMethodName));
        }

        private void LogInformation(int eventId, string message, string rootMethodName)
        {
            _logger.LogInformation(eventId, CreateLogMessage(message, rootMethodName));
        }

        private string CreateLogMessage(string message, string activityDescription)
            => $"[{this.GetType().Name}.{activityDescription}] - {message}";
    }
}
