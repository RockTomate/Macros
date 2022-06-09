using System.IO;
using HardCodeLab.RockTomate.Core.Data;
using HardCodeLab.RockTomate.Core.Enums;
using HardCodeLab.RockTomate.Core.Helpers;
using HardCodeLab.RockTomate.Core.Attributes;

namespace HardCodeLab.RockTomate.Core.Macros
{
    [Macro(FieldType.Input, "path")]
    public class ResolvePathMacro : BaseMacro<string[]>
    {
        /// <inheritdoc />
        protected override Parameter[] GetParameters()
        {
            return new[]
            {
                Parameter.Create<string>("Path to resolve."),
                Parameter.Create<bool>("Whether to convert paths to be relative to root project directory."),
            };
        }

        /// <inheritdoc />
        protected override string[] OnInvoke(JobContext context, params object[] args)
        {
            var path = GetArg<string>(args, 0);
            var convertToRelative = GetArg<bool>(args, 1);

            return PathHelpers.ResolvePaths(path, false, SearchOption.AllDirectories, convertToRelative);
        }
    }
}