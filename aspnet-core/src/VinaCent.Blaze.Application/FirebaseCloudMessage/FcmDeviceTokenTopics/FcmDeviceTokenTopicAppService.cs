using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaCent.Blaze.FirebaseCloudMessage.FcmDeviceTokenTopics.Dto;
using VinaCent.Blaze.FirebaseCloudMessage.FirebaseCloudMessage;

namespace VinaCent.Blaze.FirebaseCloudMessage.FcmDeviceTokenTopics
{
    public class FcmDeviceTokenTopicAppService : AsyncCrudAppService<FcmDeviceTokenTopic, FcmDeviceTokenTopicDto, Guid>, IFcmDeviceTokenTopicAppService
    {
        private readonly IFcmAppService _fcmAppService;

        public FcmDeviceTokenTopicAppService(IRepository<FcmDeviceTokenTopic, Guid> repository, IFcmAppService fcmAppService) : base(repository)
        {
            _fcmAppService = fcmAppService;
        }

        public override async Task<FcmDeviceTokenTopicDto> CreateAsync(FcmDeviceTokenTopicDto input)
        {
            var result = await base.CreateAsync(input);
            await _fcmAppService.SubscribeToTopicAsync(input.TopicId, input.DeviceToken);
            return result;
        }

        public override async Task<FcmDeviceTokenTopicDto> UpdateAsync(FcmDeviceTokenTopicDto input)
        {
            var old = await GetAsync(input);
            var resutl = await base.UpdateAsync(input);

            await _fcmAppService.UnsubscribeToTopicAsync(old.TopicId, old.DeviceToken);
            await _fcmAppService.SubscribeToTopicAsync(input.TopicId, input.DeviceToken);

            return resutl;
        }

        public override async Task DeleteAsync(EntityDto<Guid> input)
        {
            await base.DeleteAsync(input);

            var old = await GetAsync(input);
            await _fcmAppService.UnsubscribeToTopicAsync(old.TopicId, old.DeviceToken);
        }
    }
}
