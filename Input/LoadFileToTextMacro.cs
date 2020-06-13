using System.IO;
using System.Text;
using HardCodeLab.RockTomate.Core.Data;
using HardCodeLab.RockTomate.Core.Enums;
using HardCodeLab.RockTomate.Core.Helpers;
using HardCodeLab.RockTomate.Core.Attributes;

namespace HardCodeLab.RockTomate.Core.Macros
{
    /// <summary>
    /// Loads text file contents from given file path
    /// </summary>
    [Macro(FieldType.Input, "read")]
    public class LoadFileToTextMacro : BaseMacro<string[]>
    {
        /// <inheritdoc />
        protected override Parameter[] GetParameters()
        {
            return new[]
            {
                Parameter.Create<string>("Path to a file to read."),
            };
        }

        /// <inheritdoc />
        protected override string[] OnInvoke(JobContext context, params object[] args)
        {
            var filePath = GetArg<string>(args, 0);

            var resolvedPaths = PathHelpers.ResolvePaths(filePath);
            var results = new string[resolvedPaths.Length];

            for (var i = 0; i < resolvedPaths.Length; i++)
            {
                results[i] = File.ReadAllText(resolvedPaths[i], Encoding.UTF8);
            }

            return results;
        }
    }
}