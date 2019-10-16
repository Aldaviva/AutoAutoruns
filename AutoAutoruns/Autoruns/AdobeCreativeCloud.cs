using Microsoft.Win32;

namespace AutoAutoruns.Autoruns {

    public class AdobeCreativeCloud: RegistryAutorun {

        public override string Name { get; } = "Adobe Creative Cloud";

        protected override (RegistryKey hive, string path, string name) RegistryLocation { get; } = (Registry.LocalMachine,
            @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Run", "Adobe Creative Cloud");

    }

}