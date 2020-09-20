using HardCodeLab.RockTomate.Core.Data;
using HardCodeLab.RockTomate.Core.Enums;
using HardCodeLab.RockTomate.Core.Attributes;

namespace HardCodeLab.RockTomate.Core.Macros
{
    [Macro(FieldType.Input, "decr")]
    public class DecrementValueMacro : BaseMacro<decimal>
    {
        /// <inheritdoc />
        protected override Parameter[] GetParameters()
        {
            return new[]
            {
                Parameter.Create<long>("Value that will be decremented."),
            };
        }

        /// <inheritdoc />
        protected override decimal OnInvoke(JobContext context, params object[] args)
        {
            var value = GetArg<long>(args, 0);

            return --value;
        }
    }
}