<Query Kind="Statements">
  <Connection>
    <ID>037a8b37-d49b-43e3-b7a4-94ab5b1cd0ce</ID>
    <Persist>true</Persist>
    <Driver>EntityFramework</Driver>
    <CustomAssemblyPath>C:\Users\Torsten\SyncStation\Projekte\Hermine\Bin\Hermine.Data.dll</CustomAssemblyPath>
    <CustomTypeName>Hermine.Data.HermineContent</CustomTypeName>
    <CustomMetadataPath>res://Hermine.Data/Data.HermineContent.csdl|res://Hermine.Data/Data.HermineContent.ssdl|res://Hermine.Data/Data.HermineContent.msl</CustomMetadataPath>
    <Provider>System.Data.VistaDB5</Provider>
    <CustomCxString>data source=C:\Users\Torsten\Dropbox\Softwareentwicklung.vdb5</CustomCxString>
  </Connection>
</Query>

var q1 = (from Entry e in Entries group e by e.Portfolio.Id into f 
	select new {MaxDate = f.Max (x => x.Modified),
				MinDate = f.Min (x => x.Modified),
				Id = f.Key}).OrderBy(q => q.MaxDate);

q1.Dump();