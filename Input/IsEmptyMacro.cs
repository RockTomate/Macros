using System.Collections;
using HardCodeLab.RockTomate.Core.Data;
using HardCodeLab.RockTomate.Core.Enums;
using HardCodeLab.RockTomate.Core.Extensions;
using HardCodeLab.RockTomate.Core.Attributes;

namespace HardCodeLab.RockTomate.Core.Macros
{
    [Macro(FieldType.Input, "is_empty")]
    public class IsEmptyMacro : BaseMacro<bool>
    {
        protected override Parameter[] GetParameters()
        {
            return new[]
            {
                Parameter.Create<IEnumerable>("String or Collection type instance"),
            };
        }

        protected override bool OnInvoke(JobContext context, params object[] args)
        {
            var value = GetArg<IEnumerable>(args, 0);
            return value.IsEmpty();
        }
    }
}