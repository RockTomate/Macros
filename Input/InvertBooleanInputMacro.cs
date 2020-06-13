using System;
using HardCodeLab.RockTomate.Core.Data;
using HardCodeLab.RockTomate.Core.Enums;
using HardCodeLab.RockTomate.Core.Attributes;

namespace HardCodeLab.RockTomate.Core.Macros
{
    [Macro(FieldType.Input, "invert")]
    public class InvertBooleanInputMacro : BaseMacro<bool>
    {
        /// <inheritdoc />
        protected override Parameter[] GetParameters()
        {
            return new[]
            {
                Parameter.Create<bool>("Boolean which will be inverted"),
            };
        }

        /// <inheritdoc />
        protected override bool OnInvoke(JobContext context, params object[] args)
        {
            return !GetArg<bool>(args, 0);
        }
    }
}