#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;

namespace Yellfage.Bitflux.Sample.Echo
{
    public class NotifyPayload
    {
        [Required]
        public string Message { get; set; }
    }
}
