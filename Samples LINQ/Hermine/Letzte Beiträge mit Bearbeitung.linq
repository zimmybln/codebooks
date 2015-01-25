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

var query = from e in Entries join c in Contents on e.Id equals c.EntryId
			orderby e.Modified descending
			select new {Id = e.Id,
						Name = e.Name,
						Modified = e.Modified,
						PortfolioName = e.Portfolio.Name,
						PortfolioId = e.Portfolio.Id};
						
query.Take(5).Dump();
