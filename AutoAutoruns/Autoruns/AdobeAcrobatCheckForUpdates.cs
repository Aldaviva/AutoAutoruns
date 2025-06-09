#nullable enable

using AutoAutoruns.Autoruns.Base;
using Microsoft.Win32;

namespace AutoAutoruns.Autoruns;

/// <summary>
/// <para>Acrobat › Edit › Preferences… › Updater › Automatically install updates</para>
/// <para>Tested on Acrobat Pro 64-bit 2024.002.20965.</para>
/// </summary>
public class AdobeAcrobatCheckForUpdates: Autorun {

    private const string KEY   = @"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Adobe\Adobe ARM\1.0\ARM";
    private const string VALUE = "iCheck";

    public string name { get; } = "Adobe Acrobat check for updates";

    public bool enabled {
        get => Registry.GetValue(KEY, VALUE, 0) as uint? != 0; // 3 = enabled, 0 = disabled
        set => Registry.SetValue(KEY, VALUE, 0, RegistryValueKind.DWord);
    }

}