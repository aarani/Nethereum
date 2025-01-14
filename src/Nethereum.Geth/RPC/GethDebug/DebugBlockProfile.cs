using System.Threading;
using System.Threading.Tasks;
using Nethereum.JsonRpc.Client;

namespace Nethereum.Geth.RPC.Debug
{
    /// <Summary>
    ///     Turns on block profiling for the given duration and writes profile data to disk. It uses a profile rate of 1 for
    ///     most accurate information. If a different rate is desired, set the rate and write the profile manually using
    ///     debug_writeBlockProfile.
    /// </Summary>
    public class DebugBlockProfile : RpcRequestResponseHandler<object>, IDebugBlockProfile
    {
        public DebugBlockProfile(IClient client) : base(client, ApiMethods.debug_blockProfile.ToString())
        {
        }

        public RpcRequest BuildRequest(string file, long seconds, object id = null)
        {
            return base.BuildRequest(id, file, seconds);
        }

        public Task<object> SendRequestAsync(string file, long seconds, object id = null,
                                             CancellationToken cancellationToken = default(CancellationToken))
        {
            return base.SendRequestAsync(id, cancellationToken, file, seconds);
        }
    }
}