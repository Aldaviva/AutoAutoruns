#nullable enable

using AutoAutoruns.Autoruns.Base;
using Microsoft.Win32;

namespace AutoAutoruns.Autoruns {

    public class VMDiskMenuHandler: RegistryAutorun {

        public override string name { get; } = "VMware Disk Menu Handler";

        protected override (RegistryKey hive, string path, string? name) registryLocation { get; } =
            (Registry.LocalMachine, @"SOFTWARE\Classes\Drive\shellex\ContextMenuHandlers\VMDiskMenuHandler64", null);

    }

}