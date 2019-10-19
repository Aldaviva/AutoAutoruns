using System;
using Microsoft.Win32.TaskScheduler;

namespace AutoAutoruns.Autoruns.Base {

    public abstract class ScheduledTaskAutorun: Autorun {

        private static readonly Lazy<TaskService> TASK_SERVICE = new Lazy<TaskService>();

        public abstract string name { get; }

        /// <summary>
        /// The path of the scheduled task, using a leading backslash and backslashes to separate path components.
        /// </summary>
        /// <example><code>\Microsoft\Windows\NetTrace\GatherNetworkInfo</code></example>
        protected abstract string path { get; }

        public bool enabled {
            get => isEnabled();
            set => setEnabled(value);
        }

        private bool isEnabled() {
            using (Task scheduledTask = TASK_SERVICE.Value.GetTask(path)) {
                return scheduledTask?.Definition.Settings.Enabled ?? false;
            }
        }

        private void setEnabled(bool shouldBeEnabled) {
            if (!shouldBeEnabled) {
                using (Task scheduledTask = TASK_SERVICE.Value.GetTask(path)) {
                    scheduledTask.Definition.Settings.Enabled = false;
                    scheduledTask.RegisterChanges();
                }
            } else {
                throw new NotImplementedException();
            }
        }

    }

}