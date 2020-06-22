using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.ChannelsModel
{
    public class ChannelCreateModel
    {
        public int ChannelId { get; set; }
        public string ChannelName { get; set; }
        public bool IsActive { get; set; }
    }
}
