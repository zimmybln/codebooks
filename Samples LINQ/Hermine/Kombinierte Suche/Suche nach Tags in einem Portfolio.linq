<Query Kind="Statements">
  <Connection>
    <ID>ac5eb4c8-16c8-4e67-b6fa-6c41188e8449</ID>
    <Persist>true</Persist>
    <Driver>EntityFramework</Driver>
    <CustomAssemblyPathEncoded>&lt;Personal&gt;\Projekte\Hermine\Hermine\Bin\Hermine.Data.dll</CustomAssemblyPathEncoded>
    <CustomAssemblyPath>D:\Dokumente\Projekte\Hermine\Hermine\Bin\Hermine.Data.dll</CustomAssemblyPath>
    <CustomTypeName>Hermine.Data.HermineContent</CustomTypeName>
    <CustomMetadataPath>res://Hermine.Data/Data.HermineContent.csdl|res://Hermine.Data/Data.HermineContent.ssdl|res://Hermine.Data/Data.HermineContent.msl</CustomMetadataPath>
    <Provider>System.Data.VistaDB</Provider>
    <CustomCxString>Data Source=D:\Dokumente\Projekte\Hermine\Hermine\Bin\Data\Test.vdb4</CustomCxString>
  </Connection>
</Query>

Portfolio p = Portfolios.FirstOrDefault (po => po.Id == 27 );

var tg = from t in p.Entries.SelectMany (e => e.Tags).Distinct() select t.Name;

tg.Dump();