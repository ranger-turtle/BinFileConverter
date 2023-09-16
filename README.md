# BinFileConverter

Binary File Converter is an app for converting binary files created using file handling methods from .NET standard library. It reads the JSON file containing info about types of data, since the program itself will not know how to read binary file properly
since binary files almost never contain info how the following data should be interpreted. After JSON blueprint is read, it read the binary file and writes, using output blueprint. Order of the data is determined by the order of identifiers saved in
"name" field in JSON files.
If the identifier is present in both input and output JSONs, the data associated with identifier will be copied to output.
For now, Binary File Converter supports strings, floats, ints, and lists and dictionaries of the listed primitives and the structure types themselves.
