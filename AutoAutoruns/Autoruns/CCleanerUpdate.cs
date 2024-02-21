#nullable enable

using AutoAutoruns.Autoruns.Base;

namespace AutoAutoruns.Autoruns {

    public class CCleanerUpdate: ScheduledTaskAutorun {

        public override string name { get; } = "CCleaner Update";
        protected override string path { get; } = @"\CCleaner Update";

    }

}