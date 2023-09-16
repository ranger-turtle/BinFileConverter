namespace Binary_File_Converter
{
	struct BinaryDataTypeData
	{
		//public string Name { get; set; }
		public string TypeName { get; set; }
		public string DataTypeName { get; set; }
		public string KeyTypeName { get; set; }
		public string DefaultValueStr { get; set; }

		public BinaryDataTypeData(string typeName) : this()
		{
			//Name = name;
			TypeName = typeName;
		}

		//public BinaryDataTypeData(string typeName, string dataTypeName) : this(typeName)
		//{
		//	DataTypeName = dataTypeName;
		//}

		public BinaryDataTypeData(string typeName, string keyTypeName, string dataTypeName) : this(typeName)
		{
			//TypeName = typeName;
			DataTypeName = dataTypeName;
			KeyTypeName = keyTypeName;
			DefaultValueStr = string.Empty;
		}

		public BinaryDataTypeData(string typeName, string keyTypeName, string dataTypeName, string defaultValueStr) : this(typeName, keyTypeName, dataTypeName)
		{
			DefaultValueStr = defaultValueStr;
		}
	}
}
