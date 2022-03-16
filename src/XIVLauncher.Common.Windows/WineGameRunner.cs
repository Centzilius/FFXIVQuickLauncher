using System.Collections.Generic;
using System.Diagnostics;
using Serilog;
using XIVLauncher.Common.Dalamud;
using XIVLauncher.Common.PlatformAbstractions;

namespace XIVLauncher.Common.Windows;

public class WineGameRunner : IGameRunner
{
    private readonly DalamudLauncher dalamudLauncher;
    private readonly bool dalamudOk;
    private readonly DalamudLoadMethod loadMethod;

    public WineGameRunner(DalamudLauncher dalamudLauncher, bool dalamudOk, DalamudLoadMethod loadMethod)
    {
        this.dalamudLauncher = dalamudLauncher;
        this.dalamudOk = dalamudOk;
        this.loadMethod = loadMethod;
    }

    public Process Start(string path, string workingDirectory, string arguments, IDictionary<string, string> environment, DpiAwareness dpiAwareness)
    {
        Process game = new Process();
        Process.Start("wine", "\"" + path + "\" " + arguments);

        return game;
    }
}
