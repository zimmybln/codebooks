<Query Kind="Statements">
  <Connection>
    <ID>87639016-22c7-4bf3-a043-188474d01b1a</ID>
    <Persist>true</Persist>
    <Driver>EntityFramework</Driver>
    <CustomAssemblyPathEncoded>&lt;ProgramFilesX86&gt;\Hermine\Hermine.Data.dll</CustomAssemblyPathEncoded>
    <CustomAssemblyPath>C:\Program Files (x86)\Hermine\Hermine.Data.dll</CustomAssemblyPath>
    <CustomTypeName>Hermine.Data.HermineContent</CustomTypeName>
    <CustomMetadataPath>res://Hermine.Data/Data.HermineContent.csdl|res://Hermine.Data/Data.HermineContent.ssdl|res://Hermine.Data/Data.HermineContent.msl</CustomMetadataPath>
    <Provider>System.Data.VistaDB</Provider>
    <CustomCxString>data source=D:\Dokumente\Dropbox\Softwareentwicklung.vdb4</CustomCxString>
  </Connection>
</Query>

// Ermitteln des Portfolios
Portfolio p = Portfolios.FirstOrDefault (px => px.Id == 28);

// Definition der zu suchenden Tags
IEnumerable<string> tags = new []{"Eins", "Drei"};

// Ermitteln der Tags
IEnumerable<Tag> arrTags = Tags.Where(x => tags.Contains(x.Name));

// arrTags.Dump();

List<Entry> arrEntries = new List<Entry>();

foreach(Tag tg in arrTags)
{
	IEnumerable<Entry> entries = p.Entries.Where (e => e.Tags.Contains(tg));
	if (entries != null && entries.Count () > 0)
		foreach(Entry e in entries)
			if (!arrEntries.Contains(e)) arrEntries.Add(e);
}

arrEntries.Dump();

// IEnumerable<Entry> entries = arrTags.Select(t => t.Portfolios.Contains(p));

// entries.Dump();

//IEnumerable<Entry> entries = p.Entries.Where(e => e.Tags.Contains(arrTags));

//entries.Dump();