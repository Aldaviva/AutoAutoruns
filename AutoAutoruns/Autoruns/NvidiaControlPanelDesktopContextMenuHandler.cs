#nullable enable

using AutoAutoruns.Autoruns.Base;
using Microsoft.Win32;

namespace AutoAutoruns.Autoruns;

public class NvidiaControlPanelDesktopContextMenuHandler: RegistryAutorun {

    public override string name { get; } = "Nvidia Control Panel Desktop Context";

    protected override (RegistryKey hive, string path, string? name) registryLocation { get; } =
        (hive: Registry.LocalMachine,
         path: @"SOFTWARE\Classes\Directory\Background\shellex\ContextMenuHandlers\NvCplDesktopContext",
         name: null);

}