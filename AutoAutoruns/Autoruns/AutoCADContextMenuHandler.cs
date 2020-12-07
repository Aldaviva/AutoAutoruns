using AutoAutoruns.Autoruns.Base;
using Microsoft.Win32;

#nullable enable

namespace AutoAutoruns.Autoruns {

    public class AutoCADContextMenuHandler: RegistryAutorun {

        public override string name { get; } = "AutoCAD Context Menu Handler";

        protected override (RegistryKey hive, string path, string? name) registryLocation { get; } =
            (Registry.LocalMachine, @"SOFTWARE\Classes\*\shellex\ContextMenuHandlers\AcShellExtension.AcContextMenuHandler", null);

    }

}