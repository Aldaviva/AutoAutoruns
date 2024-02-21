#nullable enable

namespace AutoAutoruns.Autoruns.Base;

public interface Autorun {

    string name { get; }
    bool enabled { get; set; }

}