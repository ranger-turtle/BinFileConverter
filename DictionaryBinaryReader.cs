using System.Collections.Generic;
using System.IO;

namespace Binary_File_Converter
{
	class DictionaryBinaryReader : IBinaryHandler
	{
		private readonly List<IBinaryHandler> keyHandlers = new List<IBinaryHandler>();
		private readonly List<IBinaryHandler> dataHandlers = new List<IBinaryHandler>();
		private readonly string keyType;
		private readonly string dataType;

		public DictionaryBinaryReader(string keyType, string dataType)
		{
			this.keyType = keyType;
			this.dataType = dataType;
		}

		public void ReadValue(BinaryReader binaryReader)
		{
			int numberOfElements = binaryReader.ReadInt32();
			for (int i = 0; i < numberOfElements; i++)
			{
				IBinaryHandler keyBinaryHandler = BinaryHandlerFactory.GenerateHandler(new BinaryDataTypeData(keyType));
				keyBinaryHandler.ReadValue(binaryReader);
				keyHandlers.Add(keyBinaryHandler);

				IBinaryHandler dataBinaryHandler = BinaryHandlerFactory.GenerateHandler(new BinaryDataTypeData(dataType));
				dataBinaryHandler.ReadValue(binaryReader);
				dataHandlers.Add(dataBinaryHandler);
			}
		}

		public void WriteValue(BinaryWriter binaryWriter)
		{
			binaryWriter.Write(dataHandlers.Count);
			for (int i = 0; i < keyHandlers.Count; i++)
			{
				keyHandlers[i].WriteValue(binaryWriter);
				dataHandlers[i].WriteValue(binaryWriter);
			}
		}
	}
}
