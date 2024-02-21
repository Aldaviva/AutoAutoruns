#nullable enable

using AutoAutoruns.Autoruns.Base;
using Microsoft.Win32;

namespace AutoAutoruns.Autoruns;

public class AutoCADColumnHandler: RegistryAutorun {

    public override string name { get; } = "AutoCAD Column Handler";

    protected override (RegistryKey hive, string path, string? name) registryLocation { get; } =
        (Registry.LocalMachine, @"SOFTWARE\Classes\Folder\shellex\ColumnHandlers\{8A0BC933-7552-42E2-A228-3BE055777227}", null);

}