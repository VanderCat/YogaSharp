﻿using Yoga.Interop;

namespace Yoga; 

[Flags]
public enum Errata {
    All = YGErrata.YGErrataAll,
    Classic = YGErrata.YGErrataClassic,
    None = YGErrata.YGErrataNone,
    AbsolutePositioningIncorrect = YGErrata.YGErrataAbsolutePositioningIncorrect,
    StretchFlexBasis = YGErrata.YGErrataStretchFlexBasis,
    InnerSize = YGErrata.YGErrataAbsolutePercentAgainstInnerSize
}