using System.IO;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace CSharkLibrary
{
    [ServiceContract(CallbackContract = typeof(ICSharkClient))]
    public interface ICSharkService
    {
        [OperationContract]
        void Login(string Username);

        [OperationContract]
        void Logout();

        [OperationContract]
        void SendMessage(string Message);

        [OperationContract]
        void UploadFile(CSharkFile file);

        User[] LoggedUsers
        {
            [OperationContract]
            get;
        }
    }

    [MessageContract]
    public class CSharkFile
    {
        [MessageHeader]
        public string Filename;

        [MessageHeader]
        public string Username;

        [MessageBodyMember]
        public Stream FileByteStream;
    }
}
