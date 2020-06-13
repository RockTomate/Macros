using HardCodeLab.RockTomate.Core.Data;
using HardCodeLab.RockTomate.Core.Enums;
using HardCodeLab.RockTomate.Core.Attributes;

namespace HardCodeLab.RockTomate.Core.Macros
{
    [Macro(FieldType.Input, "sum")]
    public class SumMacro : BaseMacro<float>
    {
        /// <inheritdoc />
        protected override Parameter[] GetParameters()
        {
            return new[]
            {
                Parameter.Create<float>("First value."),
                Parameter.Create<float>("Second value."),
            };
        }

        /// <inheritdoc />
        protected override float OnInvoke(JobContext context, params object[] args)
        {
            var valA = GetArg<float>(args, 0);
            var valB = GetArg<float>(args, 1);

            return valA + valB;
        }
    }
}