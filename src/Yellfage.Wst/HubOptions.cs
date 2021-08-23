using Yellfage.Wst.Configuration;

namespace Yellfage.Wst
{
    public class HubOptions<TMarker>
    {
        public CommunicationSettings Communication { get; set; }

        public HubOptions()
        {
            Communication = new CommunicationSettings();
        }

        public HubOptions(CommunicationSettings communication)
        {
            Communication = communication;
        }

        internal void Validate()
        {
            Communication.Validate();
        }
    }
}
