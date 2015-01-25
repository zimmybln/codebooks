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

var query = from e in Entries
			group e by e.Name.Substring(0, 1) into g
			orderby g.Count ()
			select new {k = g.Key,
						count = g.Count()};
					
						
			
Entries.Count ().Dump();
query.Dump();

//var query2 = from p in Portfolios join g in query on p.Id equals g.Id
//			orderby g.count descending
//			select new {
//						Id = p.Id,
//						Name = p.Name,
//						Count = g.count};
//						
//query2.Dump();