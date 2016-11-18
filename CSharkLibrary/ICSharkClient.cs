using System.IO;
using System.ServiceModel;

namespace CSharkLibrary
{
    public interface ICSharkClient
    {
        [OperationContract(IsOneWay = true)]
        void ReceiveMessage(string Username, string Message);

        [OperationContract(IsOneWay = true)]
        void DownloadFile(CSharkFile file);
    }
}
