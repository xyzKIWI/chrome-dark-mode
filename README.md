# Browser Dark Mode Tool

A portable Windows tool that switches supported browser interfaces and web content to dark mode, with options to restore the system-default appearance.

## Usage

1. Download [`ChromeDarkModeTool.exe`](https://github.com/xyzKIWI/chrome-dark-mode/releases/latest/download/ChromeDarkModeTool.exe).
2. Double-click the file.
3. Select one browser or apply the change to all supported browsers.

The tool closes the selected browsers before applying the change. Save any unfinished forms or unsent content before running it.

## Supported browsers

- Google Chrome
- Perplexity Comet
- Microsoft Edge
- Internet Explorer, when it is available on the installed Windows version

## Features

- Uses the built-in Windows PowerShell runtime; no additional installation is required.
- Ships as one portable executable with an embedded day/night icon and script.
- Updates existing Chromium browser profiles for the current Windows user.
- Covers Guest mode and newly created profiles through the dark-mode launch option.
- Removes only this tool's dark-mode flag when restoring, preserving other custom browser flags.
- Provides individual controls plus enable-all and restore-all options.
- Uses a local stylesheet for Internet Explorer without changing Chromium policy registry keys.
- Requires no administrator privileges.

## Requirements

- Windows 10 or Windows 11
- At least one supported browser
- Windows PowerShell 5.1 or later

## Notes

Future browser releases may change their preferences format or dark-mode launch options. Retest the tool after major browser updates if its behavior changes.

The executable is not code-signed, so Windows SmartScreen may display a warning. The release notes include its SHA-256 checksum for verification.

## Source and build

`ChromeDarkMode.bat` contains the English PowerShell implementation embedded in the executable. `src/ChromeDarkModeLauncher.cs` is the small launcher that writes the embedded script to a randomly named temporary file, runs it, and deletes it after PowerShell exits. The executable can be rebuilt with the .NET Framework C# compiler included with Windows:

```powershell
& "$env:WINDIR\Microsoft.NET\Framework64\v4.0.30319\csc.exe" /nologo /target:exe /platform:anycpu /win32icon:ChromeDarkMode.ico /resource:ChromeDarkMode.bat,ChromeDarkMode.Payload /out:ChromeDarkModeTool.exe src\ChromeDarkModeLauncher.cs
```
