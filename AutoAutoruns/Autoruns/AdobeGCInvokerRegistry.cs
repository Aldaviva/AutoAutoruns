using AutoAutoruns.Autoruns.Base;
using Microsoft.Win32;

#nullable enable

namespace AutoAutoruns.Autoruns {

    public class AdobeGCInvokerRegistry: RegistryAutorun {

        public override string name { get; } = "Adobe GC Invoker Utility (Registry)";

        protected override (RegistryKey hive, string path, string? name) registryLocation { get; } = (Registry.LocalMachine, @"Software\Microsoft\Windows\CurrentVersion\Run", "AdobeGCInvoker-1.0");

    }

}