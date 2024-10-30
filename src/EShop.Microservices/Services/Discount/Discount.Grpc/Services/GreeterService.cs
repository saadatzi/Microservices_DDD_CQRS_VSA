// <fileheader>
//     <copyright file="GreeterService.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

namespace Discount.Grpc.Services
{
    /// <summary>
    /// Provides implementation for the Greeter gRPC service, extending from GreeterBase.
    /// </summary>
    public class GreeterService : Greeter.GreeterBase
    {
        /// <summary>
        /// Sends a greeting message to the client based on the provided request.
        /// </summary>
        /// <param name="request">The request containing the name of the user to greet.</param>
        /// <param name="context">The context of the server call.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the HelloReply message.</returns>
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            // Constructs a greeting message by appending "Hello " to the user's name from the request.
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name,
            });
        }
    }
}
