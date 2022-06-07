using System.Collections;
using HardCodeLab.RockTomate.Core.Data;
using HardCodeLab.RockTomate.Core.Enums;
using HardCodeLab.RockTomate.Core.Attributes;
using HardCodeLab.RockTomate.Core.Extensions;

namespace HardCodeLab.RockTomate.Core.Macros
{
    [Macro(FieldType.Input, "join")]
    public class JoinMacro : BaseMacro<string>
    {
        protected override Parameter[] GetParameters()
        {
            return new[]
            {
                Parameter.Create<string>("Separator"),
                Parameter.Create<IEnumerable>("Values"),
            };
        }

        protected override string OnInvoke(JobContext context, params object[] args)
        {
            var separator = GetArg<string>(args, 0);
            var values = GetArg<IEnumerable>(args, 1);

            return values.ToStringContents(separator);
        }
    }
}