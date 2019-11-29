using AutoAutoruns.Autoruns.Base;

namespace AutoAutoruns.Autoruns {

    public class AdobeFlashPlayerNotifier: ScheduledTaskAutorun {

        public override string name { get; } = "Adobe Flash Player PPAPI Notifier";
        protected override string path { get; } = @"\Adobe Flash Player PPAPI Notifier";

    }

}