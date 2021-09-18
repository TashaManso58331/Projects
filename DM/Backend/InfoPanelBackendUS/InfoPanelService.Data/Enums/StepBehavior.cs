using System;

namespace InfoPanelService.Data.Enums
{
    [Flags]
    public enum StepBehavior
    {
        OnStartOnly = 1,
        OnEachTransaction = 2,
        OnFinishOnly = 4
    }
}
