using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_mongo_local.SignalR.Models;
using Microsoft.AspNetCore.SignalR;

namespace dotnet_mongo_local.SignalR.HubConfig
{
    public class ChartHub : Hub
    {
        public async Task BroadcastChartData(List<ChartModel> data)
        {
            await Clients.All.SendAsync("broadcastchartdata", data);
        }
    }
}