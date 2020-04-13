using System.Linq;
using System.Collections;
using HardCodeLab.RockTomate.Core.Data;
using HardCodeLab.RockTomate.Core.Enums;
using HardCodeLab.RockTomate.Core.Logging;
using HardCodeLab.RockTomate.Core.Attributes;
using HardCodeLab.RockTomate.Core.Extensions;

namespace HardCodeLab.RockTomate.Core.Macros
{
    [Macro(FieldType.Output, "addto")]
    public class AddToListMacro : BaseOutputMacro
    {
        /// <inheritdoc />
        protected override MacroParameter[] GetParameters()
        {
            return new[]
            {
                MacroParameter.Create<string>("Target variable name."),
                MacroParameter.Create<object>("Object to add to."),
            };
        }

        /// <inheritdoc />
        protected override bool OnVariableUpdate(JobContext context, string variableName, object newValue)
        {
            BaseField targetField;
            GetOrCreateField<IEnumerable>(context, variableName, out targetField);

            var targetFieldValue = targetField.GetValue(context);

            // check that target variable is actually a collection type
            if (!targetFieldValue.GetType().IsCollectionArrayType())
            {
                RockLog.WriteLine(LogTier.Error, string.Format("Variable of name \"{0}\" is not of list type (actually \"{1}\")", targetField.Name, targetField.ReturnType.FullName));
                return false;
            }

            var initialEnumerable = (IEnumerable)targetFieldValue;
            var newList = initialEnumerable.Cast<object>().ToList();

            // if supplied argument is of collection type
            if (newValue.GetType().IsCollectionArrayType())
            {
                var enumerableItem = ((IEnumerable)newValue).Cast<object>();
                newList.AddRange(enumerableItem);
            }
            else
            {
                newList.Add(newValue);
            }

            // update variable value
            targetField.SetValue(newList);

            return true;
        }
    }
}