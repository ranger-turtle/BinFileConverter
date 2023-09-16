using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Binary_File_Converter
{
	class BinaryDataReader
	{
		public Dictionary<string, IBinaryHandler> ReadBinaryDataDictionary(string binaryFilePath, string jsonInBlueprintPath)
		{
			Dictionary<string, IBinaryHandler> binaryDataDictionary = new Dictionary<string, IBinaryHandler>();
			using var fileStream = File.OpenRead(binaryFilePath);
			using BinaryReader binaryReader = new BinaryReader(fileStream);
			var blueprintNodes = JsonDocument.Parse(File.ReadAllText(jsonInBlueprintPath)).RootElement.GetProperty("Input Binary Data");
			foreach (var item in blueprintNodes.EnumerateArray())
			{
				string name = item.GetProperty("name").GetString();
				string type = item.GetProperty("type").GetString();
				string dataType = item.GetProperty("dataType").GetString();
				string keyType = item.GetProperty("keyType").GetString();
				var binaryDataHandler = BinaryHandlerFactory.GenerateHandler(new BinaryDataTypeData(type, keyType, dataType));
				binaryDataHandler.ReadValue(binaryReader);
				binaryDataDictionary.Add(name, binaryDataHandler);
			}
			return binaryDataDictionary;
		}
	}
}
