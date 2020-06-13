using HardCodeLab.RockTomate.Core.Data;
using HardCodeLab.RockTomate.Core.Enums;
using HardCodeLab.RockTomate.Core.Attributes;

namespace HardCodeLab.RockTomate.Core.Macros
{
    [Macro(FieldType.Output, "invert")]
    public class InvertBooleanOutputMacro : BaseOutputMacro
    {
        /// <inheritdoc />
        protected override Parameter[] GetParameters()
        {
            return new[]
            {
                Parameter.Create<string>("Target variable name."),
                Parameter.Create<bool>("Boolean which will be inverted"),
            };
        }

        /// <inheritdoc />
        protected override bool OnVariableUpdate(JobContext context, string variableName, object newValue)
        {
            BaseField targetField;
            GetOrCreateField<bool>(context, variableName, out targetField);

            targetField.SetValue(!(bool)newValue);
            return true;
        }
    }
}