set name_bin=Bin
for /f "delims=" %%a in ('dir /ad /b /s "%name_bin%"') do rd /s /q "%%a" 2>nul

set name_obj=obj
for /f "delims=" %%a in ('dir /ad /b /s "%name_obj%"') do rd /s /q "%%a" 2>nul

set name_resharper=_Resharper*
for /f "delims=" %%a in ('dir /ad /b /s "%name_resharper%"') do rd /s /q "%%a" 2>nul