# kOS Scripts (vendored)

Three giuliodondi kOS packages, vendored verbatim from their upstream repos. Each subfolder is self-contained — the `Ships/Script/Libraries/` files are duplicated across packages because each upstream repo carries its own (slightly diverged) copy, and the scripts use absolute paths like `RUN /Libraries/...` that would break if merged.

| Folder | Purpose | Upstream | Commit |
|---|---|---|---|
| `Shuttle-OPS1-ascent/` | Powered Explicit Guidance (UPFG) ascent + abort logic | [kOS-Shuttle_OPS1](https://github.com/giuliodondi/kOS-Shuttle_OPS1) | `bef4e36` |
| `Shuttle-OPS3-entry/` | Entry, TAEM, Approach, GRTLS guidance | [kOS-Shuttle-OPS3](https://github.com/giuliodondi/kOS-Shuttle-OPS3) | `dfef445` |
| `ShuttleEntrySim-legacy/` | Older deorbit + entry sim (predecessor to OPS3) | [kOS-ShuttleEntrySim](https://github.com/giuliodondi/kOS-ShuttleEntrySim) | `db52d02` |

## Install

Copy the contents of **one ascent + one entry** package's `Ships/Script/` into your KSP install's `Ships/Script/` directory. Typical pairing is `Shuttle-OPS1-ascent` + `Shuttle-OPS3-entry`. `ShuttleEntrySim-legacy` is included for archival reference and should not be combined with OPS3 in the same install.

See each subfolder's `README.md` for usage details from the upstream author.

## Updating

To pull a newer upstream version, re-clone the upstream repo, replace the relevant subfolder's `Ships/` contents, and update the commit ref in this table.
