<Query Kind="Program" />

	interface ITest
	{
		int v1 { get; set; }
	}

void Main()
{
	    (from p in typeof (ITest).GetProperties()
                                        select new{Name = p.Name, CanRead = p.CanRead, CanWrite = p.CanWrite}).Dump();
}

// Define other methods and classes here
