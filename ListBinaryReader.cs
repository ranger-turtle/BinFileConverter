using System.Collections.Generic;
using System.IO;

namespace Binary_File_Converter
{
	class ListBinaryReader : IBinaryHandler
	{
		private readonly List<IBinaryHandler> dataHandlers = new List<IBinaryHandler>();
		private readonly string type;

		public ListBinaryReader(string type) => this.type = type;

		public void ReadValue(BinaryReader binaryReader)
		{
			int numberOfElements = binaryReader.ReadInt32();
			for (int i = 0; i < numberOfElements; i++)
			{
				IBinaryHandler binaryHandler = BinaryHandlerFactory.GenerateHandler(new BinaryDataTypeData(type));
				binaryHandler.ReadValue(binaryReader);
				dataHandlers.Add(binaryHandler);
			}
		}

		public void WriteValue(BinaryWriter binaryWriter)
		{
			binaryWriter.Write(dataHandlers.Count);
			foreach (IBinaryHandler dataHandler in dataHandlers)
			{
				dataHandler.WriteValue(binaryWriter);
			}
		}
	}
}
