using System;
using Networker.Common.Abstractions;

namespace Forza7DataClient
{
    public class ForzaPacketSerialiser : IPacketSerialiser
    {
        public T Deserialise<T>(byte[] packetBytes, int offset, int length)
        {
            return (T)Activator.CreateInstance(typeof(T), packetBytes);
        }

        public byte[] Serialise<T>(T packet)
        {
            throw new System.NotImplementedException();
        }

        public bool CanReadOffset => false;
        public bool CanReadName => false;
        public bool CanReadLength => false;
    }
}