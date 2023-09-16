using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Binary_File_Converter
{
	class BinaryDataWriter
	{
		public void WriteBinaryDataDictionary(string outputBinaryFilePath, string jsonOutBlueprintPath, Dictionary<string, IBinaryHandler> binaryDataDictionary)
		{
			using var fileStream = File.OpenWrite(outputBinaryFilePath);
			using BinaryWriter binaryWriter = new BinaryWriter(fileStream);
			var blueprintNodes = JsonDocument.Parse(File.ReadAllText(jsonOutBlueprintPath)).RootElement.GetProperty("Output Binary Data");
			foreach (var item in blueprintNodes.EnumerateArray())
			{
				string name = item.GetProperty("name").GetString();
				try
				{
					if (binaryDataDictionary.ContainsKey(name))
					{
						binaryDataDictionary[name].WriteValue(binaryWriter);
					}
					else
					{
						string type = item.GetProperty("type").GetString();
						string dataType = item.GetProperty("dataType").GetString();
						string keyType = item.GetProperty("keyType").GetString();
						string defaultValue = item.GetProperty("defaultValue").GetRawText();
						IBinaryHandler binaryHandler = BinaryHandlerFactory.GenerateHandler(new BinaryDataTypeData(type, keyType, dataType, defaultValue), true);
						binaryHandler.WriteValue(binaryWriter);
					}
				}
				catch (FormatException)
				{
					throw new FormatException($"Error at field \"{name}\": Type mismatch.");
				}
			}
		}
	}
}
