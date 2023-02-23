using Abp.Application.Services;
using Abp.Domain.Repositories;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using VinaCent.Blaze.FirebaseCloudMessage;
using VinaCent.Blaze.FirebaseCloudMessage.FirebaseCloudMessage;
using VinaCent.Blaze.FirebaseCloudMessage.FirebaseCloudMessage.Dto;

namespace VinaCent.Blaze.Web.FirebaseCloudMessage
{
    public class FcmAppService : ApplicationService, IFcmAppService
    {
        private readonly IRepository<FcmMessageLog, Guid> repository;

        private readonly string _fcmInstanceName = "NghiaFcmInstanceName";

        private FirebaseApp _firebaseApp = null;

        public FcmAppService(IRepository<FcmMessageLog, Guid> repository)
        {
            this.repository = repository;
        }

        public FirebaseApp FirebaseApp
        {
            get
            {
                if (_firebaseApp == null)
                {
                    try
                    {
                        using var stream = new FileStream("demofcm-438a6-firebase-adminsdk-b3vli-b5980c126b.json", FileMode.Open, FileAccess.Read);
                        var credentials = ServiceAccountCredential.FromServiceAccountData(stream);
                        _firebaseApp = FirebaseApp.Create(new AppOptions()
                        {
                            Credential = GoogleCredential.FromServiceAccountCredential(credentials)
                        }, _fcmInstanceName);
                    }
                    catch (Exception)
                    {
                        _firebaseApp = FirebaseApp.GetInstance(_fcmInstanceName);
                    }
                }

                return _firebaseApp;
            }
        }

        public Task<string> SendByToken(FcmMsgBody msg)
        {
            var message = new Message()
            {
                Notification = new Notification
                {
                    Title = msg.Title,
                    Body = msg.Message
                },
                Token = msg.Token
            };
            return SendMessageAsync(message);
        }

        public Task<string> SendByTopic(FcmMsgBody msg)
        {
            var message = new Message()
            {
                Notification = new Notification
                {
                    Title = msg.Title,
                    Body = msg.Message
                },
                Topic = msg.Token
            };
            return SendMessageAsync(message);
        }

        public async Task<string> SendMessageAsync(Message msg)
        {
            var fcm = FirebaseMessaging.GetMessaging(FirebaseApp);
            repository.Insert(new FcmMessageLog
            {
                Title = msg.Notification.Title,
                Body = msg.Notification.Body,
                TopicId = Guid.Parse(msg.Topic),
                Token = msg.Token
            });
            return await fcm.SendAsync(msg);
        }

        public async Task<TopicManagementResponse> SubscribeToTopicAsync(Guid topicId, params string[] tokens)
        {
            var fcm = FirebaseMessaging.GetMessaging(FirebaseApp);
            // Subscribe the devices corresponding to the registration tokens to the
            // topic
            return await fcm.SubscribeToTopicAsync(
                tokens, topicId.ToString());
        }

        public async Task<TopicManagementResponse> UnsubscribeToTopicAsync(Guid topicId, params string[] tokens)
        {
            var fcm = FirebaseMessaging.GetMessaging(FirebaseApp);
            // Unsubscribe the devices corresponding to the registration tokens from the
            // topic
            return await fcm.UnsubscribeFromTopicAsync(
                tokens, topicId.ToString());
        }
    }
}
