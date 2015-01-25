<Query Kind="Statements" />

System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.AllCultures)
		.OrderBy (ci => ci.Name)
		.ToList()
		.ForEach(c => Debug.WriteLine(String.Format("{0}: {1}", c.Name, c.DisplayName)));