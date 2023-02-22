using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace VinaCent.Blaze.Web.FirebaseCloudMessage
{
    public class FcmService : IFcmService
    {
        private readonly string _fcmInstanceName = "NghiaFcmInstanceName";

        private FirebaseApp _firebaseApp = null;

        public FcmService()
        {
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
                    } catch (Exception)
                    {
                        _firebaseApp = FirebaseApp.GetInstance(_fcmInstanceName);
                    }
                }

                return _firebaseApp;
            }
        }

        public async Task<string> SendMessageAsync(Message msg)
        {
            var fcm = FirebaseMessaging.GetMessaging(FirebaseApp);
            return await fcm.SendAsync(msg);
        }
    }
}
