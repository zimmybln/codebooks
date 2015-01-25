<Query Kind="Statements" />

string strSource = "User name {sales} Das ist auch {Beispielcode} Hier {ContentObject.Label}";
string strPattern = @"{(\w*|.*)}";

var results = Regex.Matches(strSource, strPattern);

foreach(Match m in results)
{
	m.Groups[1].Value.Dump();
}