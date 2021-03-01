#if NET_4_6 || NET_STANDARD_2_0

using HardCodeLab.RockTomate.Core.Data;
using HardCodeLab.RockTomate.Core.Enums;
using HardCodeLab.RockTomate.Core.VC.Git;
using HardCodeLab.RockTomate.Core.Attributes;

namespace HardCodeLab.RockTomate.Core.Macros
{
    [Macro(FieldType.Input, "get_git_current_branch")]
    public class GitGetCurrentBranchMacro : BaseMacro<string>
    {
        protected override Parameter[] GetParameters()
        {
            return new[]
            {
                Parameter.Create<string>("Path to the Git repository."),
            };
        }

        protected override string OnInvoke(JobContext context, params object[] args)
        {
            var path = GetArg<string>(args, 0);
            return GitUtils.GetCurrentBranch(path);
        }
    }
}

#endif