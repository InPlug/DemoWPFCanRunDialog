# DemoWPFCanRunDialog
Generiert eine Zusatzabfrage, die vor den Start eines Vishnu-Knotens geschaltet werden kann, um den Start ggf. noch verhindern zu können.
Die DemoWPFCanRunDialog.dll wird von Vishnu vor dem Start eines Knotens aufgerufen, wenn sie in der JopDescrition.xml
beim Checker über <CanRunDllPath>DemoWPFCanRunDialog.dll</CanRunDllPath> deklariert wurde.
Siehe auch den Test-Job ...VishnuHome\Tests\TestJobs\CheckCanRun.
