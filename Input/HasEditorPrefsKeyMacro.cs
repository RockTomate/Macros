using UnityEditor;
using HardCodeLab.RockTomate.Core.Data;
using HardCodeLab.RockTomate.Core.Enums;
using HardCodeLab.RockTomate.Core.Attributes;

namespace HardCodeLab.RockTomate.Core.Macros
{
    /// <summary>
    /// Used to check if EditorPrefs key exists
    /// </summary>
    [Macro(FieldType.Input, "has_key")]
    public class HasEditorPrefsKeyMacro : BaseMacro<bool>
    {
        /// <inheritdoc />
        protected override Parameter[] GetParameters()
        {
            return new[]
            {
                Parameter.Create<string>("Key of the pref to check against."),
            };
        }

        /// <inheritdoc />
        protected override bool OnInvoke(JobContext context, params object[] args)
        {
            var key = GetArg<string>(args, 0);
            return EditorPrefs.HasKey(key);
        }
    }
}