#nullable enable

using AutoAutoruns.Autoruns;
using AutoAutoruns.Autoruns.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoAutoruns;

public static class Program {

    public static void Main() {
        foreach (Autorun autorunToDisable in AUTORUNS_TO_DISABLE.Where(a => a.enabled)) {
            Console.WriteLine($"Disabling {autorunToDisable.name}...");
            autorunToDisable.enabled = false;
        }
    }

    private static readonly IEnumerable<Autorun> AUTORUNS_TO_DISABLE = [
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
    ];

}