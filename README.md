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
- `GameData/NotEnoughShuttles/` — our RP-1 patches, part naming, and Harmony aero plugin
- `kOS-Scripts/` — vendored giuliodondi kOS guidance scripts (ascent, entry, legacy reentry sim). See [kOS-Scripts/README.md](kOS-Scripts/README.md).

## Install

Grab the latest release ZIP from [Releases](https://github.com/Alex6511/NotEnoughShuttles/releases) and extract it directly into your KSP install root (the folder containing `KSP_x64.exe`). The ZIP has two top-level directories that merge into your install:

```
your-KSP-root/
├── GameData/                ← parts, configs, Harmony DLL go here
│   ├── SPACE_SHUTTLE_SYSTEM/
│   └── NotEnoughShuttles/
└── Ships/Script/            ← kOS guidance scripts go here
    ├── Libraries/           (shared by OPS1 + OPS3)
    ├── Shuttle_OPS1/        (ascent guidance package)
    ├── Shuttle_OPS3/        (entry guidance package)
    └── *.ks                 (launcher scripts: ops1.ks, ops3.ks, etc.)
```

`Ships/Script/` is where kOS looks for its archive volume — scripts placed here are available to any vessel running a kOS CPU. Run guidance via the kOS terminal, e.g. `RUN /ops1.ks` for ascent or `RUN /ops3.ks` for entry.

### Required dependencies (install separately)

- RP-1 (or RP-1 Full Thrust) with full Realism Overhaul stack
- FerramAerospaceResearch (dkavolis build — the one RP-1 ships)
- kOS 1.3+ (for the guidance scripts)
- Waterfall, ASET, B9PartSwitch, CRP, KSPWheel, Textures Unlimited, TacLS or Kerbalism

### Cloning the repo for development

If you want to clone for development instead of using a release: the layout in the source tree differs slightly (kOS scripts live under `kOS-Scripts/` for clarity, not the install-ready `Ships/Script/` flat layout). The GitHub Action under `.github/workflows/package.yml` is what produces the install-ready ZIP for releases.

## Licensing

This is a layered fork — different folders trace back to different upstream authors with different stated licenses. See [LICENSING.md](LICENSING.md) for the full attribution map. The short version:

- Original additions in this repo: **MIT** (see [LICENSE](LICENSE))
- `GameData/SPACE_SHUTTLE_SYSTEM/`: **CC BY-NC-SA 4.0** (inherited from SpaceODY's fork, with GPL-2.0 components from the Orbiter2010 lineage)
- Vendored kOS scripts: **CC BY 4.0** where stated by upstream; OPS1 has no upstream license and is vendored on a good-faith basis (see [NOTICE](kOS-Scripts/Shuttle-OPS1-ascent/NOTICE.md))

## Status

Work in progress. See upstream for assembly instructions and full feature list.
