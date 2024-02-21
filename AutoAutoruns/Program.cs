#nullable enable

using AutoAutoruns.Autoruns;
using AutoAutoruns.Autoruns.Base;
using System;
using System.Collections.Generic;
using System.Linq;

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
            new AdobeAcrobatSynchronizer(),
            new AdobeAcrobatUpdateTask(),
            new AdobeApplicationManagerUpdater(),
            new AdobeCoreSyncExtensionFolderContextMenuHandlers(),
            new AdobeCoreSyncExtensionIcon(1),
            new AdobeCoreSyncExtensionIcon(2),
            new AdobeCoreSyncExtensionIcon(3),
            new AdobeCoreSyncExtensionWildcardContextMenuHandlers(),
            new AdobeCreativeCloud(),
            new AdobeCreativeCloudExperience(),
            new AdobeCreativeCloudExperienceProcess(),
            new AdobeGCInvokerRegistry(),
            new AdobeGCInvokerScheduledTask(),
            new AdobeGenuineSoftwareIntegrityScheduler(),
            new AdobeFlashPlayerNotifier(),
            new AdobeFlashPlayerUpdater(),
            new AutoCADColumnHandler(),
            new AutoCADContextMenuHandler(),
            new CanonEosUtility(),
            new CCleanerUpdate(),
            new CCleanerCrashReporting(),
            new HexWorkshopContextMenu(),
            new NvidiaAppShellExtensions(),
            new NvidiaControlPanelDesktopContextClassApprovedShellExtension(),
            new NvidiaControlPanelDesktopContextMenuHandler(),
            new NvidiaOpenGlShellExtensions(),
            new NvidiaPlayOnMyTvContextMenuExtension(),
            new VMDiskMenuHandler(),
            new VmwareTray(),
        };

        private void run() {
            foreach (Autorun autorunToDisable in autorunsToDisable.Where(a => a.enabled)) {
                Console.WriteLine($"Disabling {autorunToDisable.name}...");
                autorunToDisable.enabled = false;
            }
        }

    }

}