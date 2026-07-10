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

:: Check if ADB can see a running emulator
adb devices >temp.txt 2>nul
findstr /i "device" temp.txt | findstr /i "emulator" >nul
if errorlevel 1 (
    echo Emulator kapali, baslatiliyor...
    if exist "%USERPROFILE%\AppData\Local\Android\sdk\emulator\emulator.exe" (
        set "ANDROID_HOME=%USERPROFILE%\AppData\Local\Android\sdk"
        set "ANDROID_SDK_ROOT=%USERPROFILE%\AppData\Local\Android\sdk"
        set "ANDROID_USER_HOME=%USERPROFILE%\.android"
        set "ANDROID_AVD_HOME=%USERPROFILE%\.android\avd"
        start "LojistikYol Emulator" "%USERPROFILE%\AppData\Local\Android\sdk\emulator\emulator.exe" -avd Medium_Phone_API_36.1 -gpu swiftshader_indirect
    ) else (
        set "emu_id="
        for /f "tokens=1" %%a in ('flutter emulators ^| findstr /i "android" ^| findstr /v /i "http" ^| findstr /v /i "platform"') do (
            set "emu_id=%%a"
        )
        if not "%emu_id%"=="" (
            start "LojistikYol Emulator Launcher" cmd /c "flutter emulators --launch %emu_id%"
        )
    )
    echo Emulatorun acilmasi icin 15 saniye bekleniyor...
    timeout /t 15 /nobreak >nul
) else (
    echo Emulator zaten acik durumda.
)
del temp.txt >nul 2>&1

echo.
echo 3. Mobil uygulama (Flutter) baslatiliyor...
start "LojistikYol Frontend" cmd /k "flutter run -d android"

echo.
echo ===================================================
echo Servisler baslatildi! 
echo Pencereleri kapatarak servisleri durdurabilirsiniz.
echo ===================================================
pause
