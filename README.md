# Chrome Dark Mode Toggle

A portable Windows batch tool that switches both Chrome's interface and web content to dark mode, with an option to restore the system-default appearance.

## Usage

1. Download `ChromeDarkMode.bat`.
2. Double-click the file.
3. Enter `1` to enable full dark mode or `2` to restore the default appearance.

The tool closes all Chrome windows before applying the change, then restarts Chrome. Save any unfinished forms or unsent content before running it.

## Features

- Uses the built-in Windows PowerShell runtime; no additional installation is required.
- Updates existing Chrome profiles for the current Windows user.
- Covers Guest mode and newly created profiles through Chrome's dark-mode launch option.
- Removes only this tool's dark-mode flag when restoring, preserving other custom Chrome flags.
- Requires no administrator privileges and does not write Chrome policy registry keys.

## Requirements

- Windows 10 or Windows 11
- Google Chrome
- Windows PowerShell 5.1 or later

## Notes

Future Chrome releases may change the preferences format or dark-mode launch option. Retest the tool after major Chrome updates if its behavior changes.
