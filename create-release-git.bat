@echo off
REM ========================================
REM Create Release Archive Script (Git-based)
REM ========================================
REM This script uses Git to automatically exclude
REM files listed in .gitignore
REM ========================================

setlocal enabledelayedexpansion

echo.
echo ========================================
echo   Creating Release Archive (Git-based)
echo ========================================
echo.

REM Check if Git is available
where git >nul 2>nul
if %errorlevel% neq 0 (
    echo ERROR: Git is not available!
    echo Please install Git or use create-release.bat instead.
    pause
    exit /b 1
)

REM Check if PowerShell is available
where powershell >nul 2>nul
if %errorlevel% neq 0 (
    echo ERROR: PowerShell is not available!
    echo Please install PowerShell to use this script.
    pause
    exit /b 1
)

REM Get current date for archive name
for /f "tokens=2 delims==" %%I in ('wmic os get localdatetime /value') do set datetime=%%I
set RELEASE_DATE=%datetime:~0,8%

REM Set version (you can change this)
set VERSION=v2.0.0
set ARCHIVE_NAME=CSharp-Unity-Course-%VERSION%-%RELEASE_DATE%.zip

echo Creating archive: %ARCHIVE_NAME%
echo Version: %VERSION%
echo Date: %RELEASE_DATE%
echo.

REM Create temporary directory
set TEMP_DIR=%TEMP%\release_temp_%RANDOM%
mkdir "%TEMP_DIR%"

echo Exporting files using Git...
echo.

REM Use git archive to export only tracked files (respects .gitignore)
git archive --format=zip --output="%TEMP_DIR%\temp.zip" HEAD

REM Extract to temp directory
powershell -Command "Expand-Archive -Path '%TEMP_DIR%\temp.zip' -DestinationPath '%TEMP_DIR%\extracted' -Force"

REM Remove temporary zip
del /Q "%TEMP_DIR%\temp.zip" >nul 2>&1

echo Files exported successfully!
echo.

REM Create final ZIP archive
echo Creating final ZIP archive...
powershell -Command "Compress-Archive -Path '%TEMP_DIR%\extracted\*' -DestinationPath '%CD%\%ARCHIVE_NAME%' -Force"

if %errorlevel% equ 0 (
    echo.
    echo ========================================
    echo   SUCCESS!
    echo ========================================
    echo.
    echo Archive created: %ARCHIVE_NAME%
    echo Location: %CD%\%ARCHIVE_NAME%
    echo.
    
    REM Get archive size
    for %%A in ("%ARCHIVE_NAME%") do set ARCHIVE_SIZE=%%~zA
    set /a ARCHIVE_SIZE_MB=!ARCHIVE_SIZE! / 1048576
    echo Archive size: !ARCHIVE_SIZE_MB! MB
    echo.
    
    REM Count files in archive
    powershell -Command "$count = (Get-ChildItem -Path '%TEMP_DIR%\extracted' -Recurse -File).Count; Write-Host 'Files included:' $count"
    echo.
) else (
    echo.
    echo ========================================
    echo   ERROR!
    echo ========================================
    echo.
    echo Failed to create archive!
    echo Please check the error messages above.
    echo.
)

REM Clean up temporary directory
echo Cleaning up temporary files...
rmdir /S /Q "%TEMP_DIR%" >nul 2>&1

echo.
echo ========================================
echo   Done!
echo ========================================
echo.
echo The archive is ready for release on GitHub!
echo.

pause
