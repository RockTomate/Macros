using System;
using HardCodeLab.RockTomate.Core.Data;
using HardCodeLab.RockTomate.Core.Enums;
using HardCodeLab.RockTomate.Core.Attributes;

namespace HardCodeLab.RockTomate.Core.Macros
{
    [Macro(FieldType.Input, "abs")]
    public class AbsMacro : BaseMacro<decimal>
    {
        /// <inheritdoc />
        protected override MacroParameter[] GetParameters()
        {
            return new[]
            {
                MacroParameter.Create<float>("A number that is greater than or equal to MinValue, but less than or equal to MaxValue."),
            };
        }

        /// <inheritdoc />
        protected override decimal OnInvoke(JobContext context, params object[] args)
        {
            var value = GetArg<decimal>(args, 0);

            return Math.Abs(value);
        }
    }
}