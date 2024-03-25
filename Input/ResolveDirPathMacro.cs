using System.IO;
using HardCodeLab.RockTomate.Core.Data;
using HardCodeLab.RockTomate.Core.Enums;
using HardCodeLab.RockTomate.Core.Helpers;
using HardCodeLab.RockTomate.Core.Attributes;

namespace HardCodeLab.RockTomate.Core.Macros
{
    [Macro(FieldType.Input, "dirpath")]
    public class ResolveDirPathMacro : BaseMacro<string[]>
    {
        /// <inheritdoc />
        protected override Parameter[] GetParameters()
        {
            return new[]
            {
                Parameter.Create<string>("Path to resolve."),
                Parameter.Create<bool>("Whether to convert paths to be relative to root project directory."),
                Parameter.Create<bool>("Whether the search should be shallow or not (top directories only)"),
            };
        }

        /// <inheritdoc />
        protected override string[] OnInvoke(JobContext context, params object[] args)
        {
            var path = GetArg<string>(args, 0);
            var convertToRelative = GetArg<bool>(args, 1);
            var searchOption = GetArg<bool>(args, 2) ? SearchOption.TopDirectoryOnly : SearchOption.AllDirectories;

            return PathHelpers.ResolvePaths(path, true, searchOption, convertToRelative);
        }
    }
}