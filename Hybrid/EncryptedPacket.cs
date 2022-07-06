using System;
using System.Collections.Generic;
using System.Text;

namespace Pluralsight.Hybrid
{
    public class EncryptedPacket
    {
        public byte[] EncryptedSessionKey;
        public byte[] EncryptedData;
        public byte[] Iv;
    }
}
