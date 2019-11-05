using System.Diagnostics;
using System.IO;

#nullable enable

namespace AutoAutoruns.Autoruns.Base {

    public abstract class ShortcutFileAutorun: Autorun {

        private const string DISABLED_FOLDER_NAME = "AutorunsDisabled";

        public abstract string name { get; }

        protected abstract string filePath { get; }

        public bool enabled {
            get => isEnabled();
            set => setEnabled(value);
        }

        private bool isEnabled() {
            return File.Exists(filePath);
        }

        private void setEnabled(bool shouldBeEnabled) {
            if (!shouldBeEnabled) {
                string parentDirectory = Path.GetDirectoryName(filePath);
                string fileName = Path.GetFileName(filePath);
                Debug.Assert(parentDirectory != null, nameof(parentDirectory) + " != null");
                Debug.Assert(fileName != null, nameof(fileName) + " != null");

                string childDirectory = Path.Combine(parentDirectory, DISABLED_FOLDER_NAME);
                string disabledFilePath = Path.Combine(childDirectory, fileName);

                Directory.CreateDirectory(childDirectory);
                File.Move(filePath, disabledFilePath);
            } else {
                throw new System.NotImplementedException();
            }
        }

    }

}