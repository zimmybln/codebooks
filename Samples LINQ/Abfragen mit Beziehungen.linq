<Query Kind="Statements">
  <Connection>
    <ID>14245437-abeb-43c5-999d-c638af96bfef</ID>
    <Persist>true</Persist>
    <Driver>EntityFramework</Driver>
    <Server>.\SQLEXPRESS</Server>
    <CustomAssemblyPathEncoded>&lt;Personal&gt;\My Dropbox\Codebooks\Samples LINQ\LINQSampleModel\LINQSampleModel\bin\Debug\LINQSampleModel.dll</CustomAssemblyPathEncoded>
    <CustomAssemblyPath>D:\Dokumente\My Dropbox\Codebooks\Samples LINQ\LINQSampleModel\LINQSampleModel\bin\Debug\LINQSampleModel.dll</CustomAssemblyPath>
    <CustomTypeName>LINQSampleModel.LINQ_SamplesEntities</CustomTypeName>
    <CustomMetadataPath>res://LINQSampleModel/Model1.csdl|res://LINQSampleModel/Model1.ssdl|res://LINQSampleModel/Model1.msl</CustomMetadataPath>
    <AttachFile>true</AttachFile>
    <UserInstance>true</UserInstance>
    <AttachFileName>&lt;Personal&gt;\My Dropbox\Codebooks\Samples LINQ\LINQSampleModel\LINQSampleModel\bin\Debug\LINQ Samples.mdf</AttachFileName>
  </Connection>
</Query>

// *** Ohne Berücksichtigung von Beziehungen ***
(from p in Persons 
	select new {FirstName = p.FirstName, LastName = p.LastName, Alben = p.Albums}).Dump("Einfache Datenabfrage");
	
// Berücksichtigung einer 1:n Beziehung
(from p in Persons 
	select new {FirstName = p.FirstName, LastName = p.LastName, City = p.Cities.Name}).Dump("Berücksichtigung einer 1:n Beziehung");

// Alle Personen, die mit Alben verbunden sind
(from p in Persons where p.Albums.Count() > 0 
	select new {FirstName = p.FirstName, LastName = p.LastName, City = p.Cities.Name, Alben = p.Albums}).Dump("Berücksichtigung einer n:m Beziehung");

(from p in Persons 
	where p.Albums.Count() > 0 && p.Cities.Name == "Liverpool" 
	select new {FirstName = p.FirstName, LastName = p.LastName, Alben = p.Albums}).Dump("Berücksichtigung einer n:m Beziehung mit Einschränkungen");

// (from p in Persons where p.Albums.Count (a => a.Name == "Imagine") > 0 select new {FirstName = p.FirstName, LastName = p.LastName, Alben = p.Albums}).Dump();

(from a in Albums
	where a.Persons.Count () == 0
	select new {Title = a.Name}).Dump();
	
(from a in Albums select a.Persons).Dump();


