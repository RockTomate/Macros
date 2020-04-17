using System.IO;
using HardCodeLab.RockTomate.Core.Data;
using HardCodeLab.RockTomate.Core.Enums;
using HardCodeLab.RockTomate.Core.Helpers;
using HardCodeLab.RockTomate.Core.Attributes;

namespace HardCodeLab.RockTomate.Core.Macros
{
    /// <summary>
    /// Loads a UnityScene from scene file path
    /// </summary>
    [Macro(FieldType.Input, "load")]
    public class LoadUnitySceneMacro : BaseMacro<UnityScene>
    {
        /// <inheritdoc />
        protected override MacroParameter[] GetParameters()
        {
            return new[]
            {
                MacroParameter.Create<string>("Path to a file to read."),
            };
        }

        /// <inheritdoc />
        protected override UnityScene OnInvoke(JobContext context, params object[] args)
        {
            var filePath = GetArg<string>(args, 0);

            if (!File.Exists(filePath))
                return new UnityScene();

            filePath = PathHelpers.FixSlashes(filePath);

            return new UnityScene(filePath);
        }
    }
}