using System;
using System.Collections.Generic;

namespace Binary_File_Converter
{
	class Program
	{
		static void Main(string[] args)
		{
			BinaryDataReader jSONBinaryInfoReader = new BinaryDataReader();
			Dictionary<string, IBinaryHandler> binaryDataDict = jSONBinaryInfoReader.ReadBinaryDataDictionary("dummy.dat", "input blueprint.json");
			new BinaryDataWriter().WriteBinaryDataDictionary("new dummy.dat", "output blueprint.json", binaryDataDict);
			Console.WriteLine("Success! Check out your result.");
		}
	}
}
