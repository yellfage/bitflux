#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;

namespace Yellfage.Wst.Sample.Echo
{
    public class NotifyPayload
    {
        [Required]
        public string Message { get; set; }
    }
}
