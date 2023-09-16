using System.IO;

namespace Binary_File_Converter
{
	interface IBinaryHandler
	{
		void ReadValue(BinaryReader binaryReader);
		void WriteValue (BinaryWriter binaryWriter);
	}
}
