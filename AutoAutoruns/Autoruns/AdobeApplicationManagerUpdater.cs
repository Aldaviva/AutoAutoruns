using Microsoft.Win32;

namespace AutoAutoruns.Autoruns {

    public class AdobeApplicationManagerUpdater: RegistryAutorun {

        public override string Name { get; } = "Adobe Application Manager Updater";

        protected override (RegistryKey hive, string path, string name) RegistryLocation { get; } = (Registry.LocalMachine,
            @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", "AdobeAAMUpdater-1.0");

    }

}