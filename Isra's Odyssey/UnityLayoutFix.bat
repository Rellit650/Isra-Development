@set directory="%AppData%\Unity\Editor-5.x\Preferences\Layouts\default\"
@set defultLayout="%directory%Default.wlt"
@set corruptLayout="%directory%LastLayout.dwlt"
@set projectLayout="Library\CurrentLayout-default.dwlt"

@echo Restoring project layout file...

@copy /b/v/y "%defultLayout%" "%projectLayout%"

@echo Restoring AppData last layout file...

@copy /b/v/y "%defultLayout%" "%corruptLayout%"

@echo Complete...

@pause