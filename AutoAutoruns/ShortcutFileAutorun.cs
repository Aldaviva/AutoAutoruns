using System.Diagnostics;
using System.IO;

namespace AutoAutoruns {

    public abstract class ShortcutFileAutorun: Autorun {

        public abstract string Name { get; }

        protected abstract string FilePath { get; }

        public bool Enabled {
            get => IsEnabled();
            set => SetEnabled(value);
        }

        private bool IsEnabled() {
            return File.Exists(FilePath);
        }

        private void SetEnabled(bool shouldBeEnabled) {
            if (!shouldBeEnabled) {
                string parentDirectory = Path.GetDirectoryName(FilePath);
                string fileName = Path.GetFileName(FilePath);
                Debug.Assert(parentDirectory != null, nameof(parentDirectory) + " != null");
                Debug.Assert(fileName != null, nameof(fileName) + " != null");

                string childDirectory = Path.Combine(parentDirectory, "AutorunsDisabled");
                string disabledFilePath = Path.Combine(childDirectory, fileName);

                Directory.CreateDirectory(childDirectory);
                File.Move(FilePath, disabledFilePath);
            } else {
                throw new System.NotImplementedException();
            }
        }

    }

}