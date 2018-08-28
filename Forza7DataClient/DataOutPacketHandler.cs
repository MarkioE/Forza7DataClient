using System.Threading.Tasks;
using Networker.Common;
using Networker.Common.Abstractions;

namespace Forza7DataClient
{
    public class DataOutPacketHandler : PacketHandlerBase<DataOutPacket>
    {
        private readonly ILogger _logger;

        public DataOutPacketHandler(ILogger logger)
        {
            _logger = logger;
        }

        public override async Task Process(DataOutPacket packet, ISender sender)
        {
            _logger.Debug($"It's working: {packet.AccelerationX}");
        }
    }
}