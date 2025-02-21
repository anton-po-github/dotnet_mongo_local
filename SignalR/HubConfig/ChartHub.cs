using Microsoft.AspNetCore.SignalR;
public class ChartHub : Hub
{
    public async Task BroadcastChartData(List<ChartModel> data)
    {
        await Clients.All.SendAsync("broadcastchartdata", data);
    }
}