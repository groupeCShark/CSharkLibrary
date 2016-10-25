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

        User[] LoggedUsers
        {
            [OperationContract]
            get;
        }
    }
}
