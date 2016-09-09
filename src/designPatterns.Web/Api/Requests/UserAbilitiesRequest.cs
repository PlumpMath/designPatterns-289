using System;
using System.Collections.Generic;
using designPatterns.Web.Api.Modules;

namespace designPatterns.Web.Api.Requests
{
    public class UserAbilitiesRequest
    {
        public IEnumerable<UserAbilityRequest> Abilities { get; set; }
        public Guid UserId { get; set; }
    }
}