using HardCodeLab.RockTomate.Core.Data;
using HardCodeLab.RockTomate.Core.Enums;
using HardCodeLab.RockTomate.Core.Attributes;

namespace HardCodeLab.RockTomate.Core.Macros
{
    [Macro(FieldType.Input, "ends_with")]
    public class StringEndsWithMacro : BaseMacro<bool>
    {
        /// <inheritdoc />
        protected override Parameter[] GetParameters()
        {
            return new[]
            {
                Parameter.Create<string>("Original string."),
                Parameter.Create<string>("The string to compare."),
            };
        }

        /// <inheritdoc />
        protected override bool OnInvoke(JobContext context, params object[] args)
        {
            var str1 = GetArg<string>(args, 0);
            var str2 = GetArg<string>(args, 1);

            return str1.EndsWith(str2);
        }
    }
}