using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VinaCent.Blaze.FirebaseCloudMessage.FcmUserTopics.Dto;
using VinaCent.Blaze.FirebaseCloudMessage.FirebaseCloudMessage;

namespace VinaCent.Blaze.FirebaseCloudMessage.FcmUserTopics
{
    public class FcmUserTopicAppService : AsyncCrudAppService<FcmUserTopic, FcmUserTopicDto, Guid>, IFcmUserTopicAppService
    {
        private readonly IFcmAppService _fcmAppService;
        private readonly IRepository<FcmUserDeviceToken, Guid> _fcmUserDeviceTokenRepository;

        public FcmUserTopicAppService(IRepository<FcmUserTopic, Guid> repository, IFcmAppService fcmAppService, IRepository<FcmUserDeviceToken, Guid> fcmUserDeviceTokenRepository) : base(repository)
        {
            _fcmAppService = fcmAppService;
            _fcmUserDeviceTokenRepository = fcmUserDeviceTokenRepository;
        }

        public override async Task<FcmUserTopicDto> CreateAsync(FcmUserTopicDto input)
        {
            var result = await base.CreateAsync(input);
            var tokens = (await _fcmUserDeviceTokenRepository.GetAllListAsync(x => x.UserId == input.UserId)).Select(x => x.UserToken).ToArray();

            await _fcmAppService.SubscribeToTopicAsync(input.FcmTopicId, tokens);
            return result;
        }

        public override async Task<FcmUserTopicDto> UpdateAsync(FcmUserTopicDto input)
        {
            var old = await GetAsync(input);
            var oldTokens = (await _fcmUserDeviceTokenRepository.GetAllListAsync(x => x.UserId == old.UserId)).Select(x => x.UserToken).ToArray();
            var result = await base.UpdateAsync(input);

            await _fcmAppService.UnsubscribeToTopicAsync(old.FcmTopicId, oldTokens);
            var tokens = (await _fcmUserDeviceTokenRepository.GetAllListAsync(x => x.UserId == input.UserId)).Select(x => x.UserToken).ToArray();
            await _fcmAppService.SubscribeToTopicAsync(input.FcmTopicId, tokens);

            return result;
        }

        public override async Task DeleteAsync(EntityDto<Guid> input)
        {
            var old = await GetAsync(input);
            var oldTokens = (await _fcmUserDeviceTokenRepository.GetAllListAsync(x => x.UserId == old.UserId)).Select(x => x.UserToken).ToArray();
            await _fcmAppService.UnsubscribeToTopicAsync(old.FcmTopicId, oldTokens);

            await base.DeleteAsync(input);
        }
    }
}
