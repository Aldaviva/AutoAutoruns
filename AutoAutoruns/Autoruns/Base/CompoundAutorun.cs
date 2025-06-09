#nullable enable

using System.Collections.Generic;
using System.Linq;

namespace AutoAutoruns.Autoruns.Base;

public abstract class CompoundAutorun: Autorun {

    protected abstract ICollection<Autorun> autoruns { get; }

    public abstract string name { get; }

    public bool enabled {
        get => autoruns.Any(autorun => autorun.enabled);
        set {
            foreach (Autorun autorun in autoruns) {
                autorun.enabled = value;
            }
        }
    }

}