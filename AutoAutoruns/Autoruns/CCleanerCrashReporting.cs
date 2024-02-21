#nullable enable

using AutoAutoruns.Autoruns.Base;

namespace AutoAutoruns.Autoruns {

    public class CCleanerCrashReporting: ScheduledTaskAutorun {

        public override string name { get; } = "CCleaner Crash Reporting";
        protected override string path { get; } = @"\CCleanerCrashReporting";

    }

}