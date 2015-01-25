<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.dll</Reference>
</Query>

string strTitle = "Golem.de: IT-News f&uuml;r Profis";

string strConverted = System.Web.HttpUtility.HtmlDecode(strTitle);

strConverted.Dump();