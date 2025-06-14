#nullable enable

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;

namespace AutoAutoruns.Autoruns.Base;

public class RegistryAutorun: Autorun {

    internal const string DISABLED_FOLDER_NAME = "AutorunsDisabled";

    public RegistryAutorun() { }

    public RegistryAutorun(string name, RegistryKey hive, string keyPath, string? valueName): this() {
        this.name        = name;
        registryLocation = (hive, keyPath, valueName);
    }

    public virtual string name { get; }
    protected virtual (RegistryKey hive, string path, string? name) registryLocation { get; }

    public bool enabled {
        get => isEnabled();
        set => setEnabled(value);
    }

    private bool isEnabled() {
        using RegistryKey key = registryLocation.hive.OpenSubKey(registryLocation.path, false);
        try {
            if (registryLocation.name != null) {
                return key?.GetValueKind(registryLocation.name) != null;
            } else {
                return key != null;
            }
        } catch (IOException) {
            return false;
        }
    }

    private void setEnabled(bool shouldBeEnabled) {
        if (!shouldBeEnabled) {
            if (registryLocation.name != null) {
                disableValue();
            } else {
                disableKey();
            }
        } else {
            throw new NotImplementedException();
        }
    }

    // Move single value to subkey
    // Old value is deleted
    // example: HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Run\AutorunsDisabled
    private void disableValue() {
        if (registryLocation.path == null) return;

        using RegistryKey oldKey = registryLocation.hive.OpenSubKey(registryLocation.path, true) ?? throw
            new KeyNotFoundException(
                $"No registry key {registryLocation.path} in {registryLocation.hive.Name}");
        using RegistryKey newKey = oldKey.CreateSubKey(DISABLED_FOLDER_NAME, true);

        RegistryValueKind kind  = oldKey.GetValueKind(registryLocation.name);
        object            value = oldKey.GetValue(registryLocation.name);

        newKey.SetValue(registryLocation.name, value, kind);
//                Console.WriteLine($"Deleting {RegistryLocation.hive}\\{RegistryLocation.path}\\{RegistryLocation.name}");
        oldKey.DeleteValue(registryLocation.name);
    }

    // Move all values inside key to niece/nephew key
    // Old key and all its values are deleted
    // example: HKEY_LOCAL_MACHINE\SOFTWARE\Classes\*\shellex\ContextMenuHandlers\AutorunsDisabled\TeraCopyS64
    private void disableKey() {
        if (registryLocation.path == null) return;

        string newPath = Path.Combine(Path.GetDirectoryName(registryLocation.path) ?? string.Empty,
            DISABLED_FOLDER_NAME,
            Path.GetFileName(registryLocation.path));

        using RegistryKey oldKey = registryLocation.hive.OpenSubKey(registryLocation.path, true) ?? throw new KeyNotFoundException(
            $"No registry key {registryLocation.path} in {registryLocation.hive.Name}");
        using RegistryKey newKey = registryLocation.hive.CreateSubKey(newPath, true);

        foreach (string valueName in oldKey.GetValueNames()) {
            RegistryValueKind kind  = oldKey.GetValueKind(valueName);
            object            value = oldKey.GetValue(valueName);

            newKey.SetValue(valueName, value, kind);
        }

//                Console.WriteLine($"Deleting {RegistryLocation.hive}\\{RegistryLocation.path}");
        registryLocation.hive.DeleteSubKey(registryLocation.path);
    }

}