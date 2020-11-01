#nullable enable

using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace AutoAutoruns.Autoruns.Base {

    public abstract class ShortcutFileAutorun: Autorun {

        private const string DISABLED_FOLDER_NAME = "AutorunsDisabled";

        public abstract string name { get; }

        [NotNull]
        protected abstract string filePath { get; }

        private string filePathExpanded => Environment.ExpandEnvironmentVariables(filePath);

        public bool enabled {
            get => isEnabled();
            set => setEnabled(value);
        }

        private bool isEnabled() {
            return File.Exists(filePathExpanded);
        }

        private void setEnabled(bool shouldBeEnabled) {
            if (!shouldBeEnabled) {
                string filePathExpandedValue = filePathExpanded;

                string parentDirectory = Path.GetDirectoryName(filePathExpandedValue);
                string fileName        = Path.GetFileName(filePathExpandedValue);

                string childDirectory   = Path.Combine(parentDirectory, DISABLED_FOLDER_NAME);
                string disabledFilePath = Path.Combine(childDirectory, fileName);

                Directory.CreateDirectory(childDirectory);
                for (int attempt = 0; attempt < 2; attempt++) {
                    try {
                        File.Move(filePathExpandedValue, disabledFilePath);
                        break;
                    } catch (IOException) {
                        File.Delete(disabledFilePath);
                    }
                }
            } else {
                throw new NotImplementedException();
            }
        }

    }

}