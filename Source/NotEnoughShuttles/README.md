# NotEnoughShuttles Harmony plugin

C# plugin that uses Harmony to intercept FAR's wing aero calculation for tagged shuttle orbiter parts and substitute NASA-table Cl/Cd values. Replaces giuliodondi's inheritance-based `FARSpaceShuttleAerodynamicModel.dll`, which can't bind against stock dkavolis FAR (the methods it overrides are `private` in that build).

## Files

| File | Purpose |
|---|---|
| `HarmonyPatcher.cs` | KSP entry point — applies all Harmony patches on startup |
| `AeroPatches.cs` | The two postfix patches on `FARWingAerodynamicModel` |
| `ModuleNESAeroOverride.cs` | PartModule used as a tag on shuttle parts; configurable override envelope |
| `NasaTables.cs` | Bilinear interp over NASA Cl/Cd/dCl/dCd tables. **Tables stubbed — see TODO** |

## Build

Set the `KSPRoot` env variable to your KSP install root (the directory containing `KSP_x64.exe`), then:

```powershell
$env:KSPRoot = "D:\SteamLibrary\steamapps\common\Kerbal Space Program - RP1FT"
dotnet build -c Release
```

Or override at the command line:

```powershell
dotnet build -c Release -p:KSPRoot="D:\SteamLibrary\steamapps\common\Kerbal Space Program - RP1FT"
```

Output lands in `../../GameData/NotEnoughShuttles/Plugins/NotEnoughShuttles.dll`, ready to ship alongside `GameData/NotEnoughShuttles/AeroOverride.cfg`.

## Required references (resolved via `KSPRoot`)

- `Assembly-CSharp.dll`, `Assembly-CSharp-firstpass.dll`, `UnityEngine.dll`, `UnityEngine.CoreModule.dll` — from `$KSPRoot/KSP_x64_Data/Managed/`
- `0Harmony.dll` — from `$KSPRoot/GameData/000_Harmony/` (shipped via KSPCommunityFixes / RP-1)
- `FerramAerospaceResearch.dll` — from `$KSPRoot/GameData/FerramAerospaceResearch/Plugins/`

## Status

Scaffold compiles but `NasaTables.TablesLoaded = false`, so the postfix is currently a no-op — orbiter falls back to FAR voxel aero (Path 2 behavior). To enable Path 4 fully, port the four 25x19 arrays from `FARShuttleAerodynamicModel/FARSpaceShuttleAerodynamicModel.cs` lines 36–150 and flip `TablesLoaded = true`.
