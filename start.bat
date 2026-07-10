@echo off
echo ===================================================
echo   LojistikYol Sistemi Baslatiliyor...
echo ===================================================
echo.

echo 1. Backend sunucusu (C# .NET + SQLite) baslatiliyor...
start "LojistikYol Backend" cmd /k "cd backend && dotnet run --urls http://localhost:5279"

echo.
echo 2. Mobil uygulama (Flutter) baslatiliyor...
echo Lutfen bagli bir emulator veya mobil cihazin acik oldugundan emin olun.
start "LojistikYol Frontend" cmd /k "cd frontend && flutter run"

echo.
echo ===================================================
echo Servisler baslatildi! 
echo Pencereleri kapatarak servisleri durdurabilirsiniz.
echo ===================================================
pause
