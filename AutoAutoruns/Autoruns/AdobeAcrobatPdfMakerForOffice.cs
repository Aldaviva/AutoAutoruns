#nullable enable

using AutoAutoruns.Autoruns.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoAutoruns.Autoruns;

public class AdobeAcrobatPdfMakerForOffice: CompoundAutorun {

    private const string ADDIN_NAME = "PDFMaker.OfficeAddin";

    public override string name { get; } = "Acrobat PDFMaker for Office";

    protected override ICollection<Autorun> autoruns { get; } = ((IEnumerable<Autorun>) Enum.GetValues(typeof(OfficeComAddInAutorun.OfficeProduct))
        .Cast<OfficeComAddInAutorun.OfficeProduct>()
        .Select(officeProduct => new OfficeComAddInAutorun(officeProduct, ADDIN_NAME))).ToList();

}