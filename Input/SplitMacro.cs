using System;
using System.Collections;
using HardCodeLab.RockTomate.Core.Data;
using HardCodeLab.RockTomate.Core.Enums;
using HardCodeLab.RockTomate.Core.Attributes;

namespace HardCodeLab.RockTomate.Core.Macros
{
    [Macro(FieldType.Input, "split")]
    public class SplitMacro : BaseMacro<IEnumerable>
    {
        /// <inheritdoc />
        protected override MacroParameter[] GetParameters()
        {
            return new[]
            {
                MacroParameter.Create<string>("String that will be split."),
                MacroParameter.Create<string>("Character separator.")
            };
        }

        /// <inheritdoc />
        protected override IEnumerable OnInvoke(JobContext context, params object[] args)
        {
            var text = GetArg<string>(args, 0);
            var separator = GetArg<string>(args, 1);
            return text.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}