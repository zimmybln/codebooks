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

var query = (from p in Portfolios 
			select 
				new {
						Id = p.Id,
						Name = p.Name,
						Count = p.Entries.Count(e => e.State < 0)
				}).Where (q => q.Count > 0).OrderByDescending (q => q.Count);

query.Dump();
				
			