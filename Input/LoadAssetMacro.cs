using UnityEditor;
using UnityEngine;
using HardCodeLab.RockTomate.Core.Data;
using HardCodeLab.RockTomate.Core.Enums;
using HardCodeLab.RockTomate.Core.Helpers;
using HardCodeLab.RockTomate.Core.Attributes;

namespace HardCodeLab.RockTomate.Core.Macros
{
    /// <summary>
    /// Loads an asset file from given path
    /// </summary>
    [Macro(FieldType.Input, "load")]
    public class LoadAssetMacro : BaseMacro<Object[]>
    {
        /// <inheritdoc />
        protected override MacroParameter[] GetParameters()
        {
            return new[]
            {
                MacroParameter.Create<string>("Path to the asset that will be loaded."),
            };
        }

        /// <inheritdoc />
        protected override Object[] OnInvoke(JobContext context, params object[] args)
        {
            var assetPath = GetArg<string>(args, 0);

            var resolvedAssetPaths = PathHelpers.ResolvePaths(assetPath, true);
            var results = new Object[resolvedAssetPaths.Length];

            for (var i = 0; i < resolvedAssetPaths.Length; i++)
            {
                results[i] = AssetDatabase.LoadAssetAtPath(resolvedAssetPaths[i], typeof(Object));
            }

            return results;
        }
    }
}