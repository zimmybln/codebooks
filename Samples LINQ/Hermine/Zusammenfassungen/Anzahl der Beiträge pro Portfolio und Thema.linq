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

// Anzahl der Einträge pro Portfolio und Thema (Portfolio WPF = ID 15)
var q2 = from Entry e in Entries where e.Portfolio.Id == 15 && e.ThemeId != null group e by e.ThemeId into f 
			select new {ThemeId = f.Key,
						Anzahl = f.Count (x => true)};
						
var q3 = from e in q2 join t in Themes on e.ThemeId equals t.Id orderby e.Anzahl, t.Name
			select new {ThemeId = e.ThemeId,
						Theme = t.Name,
						Anzahl = e.Anzahl};

q2.Dump();