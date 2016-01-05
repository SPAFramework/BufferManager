using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class BufferManager
    {
        public int TotalBufferUnits => _unitsList.Count();

        public int FreeBufferUnits
        {
            get { return _unitsList.Count(bufferUnit => bufferUnit.Status == BufferUnitStatus.Free); }
        }
        public int UsedBufferUnits
        {
            get { return _unitsList.Count(bufferUnit => bufferUnit.Status == BufferUnitStatus.Used); }
        }


        private readonly IList<BufferUnit> _unitsList;
        private readonly byte[] _buffer;

        public BufferManager(int totalBufferBytes, int bytesAllocatedPerUnit)
        {
            var numberOfPossibleBufferUnits = totalBufferBytes / bytesAllocatedPerUnit;
            _buffer = new byte[numberOfPossibleBufferUnits * bytesAllocatedPerUnit];  //Adjust buffer size to fit     
            _unitsList = new List<BufferUnit>();

            for (var unitOffset = 0; unitOffset < _buffer.Length; unitOffset += bytesAllocatedPerUnit)
                _unitsList.Add(new BufferUnit(_buffer, 0, bytesAllocatedPerUnit));
        }

        public BufferUnit GetBufferUnit()
        {
            var freeUnit = _unitsList.FirstOrDefault(bufferUnit => bufferUnit.Status == BufferUnitStatus.Free);
            freeUnit.Status = BufferUnitStatus.Used;
            return freeUnit;
        }

        public void FreeBufferUnit(BufferUnit bufferUnit) 
        {
            bufferUnit.Status = BufferUnitStatus.Free;
        }




    }
}
