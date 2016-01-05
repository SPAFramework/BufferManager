using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public enum BufferUnitStatus {
        Free,
        Used
    }
    public class BufferUnit
    {
        public byte[] Buffer { get; private set; }
        public int Offset { get; private set; }
        public int Length { get; private set; }
        public BufferUnitStatus Status { get; set; }

        public BufferUnit(byte[] buffer, int offset, int length)
        {
            Buffer = buffer;
            Offset = offset;
            Length = length;
            Status = BufferUnitStatus.Free;
        }

        public void Free()
        {
            Status = BufferUnitStatus.Free;
        }
    }
}
