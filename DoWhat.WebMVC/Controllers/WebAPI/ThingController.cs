using DoWhat.Models;
using DoWhat.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DoWhat.WebMVC.Controllers.WebAPI
{
        [Authorize]
        [RoutePrefix("api/Check")]
    public class ThingController : ApiController
    {
        private bool SetCheckState(int thingId, bool newState)
        {
            // Create the service
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ThingService(userId);

            // Get the thing
            var detail = service.GetThingById(thingId);

            // Create the ThingEdit model instance with the new star state
            var updatedNote =
                new ThingEdit
                {
                    ThingId = detail.ThingId,
                    Heading = detail.Heading,
                    SubHeading = detail.SubHeading,
                //TimeAllotted = (Models.AllottedTime)detail.TimeAllotted,
                IsCompleted = newState
                };

            // Return a value indicating whether the update succeeded
            return service.UpdateThing(updatedNote);
        }

        [Route("{id}/Check")]
        [HttpPut]
        public bool ToggleCheckOn(int id) => SetCheckState(id, true);

        [Route("{id}/Check")]
        [HttpDelete]
        public bool ToggleCheckOff(int id) => SetCheckState(id, false);
    }
}
