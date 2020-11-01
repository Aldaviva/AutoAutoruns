#nullable enable

using AutoAutoruns.Autoruns.Base;

namespace AutoAutoruns.Autoruns {

    public class AdobeGCInvokerScheduledTask: ScheduledTaskAutorun {

        public override string name { get; } = "Adobe GC Invoker Utility (Scheduled Task)";
        protected override string path { get; } = @"\AdobeGCInvoker-1.0";

    }

}