#nullable enable

using Microsoft.Win32;
using System.IO;

namespace AutoAutoruns.Autoruns.Base;

public class OfficeComAddInAutorun(OfficeComAddInAutorun.OfficeProduct product, string addInName): Autorun {

    private const string LOAD_BEHAVIOR = "LoadBehavior";

    public string name { get; } = $"{addInName} for {product.toRegistryPath()}";

    public bool enabled {
        get => isEnabled();
        set => setEnabled(value);
    }

    private RegistryKey? openKey() {
        return Registry.LocalMachine.OpenSubKey(Path.Combine(@"SOFTWARE\Microsoft\Office", product.toRegistryPath(), "Addins", addInName), true);
    }

    private bool isEnabled() {
        using RegistryKey? key = openKey();
        return key?.GetValue(LOAD_BEHAVIOR) is int and not 0;
    }

    private void setEnabled(bool value) {
        using RegistryKey? key = openKey();
        if (key != null) {
            if (value) {
                key.SetValue(LOAD_BEHAVIOR, key.GetValue(RegistryAutorun.DISABLED_FOLDER_NAME, 3), RegistryValueKind.DWord);
                key.DeleteValue(RegistryAutorun.DISABLED_FOLDER_NAME);
            } else {
                if (key.GetValue(LOAD_BEHAVIOR) is int oldLoadBehavior) {
                    key.SetValue(RegistryAutorun.DISABLED_FOLDER_NAME, oldLoadBehavior, RegistryValueKind.DWord);
                }
                key.SetValue(LOAD_BEHAVIOR, 0, RegistryValueKind.DWord);
            }
        }
    }

    public enum OfficeProduct {

        EXCEL,
        WORD,
        POWERPOINT,
        OUTLOOK

    }

}

public static class OfficeProductMethods {

    public static string toRegistryPath(this OfficeComAddInAutorun.OfficeProduct product) => product switch {
        OfficeComAddInAutorun.OfficeProduct.EXCEL      => "Excel",
        OfficeComAddInAutorun.OfficeProduct.WORD       => "Word",
        OfficeComAddInAutorun.OfficeProduct.POWERPOINT => "PowerPoint",
        OfficeComAddInAutorun.OfficeProduct.OUTLOOK    => "Outlook",
    };

}