using System.Collections.Generic;
using System.Globalization;

namespace Binary_File_Converter
{
	class BinaryHandlerFactory
	{
		public static IBinaryHandler GenerateHandler(BinaryDataTypeData binaryDataTypeData, bool useDefault = false)
		{
			return binaryDataTypeData.TypeName switch
			{
				"int" => useDefault ? new IntBinaryHandler(initVal: int.Parse(binaryDataTypeData.DefaultValueStr)) : new IntBinaryHandler(),
				"float" => useDefault ? new FloatBinaryHandler(initVal: float.Parse(binaryDataTypeData.DefaultValueStr, CultureInfo.InvariantCulture.NumberFormat)) : new FloatBinaryHandler(),
				"string" => useDefault ? new StringBinaryHandler(initVal: binaryDataTypeData.DefaultValueStr) : new StringBinaryHandler(),
				"list" => new ListBinaryReader(type: binaryDataTypeData.DataTypeName),
				"dictionary" => new DictionaryBinaryReader(keyType: binaryDataTypeData.KeyTypeName, dataType: binaryDataTypeData.DataTypeName),
				_ => throw new KeyNotFoundException($"Type key {binaryDataTypeData.TypeName} not supported by factory.")
			};
		}
	}
}
