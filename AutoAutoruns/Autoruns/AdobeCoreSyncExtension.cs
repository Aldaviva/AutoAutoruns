#nullable enable

using AutoAutoruns.Autoruns.Base;
using Microsoft.Win32;

namespace AutoAutoruns.Autoruns;

public abstract class AdobeCoreSyncExtension: RegistryAutorun {

    public sealed override string name { get; } = "Adobe Creative Cloud Core Sync Extension";

    protected abstract string registryPath { get; }

    protected sealed override (RegistryKey hive, string path, string? name) registryLocation =>
        (hive: Registry.LocalMachine, path: registryPath, name: null);

}

public class AdobeCoreSyncExtensionWildcardContextMenuHandlers: AdobeCoreSyncExtension {

    protected override string registryPath { get; } = @"SOFTWARE\Classes\*\shellex\ContextMenuHandlers\AccExt";

}

public class AdobeCoreSyncExtensionFolderContextMenuHandlers: AdobeCoreSyncExtension {

    protected override string registryPath { get; } = @"SOFTWARE\Classes\Folder\shellex\ContextMenuHandlers\AccExt";

}

public class AdobeCoreSyncExtensionIcon(int number): AdobeCoreSyncExtension {

    protected override string registryPath =>
        $@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\ShellIconOverlayIdentifiers\   AccExtIco{number}";

}