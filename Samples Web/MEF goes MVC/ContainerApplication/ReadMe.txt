Verzeichnisstruktur

Das vorliegende Beispiel geht davon aus, dass es im Root des Webs ein Verzeichnis "Extensions" gibt. Dieses Verzeichnis wird in der Global.asax festgelegt. Relevant ist das für drei Bereiche:
1. Alle Unterverzeichnisse werden dem MEF Katalog hinzugefügt ("Extensions\PlugIn1", "Extensions\PlugIn2" usw.). Es wird davon ausgegangen, dass in diesen Unterverzeichnissen die Assemblies für die Erweiterungen liegen. (siehe Klasse MefConnector)
2. Wir tauschen die ControllerFactory aus. Diese ist dafür verantwortlich, dass aus einem Aufruf "~/Controller/Action" der Aufruf an ein konkretes Objekt wird. Wir klinken uns in diesen Prozess ein und schauen, ob es für den gesuchten Controller etwas im Mef-Katalog gibt. Ist das nicht der Fall (wie beispielsweise beim Aufruf von Standardseiten), wird das Standardverhalten angewendet.
3. Wir erstellen eine angepasste ViewEngine. Wenn ein Controller ein ViewResult oder ViewPartialResult zurückliefert, muss ein View angezeigt werden. Für die Auflösung des ViewResults ist die ViewEngine verantwortlich. Davon kann es in einer Anwendung mehrere geben (für die Kombination von Darstellungsvarianten) und wir fügen eine hinzu, die das Muster für die Suche nach Views um die Verzeichnisse der Erweiterungen ergänzt. Dafür verantwortlich ist die Klasse CustomViewEngine.


Weitere Ressourcen

MVC Source Code:
https://aspnetwebstack.codeplex.com/SourceControl/latest

Bekannte Herausforderungen
- Aktuell wird nicht zwischen Controller / View unterschieden (d.h. die Namen der Views müssen für alle Erweiterungen eindeutig sein, was natürlich unsinning ist). Lösungsansatz ist hier, den VirtualPathProvider auszutauschen.
- Schönes Beispiel für SingleResponsibilty: Die Logik zur Auflösung der Verzeichnisstruktur (~/Extensions/...) ist an mehreren Stellen zu finden. Nicht nur eine Codesequenz soll nicht für mehrere Aspekte verantwortlich sein, sondern auch für einen Aspekt sollen nicht mehrere Codesequenzen verantwortlich sein.

Nächste Schritte Infrastruktur
- Erweiterungen können Views mit dem gleichen Namen haben.


Die Abfrage einer Seite aus einer Erweiterung
BeginRequest
GetHttpHandler: /AdditionalController/SampleView causes MvcHandler

... Hier wird der Controller ermittelt und ausgewertet

FileExists: ~/AdditionalController/SampleView:True

Ausnahme ausgelöst: "Microsoft.CSharp.RuntimeBinder.RuntimeBinderException" in Microsoft.CSharp.dll
Ausnahme ausgelöst: "Microsoft.CSharp.RuntimeBinder.RuntimeBinderException" in Microsoft.CSharp.dll

FileExists: ~/Views/AdditionalController/SampleView.aspx:False
FileExists: ~/Views/AdditionalController/SampleView.ascx:False
FileExists: ~/Views/Shared/SampleView.aspx:False
FileExists: ~/Views/Shared/SampleView.ascx:False
FileExists: ~/Views/AdditionalController/SampleView.cshtml:False
FileExists: ~/Views/AdditionalController/SampleView.vbhtml:False
FileExists: ~/Views/Shared/SampleView.cshtml:False
FileExists: ~/Views/Shared/SampleView.vbhtml:False
FileExists: ~/Extensions/SecondPlugIn/Views/SampleView.cshtml:True
FileExists: ~/Extensions/SecondPlugIn/Views/SampleView.Mobile.cshtml:False
FileExists: ~/Extensions/SecondPlugIn/Views/_ViewStart.cshtml:False
FileExists: ~/Extensions/SecondPlugIn/Views/_ViewStart.vbhtml:False
FileExists: ~/Extensions/SecondPlugIn/_ViewStart.cshtml:False
FileExists: ~/Extensions/SecondPlugIn/_ViewStart.vbhtml:False
FileExists: ~/Extensions/_ViewStart.cshtml:False
FileExists: ~/Extensions/_ViewStart.vbhtml:False
FileExists: ~/_ViewStart.cshtml:False
FileExists: ~/_ViewStart.vbhtml:False
Ausnahme ausgelöst: "Microsoft.CSharp.RuntimeBinder.RuntimeBinderException" in Microsoft.CSharp.dll
Ausnahme ausgelöst: "Microsoft.CSharp.RuntimeBinder.RuntimeBinderException" in Microsoft.CSharp.dll
Ausnahme ausgelöst: "Microsoft.CSharp.RuntimeBinder.RuntimeBinderException" in Microsoft.CSharp.dll
Ausnahme ausgelöst: "Microsoft.CSharp.RuntimeBinder.RuntimeBinderException" in Microsoft.CSharp.dll
Ausnahme ausgelöst: "Microsoft.CSharp.RuntimeBinder.RuntimeBinderException" in Microsoft.CSharp.dll
Ausnahme ausgelöst: "Microsoft.CSharp.RuntimeBinder.RuntimeBinderException" in Microsoft.CSharp.dll
FileExists: ~/Views/Shared/_Layout.cshtml:True
FileExists: ~/Views/AdditionalController/SomePartialView.aspx:False
FileExists: ~/Views/AdditionalController/SomePartialView.ascx:False
FileExists: ~/Views/Shared/SomePartialView.aspx:False
FileExists: ~/Views/Shared/SomePartialView.ascx:False
FileExists: ~/Views/AdditionalController/SomePartialView.cshtml:False
FileExists: ~/Views/AdditionalController/SomePartialView.vbhtml:False
FileExists: ~/Views/Shared/SomePartialView.cshtml:False
FileExists: ~/Views/Shared/SomePartialView.vbhtml:False
FileExists: ~/Extensions/SecondPlugIn/Views/SomePartialView.cshtml:True
FileExists: ~/Extensions/SecondPlugIn/Views/SomePartialView.Mobile.cshtml:False
EndRequest
