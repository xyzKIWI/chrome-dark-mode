using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

[assembly: AssemblyTitle("Chrome Dark Mode Tool")]
[assembly: AssemblyDescription("Toggle Chrome and web content between dark mode and the default appearance.")]
[assembly: AssemblyCompany("KIWI")]
[assembly: AssemblyProduct("Chrome Dark Mode Tool")]
[assembly: AssemblyCopyright("Copyright (c) 2026 KIWI")]
[assembly: AssemblyVersion("1.1.0.0")]
[assembly: AssemblyFileVersion("1.1.0.0")]

internal static class Program
{
    private const string ResourceName = "ChromeDarkMode.Payload";
    private const string ScriptMarker = "#CHROME_DARK_MODE_POWERSHELL";

    [DllImport("kernel32.dll")]
    private static extern bool SetConsoleCP(uint codePageId);

    [DllImport("kernel32.dll")]
    private static extern bool SetConsoleOutputCP(uint codePageId);

    private static int Main()
    {
        try
        {
            SetConsoleCP(65001);
            SetConsoleOutputCP(65001);
            Console.InputEncoding = new UTF8Encoding(false);
            Console.OutputEncoding = new UTF8Encoding(false);

            string payload = ReadEmbeddedPayload();
            int markerIndex = payload.LastIndexOf(ScriptMarker, StringComparison.Ordinal);
            if (markerIndex < 0)
            {
                throw new InvalidDataException("The embedded PowerShell payload marker was not found.");
            }

            string script = payload.Substring(markerIndex + ScriptMarker.Length)
                .TrimStart('\r', '\n');
            string encodedScript = Convert.ToBase64String(Encoding.Unicode.GetBytes(script));

            string powershellPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.System),
                "WindowsPowerShell",
                "v1.0",
                "powershell.exe"
            );

            if (!File.Exists(powershellPath))
            {
                throw new FileNotFoundException("Windows PowerShell was not found.", powershellPath);
            }

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = powershellPath,
                Arguments = "-NoLogo -NoProfile -ExecutionPolicy Bypass -EncodedCommand " + encodedScript,
                UseShellExecute = false,
                CreateNoWindow = false,
                WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory
            };

            using (Process process = Process.Start(startInfo))
            {
                if (process == null)
                {
                    throw new InvalidOperationException("Windows PowerShell could not be started.");
                }

                process.WaitForExit();
                return process.ExitCode;
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Chrome Dark Mode Tool could not start:");
            Console.Error.WriteLine(ex.Message);
            Console.Error.WriteLine();
            Console.Error.Write("Press Enter to close this window...");
            Console.ReadLine();
            return 1;
        }
    }

    private static string ReadEmbeddedPayload()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        using (Stream stream = assembly.GetManifestResourceStream(ResourceName))
        {
            if (stream == null)
            {
                throw new InvalidDataException("The embedded Chrome Dark Mode payload is missing.");
            }

            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8, true))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
