# DemoWPFCanRunDialog
Generiert eine Zusatzabfrage, die vor den Start eines Vishnu-Knotens geschaltet werden kann, um den Start ggf. noch verhindern zu können.
Die DemoWPFCanRunDialog.dll wird von Vishnu vor dem Start eines Knotens aufgerufen, wenn sie in der JopDescrition.xml
beim Checker über <CanRunDllPath>DemoWPFCanRunDialog.dll</CanRunDllPath> deklariert wurde.
Siehe auch den Test-Job ...VishnuHome\Tests\TestJobs\CheckCanRun.

## Einsatzbereich

  - Dieses Repository gehört, wie auch alle anderen unter **InPlug** liegenden Projekte, zum
   Repository **Vishnu** (https://github.com/VishnuHome/Vishnu) und ist auch nur für den Einsatz mit Vishnu konzipiert.

## Voraussetzungen, Schnellstart, Quellcode und Entwicklung

  - Weitere Ausführungen findest du im Repository [TrueFalseExceptionChecker](https://github.com/InPlug/TrueFalseExceptionChecker).
