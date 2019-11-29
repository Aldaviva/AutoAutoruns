using AutoAutoruns.Autoruns.Base;

namespace AutoAutoruns.Autoruns {

    public class AdobeFlashPlayerUpdater: ScheduledTaskAutorun {

        public override string name { get; } = "Adobe Flash Player Updater";
        protected override string path { get; } = @"\Adobe Flash Player Updater";

    }

}