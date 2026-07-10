Set WshShell = CreateObject("WScript.Shell")
WshShell.Run "cmd.exe /c cd /d C:\Users\Public\lojistikyol\backend && dotnet run --urls http://localhost:5279", 0
Set WshShell = Nothing
