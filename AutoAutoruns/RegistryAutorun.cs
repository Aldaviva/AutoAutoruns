using System.Diagnostics;
using System.IO;
using Microsoft.Win32;

namespace AutoAutoruns {

    public abstract class RegistryAutorun: Autorun {

        public abstract string Name { get; }
        protected abstract (RegistryKey hive, string path, string name) RegistryLocation { get; }

        public bool Enabled {
            get => IsEnabled();
            set => SetEnabled(value);
        }

        private bool IsEnabled() {
            using (RegistryKey key = RegistryLocation.hive.OpenSubKey(RegistryLocation.path, false)) {
                try {
                    return key?.GetValueKind(RegistryLocation.name) != null;
                } catch (IOException) {
                    return false;
                }
            }
        }

        private void SetEnabled(bool shouldBeEnabled) {
            if (!shouldBeEnabled) {
                using (RegistryKey parentKey = RegistryLocation.hive.OpenSubKey(RegistryLocation.path, true))
                using (RegistryKey childKey = parentKey?.CreateSubKey("AutorunsDisabled", true)) {
                    Debug.Assert(parentKey != null, nameof(parentKey) + " != null");

                    RegistryValueKind oldType = parentKey.GetValueKind(RegistryLocation.name);
                    object oldData = parentKey.GetValue(RegistryLocation.name);

                    childKey.SetValue(RegistryLocation.name, oldData, oldType);
                    parentKey.DeleteValue(RegistryLocation.name);
                }
            } else {
                throw new System.NotImplementedException();
            }
        }

    }

}