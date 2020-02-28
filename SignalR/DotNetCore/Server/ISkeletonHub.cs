using System.Threading.Tasks;

namespace Server
{
    public interface ISkeletonHub
    {
        Task announceClientConnected(System.String clientID);
    }
}