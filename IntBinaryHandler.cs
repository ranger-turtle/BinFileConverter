using System.IO;

namespace Binary_File_Converter
{
	class IntBinaryHandler : IBinaryHandler
	{
		public int Value { get; private set; }

		public IntBinaryHandler(int initVal = 0) => Value = initVal;

		public void ReadValue(BinaryReader binaryReader)
		{
			Value = binaryReader.ReadInt32();
		}

		public void WriteValue(BinaryWriter BinaryWriter)
		{
			BinaryWriter.Write(Value);
		}
	}
}
