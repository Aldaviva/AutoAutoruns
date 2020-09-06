using AutoAutoruns.Autoruns.Base;
using Microsoft.Win32;

#nullable enable

namespace AutoAutoruns.Autoruns {

    public class AdobeCreativeCloudExperienceProcess: RegistryAutorun {

        public override string name { get; } = "Adobe Creative Cloud Experience Process";

        protected override (RegistryKey hive, string path, string name) registryLocation { get; } = (Registry.LocalMachine,
            @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Run", "Adobe CCXProcess");

    }

}