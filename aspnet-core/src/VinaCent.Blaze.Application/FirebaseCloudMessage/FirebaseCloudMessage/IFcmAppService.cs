using Abp.Application.Services;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using System;
using System.Threading.Tasks;
using VinaCent.Blaze.FirebaseCloudMessage.FirebaseCloudMessage.Dto;

namespace VinaCent.Blaze.FirebaseCloudMessage.FirebaseCloudMessage
{
    public interface IFcmAppService : IApplicationService
    {
        FirebaseApp FirebaseApp { get; }
        Task<string> SendMessageAsync(Message msg);
        Task<string> SendByTopic(FcmMsgBody msg);
        Task<string> SendByToken(FcmMsgBody msg);

        Task<TopicManagementResponse> SubscribeToTopicAsync(Guid topicId, params string[] tokens);
        Task<TopicManagementResponse> UnsubscribeToTopicAsync(Guid topicId, params string[] tokens);
    }
}
