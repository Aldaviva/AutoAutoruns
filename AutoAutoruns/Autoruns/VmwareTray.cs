#nullable enable

using AutoAutoruns.Autoruns.Base;
using Microsoft.Win32;

namespace AutoAutoruns.Autoruns;

public class VmwareTray: RegistryAutorun {

    public override string name { get; } = "VMware Tray";

    protected override (RegistryKey hive, string path, string name) registryLocation { get; } =
        (Registry.LocalMachine, @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Run", "vmware-tray.exe");

}