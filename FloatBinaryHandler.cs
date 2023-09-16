using System.IO;

namespace Binary_File_Converter
{
	class FloatBinaryHandler : IBinaryHandler
	{
		public float Value { get; private set; }

		public FloatBinaryHandler(float initVal = 0) => Value = initVal;

		public void ReadValue(BinaryReader binaryReader)
		{
			Value = binaryReader.ReadSingle();
		}

		public void WriteValue(BinaryWriter BinaryWriter)
		{
			BinaryWriter.Write(Value);
		}
	}
}
