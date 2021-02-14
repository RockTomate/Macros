using HardCodeLab.RockTomate.Core.Data;
using HardCodeLab.RockTomate.Core.Enums;
using HardCodeLab.RockTomate.Core.Logging;
using HardCodeLab.RockTomate.Core.Attributes;
using HardCodeLab.RockTomate.Core.Extensions;

namespace HardCodeLab.RockTomate.Core.Macros
{
    [Macro(FieldType.Input, "peel")]
    public class PeelValueMacro : BaseMacro<object>
    {
        protected override Parameter[] GetParameters()
        {
            return new[]
            {
                Parameter.Create<object>("Object from which data will be extracted"),
                Parameter.Create<string>("Name of the field/property that's associated with the object")
            };
        }

        protected override object OnInvoke(JobContext context, params object[] args)
        {
            var obj = GetArg<object>(args, 0);
            var name = GetArg<string>(args, 1);

            if (obj == null || name.IsNullOrWhiteSpace())
                return null;

            var objType = obj.GetType();

            var fieldInfo = objType.GetField(name);
            if (fieldInfo != null)
                return fieldInfo.GetValue(obj);

            var propInfo = objType.GetProperty(name);
            if (propInfo != null)
                return propInfo.GetValue(obj);

            RockLog.WriteLine(LogTier.Info,
                string.Format("Couldn't find property/field (\"{0}\") that can be extracted from object (\"{1}\")",
                name, objType
            ));

            return null;
        }
    }
}