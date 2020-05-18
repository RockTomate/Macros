using System.Collections;
using HardCodeLab.RockTomate.Core.Data;
using HardCodeLab.RockTomate.Core.Enums;
using HardCodeLab.RockTomate.Core.Attributes;
using HardCodeLab.RockTomate.Core.Extensions;

namespace HardCodeLab.RockTomate.Core.Macros
{
    [Macro(FieldType.Input, "get")]
    public class GetCollectionItemMacro : BaseMacro<object>
    {
        /// <inheritdoc />
        protected override MacroParameter[] GetParameters()
        {
            return new[]
            {
                MacroParameter.Create<IEnumerable>("Target collection."),
                MacroParameter.Create<int>("Index of an item."), 
            };
        }

        /// <inheritdoc />
        protected override object OnInvoke(JobContext context, params object[] args)
        {
            var collection = GetArg<IEnumerable>(args, 0);
            var index = GetArg<int>(args, 1);

            return collection.GetItemAt(index);
        }
    }
}