using HardCodeLab.RockTomate.Core.Data;
using HardCodeLab.RockTomate.Core.Enums;
using HardCodeLab.RockTomate.Core.Attributes;

namespace HardCodeLab.RockTomate.Core.Macros
{
    [Macro(FieldType.Input, "equal")]
    public class EqualMacro : BaseMacro<bool>
    {
        /// <inheritdoc />
        protected override Parameter[] GetParameters()
        {
            return new[]
            {
                Parameter.Create<object>("First object to compare."),
                Parameter.Create<object>("Second object to compare.")
            };
        }

        /// <inheritdoc />
        protected override bool OnInvoke(JobContext context, params object[] args)
        {
            var obj1 = GetArg<object>(args, 0);
            var obj2 = GetArg<object>(args, 1);

            var result = Equals(obj1, obj2);

            return result;
        }
    }
}