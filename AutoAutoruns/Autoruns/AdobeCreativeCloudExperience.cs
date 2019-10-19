using AutoAutoruns.Autoruns.Base;
using Microsoft.Win32;

namespace AutoAutoruns.Autoruns {

    public class AdobeCreativeCloudExperience: RegistryAutorun {

        public override string name { get; } = "Adobe Creative Cloud Experience";

        protected override (RegistryKey hive, string path, string name) registryLocation { get; } = (Registry.CurrentUser,
            @"Software\Microsoft\Windows\CurrentVersion\Run", "CCXProcess");

    }

}