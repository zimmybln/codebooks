TODOs
- Der Zustand wird bis zur Änderung an den Eigenschaften gecacht: Die Abfrage nach dem gültigen Status bewirkt damit nicht jedesmal eine Neuberechnung


- Gültigkeiten eines Status:
	- Wenn eine definierte Datenkonstellation erfüllt ist, darf ein Status betreten werden
	- Wenn eine definierte Datenkonstellation erfüllt ist, darf ein Status verlassen werden


- Statusübergänge können über explizite Methoden ausgeführt werden. Alternativ sind auch Commands möglich.

- Wenn versucht wird, in einen ungültigen Status zu wechseln, erfolgt eine Fehlermeldung.

Umgang mit den Daten
-> Es gibt Daten, die haben für den Status keine Bedeutung
-> Es gibt Daten, die haben für einzelne Status nur teilweise eine Bedeutung
-> Es gibt Daten, die haben für jeden Status eine Bedeutung


Links
http://www.codeproject.com/Articles/509234/The-State-Design-Pattern-vs-State-Machine
http://stackoverflow.com/questions/5923767/simple-state-machine-example-in-c
https://social.msdn.microsoft.com/Forums/vstudio/de-DE/d2e4786a-7dbb-4bca-a505-346216aa402f/praxisnahes-beispiel-fr-eine-statemachine-in-c-gerne-getrnkeautomat?forum=visualcsharpde
http://www.dofactory.com/net/state-design-pattern
http://www.codeguru.com/columns/experts/working-with-state-machines-in-the-.net-framework.htm

http://blogs.msdn.com/b/nblumhardt/archive/2009/04/16/state-machines-in-domain-models.aspx



