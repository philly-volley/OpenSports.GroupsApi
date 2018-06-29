namespace OpenSports.GroupsApi.Controllers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using OpenSports.GroupsApi.Commands;
    using OpenSports.GroupsApi.Constants;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("{group}/[controller]")]
    [ApiVersion("1.0")]
    public class DetailsController : ControllerBase
    {
        private readonly Lazy<IGetDetailsCommand> getDetailsCommand;

        public DetailsController(Lazy<IGetDetailsCommand> getDetailsCommand)
        {
            this.getDetailsCommand = getDetailsCommand;
        }

        /// <summary>
        /// Gets the details about the specified group.
        /// </summary>
        /// <param name="group">The group ID.</param>
        /// <param name="cancellationToken">The cancellation token used to cancel the HTTP request.</param>
        /// <returns>A 200 OK response containing the event or a 404 Not Found if a event with the specified ID was not
        /// found.</returns>
        /// <response code="200">The event with the specified ID.</response>
        /// <response code="304">The event has not changed since the date given in the If-Modified-Since HTTP header.</response>
        /// <response code="404">A event with the specified ID could not be found.</response>
        [HttpGet(Name = DetailsControllerRoute.GetDetails)]
        [HttpHead]
        [ProducesResponseType(typeof(Details), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status304NotModified)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public Task<IActionResult> Get([FromRoute] string group, CancellationToken cancellationToken) =>
            this.getDetailsCommand.Value.ExecuteAsync(group);
    }
}
