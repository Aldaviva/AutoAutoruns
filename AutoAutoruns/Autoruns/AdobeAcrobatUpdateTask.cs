#nullable enable

using AutoAutoruns.Autoruns.Base;

namespace AutoAutoruns.Autoruns;

public class AdobeAcrobatUpdateTask: ScheduledTaskAutorun {

    public override string name { get; } = "Adobe Acrobat Update Task";
    protected override string path { get; } = @"\Adobe Acrobat Update Task";

}