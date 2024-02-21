#nullable enable

using AutoAutoruns.Autoruns.Base;
using Microsoft.Win32;

namespace AutoAutoruns.Autoruns;

public abstract class NvidiaShellExtensions: RegistryAutorun {

    protected override (RegistryKey hive, string path, string? name) registryLocation =>
        (hive: Registry.LocalMachine,
         path: @"SOFTWARE\Microsoft\Windows\CurrentVersion\Shell Extensions\Approved",
         name: registryName);

    protected abstract string? registryName { get; }

}

public class NvidiaAppShellExtensions: NvidiaShellExtensions {

    public override string name { get; } = "Nvidia App Shell Extensions";

    protected override string registryName { get; } = "{A929C4CE-FD36-4270-B4F5-34ECAC5BD63C}";

}

public class NvidiaOpenGlShellExtensions: NvidiaShellExtensions {

    public override string name { get; } = "OpenGL Shell Extensions";

    protected override string registryName { get; } = "{E97DEC16-A50D-49bb-AE24-CF682282E08D}";

}

public class NvidiaControlPanelDesktopContextClassApprovedShellExtension: NvidiaShellExtensions {

    public override string name { get; } = "Nvidia Control Panel Desktop Context Class";

    protected override string registryName { get; } = "{A70C977A-BF00-412C-90B7-034C51DA2439}";

}

public class NvidiaPlayOnMyTvContextMenuExtension: NvidiaShellExtensions {

    public override string name { get; } = "Nvidia Play On My TV Context Menu Extension";

    protected override string registryName { get; } = "{3D1975AF-48C6-4f8e-A182-BE0E08FA86A9}";

}