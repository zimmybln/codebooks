<Query Kind="Statements">
  <Connection>
    <ID>40173445-0b78-4c41-bda1-e14e864d1fa3</ID>
    <Persist>true</Persist>
    <Driver>EntityFramework</Driver>
    <CustomAssemblyPathEncoded>&lt;MyDocuments&gt;\SyncStation\Projekte\Hermine\Bin\Hermine.Data.dll</CustomAssemblyPathEncoded>
    <CustomAssemblyPath>D:\Dokumente\SyncStation\Projekte\Hermine\Bin\Hermine.Data.dll</CustomAssemblyPath>
    <CustomTypeName>Hermine.Data.HermineContent</CustomTypeName>
    <CustomMetadataPath>res://Hermine.Data/Data.HermineContent.csdl|res://Hermine.Data/Data.HermineContent.ssdl|res://Hermine.Data/Data.HermineContent.msl</CustomMetadataPath>
    <Provider>System.Data.VistaDB5</Provider>
    <CustomCxString>Data source=D:\Dokumente\Dropbox\softwareentwicklung.vdb5</CustomCxString>
  </Connection>
</Query>

var query = from e in Entries where e.State < 0
			orderby e.Modified descending
			select new {Id = e.Id,
						Name = e.Name,
						Modified = e.Modified,
						PortfolioName = e.Portfolio.Name,
						PortfolioId = e.Portfolio.Id};
						
query.Take(5).Dump();