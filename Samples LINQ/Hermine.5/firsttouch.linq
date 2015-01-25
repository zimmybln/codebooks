<Query Kind="Expression">
  <Connection>
    <ID>cefc5eb3-caf6-44b4-9e42-49ee34b70991</ID>
    <Persist>true</Persist>
    <Driver>EntityFramework</Driver>
    <CustomAssemblyPathEncoded>&lt;MyDocuments&gt;\Dropbox\Projekte\Hermine\Hermine\Bin\Hermine.Data.dll</CustomAssemblyPathEncoded>
    <CustomAssemblyPath>D:\Dokumente\Dropbox\Projekte\Hermine\Hermine\Bin\Hermine.Data.dll</CustomAssemblyPath>
    <CustomTypeName>Hermine.Data.HermineContent</CustomTypeName>
    <CustomMetadataPath>res://Hermine.Data/Data.HermineContent.csdl|res://Hermine.Data/Data.HermineContent.ssdl|res://Hermine.Data/Data.HermineContent.msl</CustomMetadataPath>
    <Provider>System.Data.VistaDB5</Provider>
    <CustomCxString>data source=D:\Dokumente\Dropbox\softwareentwicklung.vdb5</CustomCxString>
  </Connection>
</Query>

(from e in Entries select e).Dump()