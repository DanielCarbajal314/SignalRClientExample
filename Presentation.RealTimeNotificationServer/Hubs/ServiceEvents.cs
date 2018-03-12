using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities.RealTimeEvents;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Presentation.RealTimeNotificationServer.Hubs
{
    [HubName("ServiceEvents")]
    public class ServiceEvents : Hub
    {
        public void RegisterNewService(ServiceRegistration ServiceRegistration)
        {
            Clients.All.NewMessageRegistered(ServiceRegistration);
        }
    }
}