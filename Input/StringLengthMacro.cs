using HardCodeLab.RockTomate.Core.Data;
using HardCodeLab.RockTomate.Core.Enums;
using HardCodeLab.RockTomate.Core.Attributes;

namespace HardCodeLab.RockTomate.Core.Macros
{
    [Macro(FieldType.Input, "length")]
    public class StringLengthMacro : BaseMacro<int>
    {
        /// <inheritdoc />
        protected override Parameter[] GetParameters()
        {
            return new[]
            {
                Parameter.Create<string>("String to count characters"),
            };
        }

        /// <inheritdoc />
        protected override int OnInvoke(JobContext context, params object[] args)
        {
            var str = GetArg<string>(args, 0);
            return str.Length;
        }
    }
}