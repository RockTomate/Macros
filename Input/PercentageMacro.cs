using UnityEngine;
using HardCodeLab.RockTomate.Core.Data;
using HardCodeLab.RockTomate.Core.Enums;
using HardCodeLab.RockTomate.Core.Attributes;

namespace HardCodeLab.RockTomate.Core.Macros
{
    [Macro(FieldType.Input, "percentage")]
    public class PercentageMacro : BaseMacro<int>
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
        protected override int OnInvoke(JobContext context, params object[] args)
        {
            var valA = GetArg<float>(args, 0);
            var valB = GetArg<float>(args, 1);

            return Mathf.RoundToInt((valA / valB) * 100);
        }
    }
}