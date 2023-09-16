using System.IO;

namespace Binary_File_Converter
{
	class StringBinaryHandler : IBinaryHandler
	{
		public string Value { get; private set; }

		public StringBinaryHandler(string initVal = "<none>") => Value = initVal;

		public void ReadValue(BinaryReader binaryReader)
		{
			Value = binaryReader.ReadString();
		}

		public void WriteValue(BinaryWriter BinaryWriter)
		{
			BinaryWriter.Write(Value);
		}
	}
}
