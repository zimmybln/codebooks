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
- Beim Beginn einer Anfrage wird die Verbindung zur Datenbank hergestellt und als globale Ressource zur Verfügung gestellt. Alle Bestandteile der Abfrage (einschließlich die Erweiterungen) teilen sich diese Verbindung. Am Ende des Requests wird die Verbindung wieder geschlossen.
- Erweiterungen können Views mit dem gleichen Namen haben.
