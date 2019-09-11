using System;

namespace Omf.Common.Events
{
    interface IAuthenticatedEvent : IEvent
    {
        Guid UserId { get; }
    }
}