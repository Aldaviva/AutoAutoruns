using System.Diagnostics;
using System.IO;
using Microsoft.Win32;

namespace AutoAutoruns.Autoruns.Base {

    public abstract class RegistryAutorun: Autorun {

        private const string DISABLED_FOLDER_NAME = "AutorunsDisabled";

        public abstract string name { get; }
        protected abstract (RegistryKey hive, string path, string name) registryLocation { get; }

        public bool enabled { 
            get => isEnabled();
            set => setEnabled(value);
        }

        private bool isEnabled() {
            using (RegistryKey key = registryLocation.hive.OpenSubKey(registryLocation.path, false)) {
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
        }

        private void setEnabled(bool shouldBeEnabled) {
            if (!shouldBeEnabled) {
                if (registryLocation.name != null) {
                    disableValue();
                } else {
                    disableKey();
                }
            } else {
                throw new System.NotImplementedException();
            }
        }

        // Move single value to subkey
        // Old value is deleted
        // example: HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Run\AutorunsDisabled
        private void disableValue() {
            using (RegistryKey oldKey = registryLocation.hive.OpenSubKey(registryLocation.path, true))
            using (RegistryKey newKey = oldKey?.CreateSubKey(DISABLED_FOLDER_NAME, true)) {
                Debug.Assert(oldKey != null, nameof(oldKey) + " != null");

                RegistryValueKind kind = oldKey.GetValueKind(registryLocation.name);
                object value = oldKey.GetValue(registryLocation.name);

                newKey.SetValue(registryLocation.name, value, kind);
//                Console.WriteLine($"Deleting {RegistryLocation.hive}\\{RegistryLocation.path}\\{RegistryLocation.name}");
                oldKey.DeleteValue(registryLocation.name);
            }
        }

        // Move all values inside key to niece/nephew key
        // Old key and all its values are deleted
        // example: HKEY_LOCAL_MACHINE\SOFTWARE\Classes\*\shellex\ContextMenuHandlers\AutorunsDisabled\TeraCopyS64
        private void disableKey() {
            string newPath = Path.Combine(Path.GetDirectoryName(registryLocation.path),
                DISABLED_FOLDER_NAME,
                Path.GetFileName(registryLocation.path));

            using (RegistryKey oldKey = registryLocation.hive.OpenSubKey(registryLocation.path, true))
            using (RegistryKey newKey = registryLocation.hive.CreateSubKey(newPath, true)) {
                foreach (string name in oldKey.GetValueNames()) {
                    RegistryValueKind kind = oldKey.GetValueKind(name);
                    object value = oldKey.GetValue(name);

                    newKey.SetValue(name, value, kind);
                }

//                Console.WriteLine($"Deleting {RegistryLocation.hive}\\{RegistryLocation.path}");
                registryLocation.hive.DeleteSubKey(registryLocation.path);
            }
        }

    }

}