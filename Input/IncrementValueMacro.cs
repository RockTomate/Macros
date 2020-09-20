using HardCodeLab.RockTomate.Core.Data;
using HardCodeLab.RockTomate.Core.Enums;
using HardCodeLab.RockTomate.Core.Attributes;

namespace HardCodeLab.RockTomate.Core.Macros
{
    [Macro(FieldType.Input, "incr")]
    public class IncrementValueMacro : BaseMacro<decimal>
    {
        /// <inheritdoc />
        protected override Parameter[] GetParameters()
        {
            return new[]
            {
                Parameter.Create<long>("Value that will be incremented."),
            };
        }

        /// <inheritdoc />
        protected override decimal OnInvoke(JobContext context, params object[] args)
        {
            var value = GetArg<long>(args, 0);

            return ++value;
        }
    }
}