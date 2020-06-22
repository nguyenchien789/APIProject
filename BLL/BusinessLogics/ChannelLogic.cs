using BLL.Interfaces;
using BLL.Models.ChannelsModel;
using DAL.UnitOfWorks;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.BusinessLogics
{
    public class ChannelLogic : IChannelLogic
    {

        private readonly IUnitOfWork _unitOfWork;
        public ChannelLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool CreateNewChannel(ChannelCreateModel channelCreateModel)
        {
            bool check = false;
            if (channelCreateModel != null)
            {
                Channel channel = new Channel()
                {
                    ChannelId = channelCreateModel.ChannelId,
                    ChannelName = channelCreateModel.ChannelName,
                    IsActive = channelCreateModel.IsActive,
                };
                _unitOfWork.GetRepository<Channel>().Insert(channel);
                _unitOfWork.Commit();
                check = true;

            }
            return check;
        }

        public bool DeleteChannel(int id)
        {
              bool check = false;
            Channel channel = _unitOfWork.GetRepository<Channel>().FindById(id);
            if (channel != null)
            {
                channel.IsActive = false;
                _unitOfWork.GetRepository<Channel>().Update(channel);
                _unitOfWork.Commit();
                check = true;
            }
            return check;
        }

        public IQueryable<Channel> GetAllChannels()
        {
            IQueryable<Channel> channel = _unitOfWork.GetRepository<Channel>().GetAll();
            return channel;
        }

        public Channel GetChannelById(int id)
        {
            Channel channel = _unitOfWork.GetRepository<Channel>().FindById(id);
            return channel;
        }

        public bool UpdateChannel(Channel channelUpdate)
        {
            bool check = false;
            if (channelUpdate != null)
            {
                _unitOfWork.GetRepository<Channel>().Update(channelUpdate);
                _unitOfWork.Commit();
                check = true;
            }
            return check;
        }
    }
}
