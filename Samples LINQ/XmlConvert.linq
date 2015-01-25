<Query Kind="Statements" />

string strValue = "<<!-- Hallo , $%>";

string strConverted = XmlConvert.EncodeName(strValue);

strConverted.Dump();

string strReconverted = XmlConvert.DecodeName(strConverted);

strReconverted.Dump();
