using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TwitchLights.API.Models
{
    public class WatchModel
    {
        [Required(ErrorMessage = "A channel name is required.")]
        [MinLength(2,  ErrorMessage ="Channel name should be at least 2 characters long.")]
        public string ChannelName { get; set; }
    }
}
