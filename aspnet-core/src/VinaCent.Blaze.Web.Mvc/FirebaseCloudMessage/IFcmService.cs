using FirebaseAdmin.Messaging;
using System.Threading.Tasks;

namespace VinaCent.Blaze.Web.FirebaseCloudMessage
{
    public interface IFcmService
    {
        Task<string> SendMessageAsync(Message msg);
    }
}
