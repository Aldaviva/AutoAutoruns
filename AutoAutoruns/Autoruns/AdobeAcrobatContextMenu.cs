#nullable enable

using AutoAutoruns.Autoruns.Base;
using Microsoft.Win32;

namespace AutoAutoruns.Autoruns;

public abstract class AdobeAcrobatContextMenu: RegistryAutorun {

    public sealed override string name { get; } = "Adobe Acrobat Context Menu";

    protected abstract string registryPath { get; }
    protected virtual string? registryName => null;

    protected sealed override (RegistryKey hive, string path, string? name) registryLocation =>
        (hive: Registry.LocalMachine, path: registryPath, name: registryName);

}

public class AdobeAcrobatContextMenuWildcardContextMenuHandlers: AdobeAcrobatContextMenu {

    protected override string registryPath { get; } = @"SOFTWARE\Classes\*\shellex\ContextMenuHandlers\Adobe.Acrobat.ContextMenu";

}

public class AdobeAcrobatContextMenuFolderContextMenuHandlers: AdobeAcrobatContextMenu {

    protected override string registryPath { get; } = @"SOFTWARE\Classes\Folder\shellex\ContextMenuHandlers\Adobe.Acrobat.ContextMenu";

}

public class AdobeAcrobatContextMenuApprovedShellExtension: AdobeAcrobatContextMenu {

    protected override string registryPath { get; } = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Shell Extensions\Approved";
    protected override string registryName { get; } = "{A6595CD1-BF77-430A-A452-18696685F7C7}";

}