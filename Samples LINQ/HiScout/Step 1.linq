<Query Kind="Statements">
  <Reference Relative="..\..\..\..\Projekte\HiScout\Sources SVN\HiScout\bin\HiScoutAsObject.dll">&lt;MyDocuments&gt;\Projekte\HiScout\Sources SVN\HiScout\bin\HiScoutAsObject.dll</Reference>
  <Reference Relative="..\..\..\..\Projekte\HiScout\Sources SVN\HiScout\bin\HiScoutClientUtils.dll">&lt;MyDocuments&gt;\Projekte\HiScout\Sources SVN\HiScout\bin\HiScoutClientUtils.dll</Reference>
  <Reference Relative="..\..\..\..\Projekte\HiScout\Sources SVN\HiScout\bin\HiScoutTools.dll">&lt;MyDocuments&gt;\Projekte\HiScout\Sources SVN\HiScout\bin\HiScoutTools.dll</Reference>
  <Reference Relative="..\..\..\..\Projekte\HiScout\Sources SVN\HiScout\bin\HiScoutTypes.dll">&lt;MyDocuments&gt;\Projekte\HiScout\Sources SVN\HiScout\bin\HiScoutTypes.dll</Reference>
  <Namespace>HiScout.AsObject</Namespace>
</Query>

using (var runtime = new HiScoutRuntime("TestTZ", "dev-adhara", 8085))
{
	Objects obj = runtime.UseContentObjects(2870)
							.FromFolder(58099);
	
	obj.Enumerate(x => x.Label.Dump());
}