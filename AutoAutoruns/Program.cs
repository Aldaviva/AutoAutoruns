using System;
using System.Collections.Generic;
using System.Linq;
using AutoAutoruns.Autoruns;
using AutoAutoruns.Autoruns.Base;

namespace AutoAutoruns {

    public class Program {

        public static void Main() {
            new Program().run();
        }

        private readonly IEnumerable<Autorun> autorunsToDisable = new List<Autorun> {
            new AdobeAcrobatAssistant(),
            new AdobeAcrobatContextMenuApprovedShellExtension(),
            new AdobeAcrobatContextMenuFolderContextMenuHandlers(),
            new AdobeAcrobatContextMenuWildcardContextMenuHandlers(),
            new AdobeApplicationManagerUpdater(),
            new AdobeCoreSyncExtensionFolderContextMenuHandlers(),
            new AdobeCoreSyncExtensionIcon(1),
            new AdobeCoreSyncExtensionIcon(2),
            new AdobeCoreSyncExtensionIcon(3),
            new AdobeCoreSyncExtensionWildcardContextMenuHandlers(),
            new AdobeCreativeCloud(),
            new AdobeCreativeCloudExperience(),
            new NvidiaControlPanelDesktopContext(),
            new VmwareTray()
        };

        private void run() {
            foreach (Autorun autorunToDisable in autorunsToDisable.Where(a => a.enabled)) {
                Console.WriteLine($"Disabling {autorunToDisable.name}...");
                autorunToDisable.enabled = false;
            }
        }

    }

}