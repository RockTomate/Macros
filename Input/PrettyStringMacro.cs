using UnityEditor;
using HardCodeLab.RockTomate.Core.Data;
using HardCodeLab.RockTomate.Core.Enums;
using HardCodeLab.RockTomate.Core.Attributes;

namespace HardCodeLab.RockTomate.Core.Macros
{
    [Macro(FieldType.Input, "pretty")]
    public class PrettyStringMacro : BaseMacro<string>
    {
        /// <inheritdoc />
        protected override Parameter[] GetParameters()
        {
            return new[]
            {
                Parameter.Create<string>("String to be prettified"),
            };
        }

        /// <inheritdoc />
        protected override string OnInvoke(JobContext context, params object[] args)
        {
            return ObjectNames.NicifyVariableName(GetArg<string>(args, 0));
        }
    }
}