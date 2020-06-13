using System.Collections;
using HardCodeLab.RockTomate.Core.Data;
using HardCodeLab.RockTomate.Core.Enums;
using HardCodeLab.RockTomate.Core.Attributes;
using HardCodeLab.RockTomate.Core.Extensions;

namespace HardCodeLab.RockTomate.Core.Macros
{
    [Macro(FieldType.Input, "count")]
    public class CollectionItemCountMacro : BaseMacro<int>
    {
        /// <inheritdoc />
        protected override Parameter[] GetParameters()
        {
            return new[]
            {
                Parameter.Create<IEnumerable>("Collection to measure."),
            };
        }

        /// <inheritdoc />
        protected override int OnInvoke(JobContext context, params object[] args)
        {
            var collection = GetArg<IEnumerable>(args, 0);

            return collection == null
                ? 0
                : collection.Count();
        }
    }
}