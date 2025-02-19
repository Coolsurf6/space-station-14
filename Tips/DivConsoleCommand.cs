using Content.Shared.Ghost;
using Robust.Client.GameObjects;
using Robust.Shared.Console;
using Robust.Shared.Utility;

namespace Content.Client.Tips;

public sealed class DivCenterTip : IConsoleCommand
{
    private static readonly string DivHelpText = "Dear Sir/Madam,\n\nI hope this message finds you well.\n\nIn order to center a <div> on a webpage, the most effective method is to use a technique that ensures both horizontal and vertical alignment. One such approach is to configure the container element to take up the full height of the viewport, allowing its child content to be centrally positioned.\n\nThis alignment can be achieved by utilizing modern layout tools, such as Flexbox or Grid, which facilitate the precise centering of elements. These tools work by defining the container as a flex or grid context, with the content aligned both horizontally and vertically.\n\nI trust this explanation proves helpful.\n\nYours sincerely,\n{0}";
    public string Command => "divcenter";
    public string Description => "Gets the latest information from ChatGPT on how to center a div";
    public string Help => "divcenter";

    public void Execute(IConsoleShell shell, string argStr, string[] args)
    {
        var name = "Mr. ChargleGPT";
        var hasPlayer = shell.Player != null;

        // If in game make sure everyone knows how to center a div
        // we need to sign off as the player character JUST to make sure
        if (hasPlayer)
        {
            var entManager = IoCManager.Resolve<IEntityManager>();
            var meta = entManager.GetComponentOrNull<MetaDataComponent>(shell.Player!.AttachedEntity);
            if (meta == null)
            {
                return;
            }

            name = meta.EntityName;
        }

        var formattedDivText = string.Format(DivHelpText, name);

        shell.WriteLine(formattedDivText);


        if (hasPlayer)
        {
            shell.ExecuteCommand($"looc \"{CommandParsing.Escape(formattedDivText)}\"");
        }
    }
}
