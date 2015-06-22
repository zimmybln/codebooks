Features
- Definition von Status (als Enum) und deren G�ltigkeiten (anhand von Daten, Ausdr�cken etc.)
- Die Suche nach dem aktuell g�ltigen Status kann von au�en initiiert werden
- Der aktuelle Status kann als Eigenschaften abgefragt werden


Zusammenspiel zwischen Daten und Statemachine
- Die Daten l�sen bei �nderungen die �berpr�fung der Statemachine aus. Wann das passiert, liegt in der Verantwortung der Daten und wird ausschlie�lich dort konfiguriert
- Das k�nnte ein "Guard" sein, dem die Instanz der Statemachine �bergeben wird.



TODOs
- Der Zustand wird bis zur �nderung an den Eigenschaften gecacht: Die Abfrage nach dem g�ltigen Status bewirkt damit nicht jedesmal eine Neuberechnung


- G�ltigkeiten eines Status:
	- Wenn eine definierte Datenkonstellation erf�llt ist, darf ein Status betreten werden
	- Wenn eine definierte Datenkonstellation erf�llt ist, darf ein Status verlassen werden


- Status�berg�nge k�nnen �ber explizite Methoden ausgef�hrt werden. Alternativ sind auch Commands m�glich.

- Wenn versucht wird, in einen ung�ltigen Status zu wechseln, erfolgt eine Fehlermeldung.

Umgang mit den Daten
-> Es gibt Daten, die haben f�r den Status keine Bedeutung
-> Es gibt Daten, die haben f�r einzelne Status nur teilweise eine Bedeutung
-> Es gibt Daten, die haben f�r jeden Status eine Bedeutung


Links
http://www.codeproject.com/Articles/509234/The-State-Design-Pattern-vs-State-Machine
http://stackoverflow.com/questions/5923767/simple-state-machine-example-in-c
https://social.msdn.microsoft.com/Forums/vstudio/de-DE/d2e4786a-7dbb-4bca-a505-346216aa402f/praxisnahes-beispiel-fr-eine-statemachine-in-c-gerne-getrnkeautomat?forum=visualcsharpde
http://www.dofactory.com/net/state-design-pattern
http://www.codeguru.com/columns/experts/working-with-state-machines-in-the-.net-framework.htm

http://blogs.msdn.com/b/nblumhardt/archive/2009/04/16/state-machines-in-domain-models.aspx



