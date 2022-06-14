using HarmonyLib;
using Overmine.API;
using UnityEngine;

public class Backtravel : Mod
{
    public const string HarmonyInstanceID = "com.knugel.backtravel";
    
    public Backtravel(ModResources resources) : base(resources)
    {
        Patch<WarpPopupPatches>();
    }
    
    private static void Patch<T>()
    {
        Debug.Log($"Patch: {typeof(T).Name}");
        Harmony.CreateAndPatchAll(typeof(T), HarmonyInstanceID);
    }
}
