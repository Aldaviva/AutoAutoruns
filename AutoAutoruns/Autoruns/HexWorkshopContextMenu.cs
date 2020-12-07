#nullable enable

using AutoAutoruns.Autoruns.Base;
using Microsoft.Win32;

namespace AutoAutoruns.Autoruns {

    public class HexWorkshopContextMenu: RegistryAutorun {

        public override string name { get; } = "Hex Workshop Context Menu";

        protected override (RegistryKey hive, string path, string? name) registryLocation { get; } =
            (Registry.LocalMachine, @"SOFTWARE\Classes\Drive\shellex\ContextMenuHandlers\HexWorkshopContextMenu", null);

    }

}