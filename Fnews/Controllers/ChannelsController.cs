using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models.ChannelsModel;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fnews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChannelsController : ControllerBase
    {
        private readonly IChannelLogic _channelLogic;

        public ChannelsController(IChannelLogic channelLogic)
        {
            _channelLogic = channelLogic;
        }

        [HttpGet("{id}")]
        public IActionResult GetChannel(int id)
        {
            Channel channel = _channelLogic.GetChannelById(id);
            if(channel == null)
            {
                return NotFound("Channel is not found");
            }
            return Ok(channel);
        }
        [HttpGet]
        public IActionResult GetAllChannels()
        {
            List<Channel> channels = _channelLogic.GetAllChannels().ToList();
            if (channels == null)
            {
                return BadRequest("Error");
            }
            if (channels.Count == 0)
            {
                return NotFound();
            }
            return Ok(channels);
        }
        [HttpPost]
        public IActionResult CreateChannel(ChannelCreateModel channelCreate)
        {
            if(channelCreate == null)
            {
                return BadRequest("null");
            }
            bool check = _channelLogic.CreateNewChannel(channelCreate);
            if (!check)
            {
                return BadRequest("Cannot create a new channel");
            }
            return Ok("Success");
        }

        [HttpPut]
        public IActionResult UpdateChannel([FromBody] Channel channel)
        {
            Channel channel1 = _channelLogic.GetChannelById(channel.ChannelId);
            if(channel1 != null)
            {
                return NoContent();

            }
            channel1.ChannelName = channel.ChannelName;
            channel1.IsActive = channel.IsActive;
            channel1.GroupId = channel.GroupId;
            _channelLogic.UpdateChannel(channel);
            return Ok("Update Successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteChannel(int id)
        {
            var check = _channelLogic.DeleteChannel(id);
            if(!check){
                return BadRequest("Error: Remove fail");
            }
            return Ok("Delete Successfully");
        }




        
    }
}
