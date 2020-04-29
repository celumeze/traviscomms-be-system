using System.Threading.Tasks;
using TravisComms.Messaging;
using TravisComms.Messaging.Interfaces;

namespace TravisComms.Sender.Module
{
    public interface IEmailMessenger
    {
       Task SendVerifyEmailCommand(IVerifyEmailCommand verifyEmailCommand, string connectionString, string queuePath);
    }
}
