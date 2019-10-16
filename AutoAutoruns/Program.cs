using System;
using System.Collections.Generic;
using System.Linq;
using AutoAutoruns.Autoruns;

namespace AutoAutoruns {

    public class Program {

        public static void Main() {
            new Program().Run();
        }

        private readonly IEnumerable<Autorun> autorunsToDisable = new List<Autorun> {
            new AcrobatAssistant(),
            new AdobeApplicationManagerUpdater(),
            new AdobeCreativeCloud(),
            new AdobeCreativeCloudExperience(),
            new VmwareTray()
        };

        private void Run() {
            foreach (Autorun autorunToDisable in autorunsToDisable.Where(a => a.Enabled)) {
                Console.WriteLine($"Disabling {autorunToDisable.Name}...");
                autorunToDisable.Enabled = false;
            }
        }

    }

}