#nullable enable

using AutoAutoruns.Autoruns.Base;

namespace AutoAutoruns.Autoruns {

    public class AdobeGenuineSoftwareIntegrityScheduler: ScheduledTaskAutorun {

        public override string name { get; } = "Adobe Genuine Software Integrity Scheduler";
        protected override string path { get; } = @"\Adobe-Genuine-Software-Integrity-Scheduler-1.0";

    }

}