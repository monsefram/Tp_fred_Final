!include "MUI2.nsh"


Name "Meteo-2343214"
OutFile "Meteo-2343214_Setup.exe"
InstallDir "$PROGRAMFILES64\Meteo-2343214"

!define MUI_ICON "meteo.ico"
!define MUI_UNICON "meteo.ico"


!insertmacro MUI_PAGE_WELCOME
!insertmacro MUI_PAGE_LICENSE "licence.txt"
!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_PAGE_INSTFILES
!insertmacro MUI_PAGE_FINISH

!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_UNPAGE_INSTFILES
!insertmacro MUI_UNPAGE_FINISH


!insertmacro MUI_LANGUAGE "French"
!insertmacro MUI_LANGUAGE "English"


Section "Installation"

    SetOutPath "$INSTDIR"

    File /r "..\Tp_Final_Fred\bin\Release\net6.0-windows\publish\win-x64\*.*"

    CreateDirectory "$SMPROGRAMS\Meteo-2343214"
    CreateShortcut "$SMPROGRAMS\Meteo-2343214\Meteo-2343214.lnk" \
        "$INSTDIR\Tp_Final_Fred.exe"

    WriteUninstaller "$INSTDIR\Uninstall.exe"

SectionEnd


Section "Uninstall"

    Delete "$INSTDIR\Tp_Final_Fred.exe"
    Delete "$INSTDIR\Uninstall.exe"

    RMDir /r "$INSTDIR"
    RMDir /r "$SMPROGRAMS\Meteo-2343214"

SectionEnd
