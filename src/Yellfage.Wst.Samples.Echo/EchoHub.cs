namespace Yellfage.Wst.Samples.Echo
{
    [ConnectionFilter]
    [DisconnectionFilter]
    [HubInvocationFilter]
    public class EchoHub : Hub<IEchoHub>, IEchoHub
    {
    }
}
