using System.Threading;
using System.Threading.Tasks;
using Nethereum.JsonRpc.Client;

namespace Nethereum.RPC.Infrastructure
{
    public class GenericRpcRequestResponseHandlerNoParam<TResponse> : RpcRequestResponseHandlerNoParam<TResponse>, IGenericRpcRequestResponseHandlerNoParam<TResponse>
    {
        public GenericRpcRequestResponseHandlerNoParam(IClient client, string methodName) : base(client, methodName)
        {
        }

        public new Task<TResponse> SendRequestAsync(object id = null,
                                                    CancellationToken cancellationToken = default(CancellationToken))
        {
            return base.SendRequestAsync(id, cancellationToken);
        }
    }
}