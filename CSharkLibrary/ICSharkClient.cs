using System.ServiceModel;

namespace CSharkLibrary
{
    public interface ICSharkClient
    {
        [OperationContract(IsOneWay = true)]
        void ReceiveMessage(string Username, string Message);
    }
}
