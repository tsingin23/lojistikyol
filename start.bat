@echo off
echo ===================================================
echo   LojistikYol Sistemi Baslatiliyor...
echo ===================================================
echo.

echo 1. Backend sunucusu (C# .NET + SQLite) baslatiliyor...
start "LojistikYol Backend" cmd /k "cd backend && dotnet run --urls http://localhost:5279"

echo.
echo 2. Android emulator durumu kontrol ediliyor...
cd frontend

set "emu_id="
for /f "tokens=1" %%a in ('flutter emulators') do (
    if not "%%a"=="" (
        if not "%%a"=="Id" (
            if not "%%a"=="To" (
                if not "%%a"=="available" (
                    if not "%%a"=="You" (
                        set "emu_id=%%a"
                    )
                )
            )
        )
    )
)

if not "%emu_id%"=="" (
    echo Bulunan Emulator Kimligi: %emu_id%
    echo Emulator baslatiliyor (Lutfen bekleyin)...
    start "LojistikYol Emulator Launcher" cmd /c "flutter emulators --launch %emu_id%"
    echo Emulator baslatma sinyali gonderildi. 12 saniye bekleniyor...
    timeout /t 12 /nobreak >nul
) else (
    echo UYARI: Bilgisayarda tanimli Android emulator bulunamadi!
)

echo.
echo 3. Mobil uygulama (Flutter) baslatiliyor...
start "LojistikYol Frontend" cmd /k "flutter run -d android"

echo.
echo ===================================================
echo Servisler baslatildi! 
echo Pencereleri kapatarak servisleri durdurabilirsiniz.
echo ===================================================
pause
