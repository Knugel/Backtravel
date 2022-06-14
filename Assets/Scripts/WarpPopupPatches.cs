using System.Collections.Generic;
using System.Reflection.Emit;
using HarmonyLib;
using Thor;

public class WarpPopupPatches
{
    [HarmonyTranspiler]
    [HarmonyPatch(typeof(WarpPopup), "Initialize")]
    public static IEnumerable<CodeInstruction> OnWarpPopup(IEnumerable<CodeInstruction> instructions, ILGenerator il)
    {
        var matcher = new CodeMatcher(instructions, il)
            .MatchForward(true, new CodeMatch(i => i.opcode == OpCodes.Brfalse));
            
        // Remove the condition that the map zone has to be later then the current one
        return matcher.RemoveInstructions(13).InstructionEnumeration();
    }
}