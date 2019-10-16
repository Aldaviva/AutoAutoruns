using Microsoft.Win32;

namespace AutoAutoruns.Autoruns {

    public class AcrobatAssistant: RegistryAutorun {

        public override string Name { get; } = "Acrobat Assistant";

        protected override (RegistryKey hive, string path, string name) RegistryLocation { get; } = (Registry.LocalMachine,
            @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Run", "Acrobat Assistant 8.0");

    }

}