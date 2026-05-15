# NotEnoughShuttles

A fork of [Space-Shuttle-System-realistic-aerodynamics](https://github.com/giuliodondi/Space-Shuttle-System-realistic-aerodynamics) by giuliodondi, adapted for full RP-1 career compatibility.

The goal is to make every part of the SSS shuttle stack appear and function correctly in RP-1's tech tree and entry-cost system, while preserving the realistic NASA-table aerodynamics from the upstream mod.

## Lineage

- Original Space Shuttle System: DECQ, Dragon01, Olympic1, Urwumpe, zer0Kerbal
- [Space-Shuttle-System-Expanded](https://github.com/SpaceODY/Space-Shuttle-System-Expanded) — SpaceODY
- [Space-Shuttle-System-realistic-aerodynamics](https://github.com/giuliodondi/Space-Shuttle-System-realistic-aerodynamics) — giuliodondi (custom aero model, Waterfall, texture overhaul)
- **NotEnoughShuttles** — RP-1 patches, Harmony-based aero plugin (no FAR fork required)

Special thanks to FlandreScarlet1 for the Module Occlusion Heat and cockpit/rudder modelling work carried over from upstream.

## Contents

- `GameData/SPACE_SHUTTLE_SYSTEM/` — the shuttle parts mod (from upstream)
- `kOS-Scripts/` — vendored giuliodondi kOS guidance scripts (ascent, entry, legacy reentry sim). See [kOS-Scripts/README.md](kOS-Scripts/README.md).

## Licensing

This is a layered fork — different folders trace back to different upstream authors with different stated licenses. See [LICENSING.md](LICENSING.md) for the full attribution map. The short version:

- Original additions in this repo: **MIT** (see [LICENSE](LICENSE))
- `GameData/SPACE_SHUTTLE_SYSTEM/`: **CC BY-NC-SA 4.0** (inherited from SpaceODY's fork, with GPL-2.0 components from the Orbiter2010 lineage)
- Vendored kOS scripts: **CC BY 4.0** where stated by upstream; OPS1 has no upstream license and is vendored on a good-faith basis (see [NOTICE](kOS-Scripts/Shuttle-OPS1-ascent/NOTICE.md))

## Status

Work in progress. See upstream for assembly instructions and full feature list.
