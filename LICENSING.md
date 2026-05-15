# Licensing & Attribution Map

NotEnoughShuttles is a multi-layered fork. Different folders trace back to different upstream authors with different stated licenses. This document records who owns what and under which terms.

## Quick map

| Path | License | Origin |
|---|---|---|
| `LICENSE`, `README.md`, `LICENSING.md` | MIT | NotEnoughShuttles maintainers |
| `GameData/SPACE_SHUTTLE_SYSTEM/` | CC BY-NC-SA 4.0 (with GPL-2.0 components) | See "SSS lineage" below |
| `kOS-Scripts/Shuttle-OPS1-ascent/` | Not explicitly licensed by upstream (see "OPS1 note" below) | giuliodondi |
| `kOS-Scripts/Shuttle-OPS3-entry/` | CC BY 4.0 | giuliodondi |
| `kOS-Scripts/ShuttleEntrySim-legacy/` | CC BY 4.0 | giuliodondi |
| `FARShuttleAerodynamicModel/` (source) | Implicitly under same terms as parent SSS fork | giuliodondi |
| Future original additions (RP-1 patches, Harmony plugin source) | MIT | NotEnoughShuttles maintainers |

## SSS lineage

The Space Shuttle parts mod has a long history. As best as can be reconstructed:

1. **Orbiter2010 Shuttle addon** — original models/concepts by Urwumpe, released under GPL-2.0.
2. **Space Shuttle System (SSS)** — ported to KSP and expanded by DECQ, Dragon01, Olympic1, Radar, and Urwumpe. Released under GPL-2.0 with express permission from Urwumpe for the Orbiter2010-derived components. ([SpaceDock](https://spacedock.info/mod/1178/Space%20Shuttle%20System))
3. **[Space-Shuttle-System-Expanded](https://github.com/SpaceODY/Space-Shuttle-System-Expanded)** — fork by SpaceODY, stated as CC BY-NC-SA 4.0 in README.
4. **[Space-Shuttle-System-realistic-aerodynamics](https://github.com/giuliodondi/Space-Shuttle-System-realistic-aerodynamics)** — fork by giuliodondi adding realistic aero, Waterfall, texture overhaul. No LICENSE file; inherits SpaceODY's CC BY-NC-SA 4.0.
5. **NotEnoughShuttles** — this fork. Inherits the most-restrictive applicable upstream terms for the SSS content (CC BY-NC-SA 4.0). GPL-2.0 components from Orbiter2010 may still apply to specific assets — treat the whole SSS directory as the more restrictive of the two when in doubt.

**Practical implication:** redistribution of `GameData/SPACE_SHUTTLE_SYSTEM/` content must:
- Provide attribution to all upstream authors (preserved here in `GameData/SPACE_SHUTTLE_SYSTEM/`'s contents).
- Be non-commercial (CC BY-NC clause).
- Use a compatible license downstream (ShareAlike).

## OPS1 note

[kOS-Shuttle_OPS1](https://github.com/giuliodondi/kOS-Shuttle_OPS1) has no explicit LICENSE file or in-README license badge. By copyright default this means the author retains all rights. We have vendored it here with full attribution and unmodified content because:

- It is the natural ascent-guidance companion to OPS3 (which the same author released under CC BY 4.0)
- Re-implementing it from scratch would be impractical
- The vendoring is verbatim with credit, which falls within the spirit of CC BY 4.0 even if not explicitly granted

If the upstream author objects, we will remove it. If the upstream author clarifies the intended license, we will update this document. The vendored content's commit reference (`bef4e36`) is tracked in `kOS-Scripts/README.md` for reproducibility.

## Credits

Detailed credit chain follows the SSS lineage above. Specific contributors thanked by name in upstream READMEs (preserved in their respective subdirectories):

- DECQ, Dragon01, Olympic1, Radar, Urwumpe (original SSS authors)
- zer0Kerbal ([SpaceShuttleSystem](https://github.com/zer0Kerbal/SpaceShuttleSystem) stewardship)
- DylanSemrau (alternate SSS branch)
- vevladdd (Waterfall support implementation)
- Al2Me6 (RCS and SSME templates)
- SpaceODY / "NASA Fan" (SSS-Expanded fork)
- giuliodondi (realistic aero rewrite, all three kOS guidance programs)
- FlandreScarlet1 (Module Occlusion Heat, cockpit and rudder modeling)

## License full text

- [CC BY-NC-SA 4.0](https://creativecommons.org/licenses/by-nc-sa/4.0/legalcode)
- [CC BY 4.0](https://creativecommons.org/licenses/by/4.0/legalcode)
- [GPL-2.0](https://www.gnu.org/licenses/old-licenses/gpl-2.0.html)
- MIT — see `LICENSE` in this repo
