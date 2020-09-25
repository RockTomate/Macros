using HardCodeLab.RockTomate.Core.Data;
using HardCodeLab.RockTomate.Core.Enums;
using HardCodeLab.RockTomate.Core.Attributes;

namespace HardCodeLab.RockTomate.Core.Macros
{
    [Macro(FieldType.Input, "if")]
    public class IfMacro : BaseMacro<object>
    {
        /// <inheritdoc />
        protected override Parameter[] GetParameters()
        {
            return new[]
            {
                Parameter.Create<bool>("Boolean that determines which of the other parameters to return."),
                Parameter.Create<object>("Parameter that will be returned if boolean is True."),
                Parameter.Create<object>("Parameter that will be returned if boolean is False."),
            };
        }

        /// <inheritdoc />
        protected override object OnInvoke(JobContext context, params object[] args)
        {
            var isTrue = GetArg<bool>(args, 0);
            var obj1 = GetArg<object>(args, 1);
            var obj2 = GetArg<object>(args, 2);

            return isTrue
                ? obj1
                : obj2;
        }
    }
}