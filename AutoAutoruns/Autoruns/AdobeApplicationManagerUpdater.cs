using AutoAutoruns.Autoruns.Base;
using Microsoft.Win32;

namespace AutoAutoruns.Autoruns {

    public class AdobeApplicationManagerUpdater: RegistryAutorun {

        public override string name { get; } = "Adobe Application Manager Updater";

        protected override (RegistryKey hive, string path, string name) registryLocation { get; } = (Registry.LocalMachine,
            @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", "AdobeAAMUpdater-1.0");

    }

}