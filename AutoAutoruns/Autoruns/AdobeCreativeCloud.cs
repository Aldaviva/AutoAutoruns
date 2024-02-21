#nullable enable

using AutoAutoruns.Autoruns.Base;
using Microsoft.Win32;

namespace AutoAutoruns.Autoruns;

public class AdobeCreativeCloud: RegistryAutorun {

    public override string name { get; } = "Adobe Creative Cloud";

    protected override (RegistryKey hive, string path, string name) registryLocation { get; } =
        (Registry.LocalMachine, @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Run", "Adobe Creative Cloud");

}