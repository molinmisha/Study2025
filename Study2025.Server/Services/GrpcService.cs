using Grpc.Core;

/// usage
//PS C:\Users\Misha\source\repos\Study2025\study2025.client> grpcurl -insecure -proto Protos/greet.proto -d '{\"name\": \"TestUser\"}' localhost:44333 greet.Greeter / SayHello
//{
//    "message": "Hello TestUser"
//}
//PS C:\Users\Misha\source\repos\Study2025\study2025.client>

namespace GrpcService
{ 
    public class GreeterService : Greeter.GreeterBase
    {
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
    }
}