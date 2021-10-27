using AutoAutoruns.Autoruns.Base;
using Microsoft.Win32;

#nullable enable

namespace AutoAutoruns.Autoruns {

    public class AdobeAcrobatSynchronizer: RegistryAutorun {

        public override string name { get; } = "Adobe Acrobat Synchronizer";

        protected override (RegistryKey hive, string path, string? name) registryLocation { get; } =
            (Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Run", "Adobe Acrobat Synchronizer");

    }

}