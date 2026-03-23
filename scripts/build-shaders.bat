@echo off

set "COMPILER_DIR=%~dp0..\src\Morningstar\Assets\Effects\Compiler"
set "COMPILER_EXE=EasyXnb.exe"
set "COMPILER_PATH=%COMPILER_DIR%\%COMPILER_EXE%"

set "SOURCE_DIR=%~dp0..\src\Morningstar\Assets\Effects\Source"

rem Validate compiler directory
if not exist "%COMPILER_DIR%" (
    echo [ERROR] Compiler directory not found:
    echo "%COMPILER_DIR%"

    exit /B 1
)

rem Validate compiler executable
if not exist "%COMPILER_PATH%" (
    echo [ERROR] Compiler executable not found:
    echo "%COMPILER_PATH%"

    exit /B 1
)

rem Validate source directory
if not exist "%SOURCE_DIR%" (
    echo [ERROR] Source directory not found:
    echo "%SOURCE_DIR%"

    exit /B 1
)

echo [INFO] Compiling shaders from:
echo "%SOURCE_DIR%"
echo.

rem Changes the working directory
pushd "%COMPILER_DIR%" >nul

"%COMPILER_EXE%" "%SOURCE_DIR%"

set "RESULT=%ERRORLEVEL%"

rem Restores the previous working directory
popd >nul

echo.

if not %RESULT% == 0 (
    echo [ERROR] Compilation failed with error code: %RESULT%.

    exit /B %RESULT%
)

echo [INFO] Compilation succeeded.

exit /B 0
