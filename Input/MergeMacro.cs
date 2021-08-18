using System.Linq;
using System.Collections;
using System.Collections.Generic;
using HardCodeLab.RockTomate.Core.Data;
using HardCodeLab.RockTomate.Core.Enums;
using HardCodeLab.RockTomate.Core.Helpers;
using HardCodeLab.RockTomate.Core.Attributes;

namespace HardCodeLab.RockTomate.Core.Macros
{
    [Macro(FieldType.Input, "merge")]
    public class MergeMacro : BaseMacro<IEnumerable>
    {
        protected override Parameter[] GetParameters()
        {
            return new[]
            {
                Parameter.Create<IEnumerable>("First list/object that will be merged"),
                Parameter.Create<IEnumerable>("Second list/object that will be merged")
            };
        }

        protected override IEnumerable OnInvoke(JobContext context, params object[] args)
        {
            object list1Obj;
            object list2Obj;

            TypeHelpers.TryConvertObject(GetArg<object>(args, 0), typeof(List<object>), out list1Obj);
            TypeHelpers.TryConvertObject(GetArg<object>(args, 1), typeof(List<object>), out list2Obj);

            var list1 = (List<object>)list1Obj;
            var list2 = (List<object>)list2Obj;

            return list1.Concat(list2);
        }
    }
}