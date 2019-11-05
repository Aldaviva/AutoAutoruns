using AutoAutoruns.Autoruns.Base;
using Microsoft.Win32;

#nullable enable

namespace AutoAutoruns.Autoruns {

    public class AdobeAcrobatAssistant: RegistryAutorun {

        public override string name { get; } = "Acrobat Assistant";

        protected override (RegistryKey hive, string path, string name) registryLocation { get; } = (Registry.LocalMachine,
            @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Run", "Acrobat Assistant 8.0");

    }

}