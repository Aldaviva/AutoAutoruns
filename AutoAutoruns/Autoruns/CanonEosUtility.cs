#nullable enable

using AutoAutoruns.Autoruns.Base;

namespace AutoAutoruns.Autoruns;

public class CanonEosUtility: ShortcutFileAutorun {

    public override string name { get; } = "EOS Utility";
    protected override string filePath { get; } = @"%APPDATA%\Microsoft\Windows\Start Menu\Programs\Startup\EOS Utility.lnk";

}