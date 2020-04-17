using System.Linq;
using System.Collections;
using HardCodeLab.RockTomate.Core.Data;
using HardCodeLab.RockTomate.Core.Enums;
using HardCodeLab.RockTomate.Core.Attributes;

namespace HardCodeLab.RockTomate.Core.Macros
{
    [Macro(FieldType.Input, "contains")]
    public class CollectionContainsItemMacro : BaseMacro<bool>
    {
        /// <inheritdoc />
        protected override MacroParameter[] GetParameters()
        {
            return new[]
            {
                MacroParameter.Create<IEnumerable>("Collection to check."),
                MacroParameter.Create<object>("Item to look for."),
            };
        }

        /// <inheritdoc />
        protected override bool OnInvoke(JobContext context, params object[] args)
        {
            var collection = GetArg<IEnumerable>(args, 0);
            var item = GetArg<object>(args, 1);

            return collection.Cast<object>().Contains(item);
        }
    }
}