using System;
using HardCodeLab.RockTomate.Core.Data;
using HardCodeLab.RockTomate.Core.Enums;
using HardCodeLab.RockTomate.Core.Attributes;

namespace HardCodeLab.RockTomate.Core.Macros
{
    [Macro(FieldType.Input, "envar")]
    public class GetEnvironmentVariableMacro : BaseMacro<string>
    {
        /// <inheritdoc />
        protected override Parameter[] GetParameters()
        {
            return new[]
            {
                Parameter.Create<string>("Name of the environment variable"), 
            };
        }

        /// <inheritdoc />
        protected override string OnInvoke(JobContext context, params object[] args)
        {
            var variableName = GetArg<string>(args, 0);
            return Environment.GetEnvironmentVariable(variableName) ?? string.Empty;
        }
    }
}