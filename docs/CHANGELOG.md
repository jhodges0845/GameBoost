# Changelog

All notable changes to **GameBoost** will be documented in this file.
## [Unreleased]

- No unreleased changes yet.

## [0.3.0] - 2025.03.08

### Added
- `Camera2D` struct for 2D camera management with movement, zoom, and visibility checking.
- `SpriteBatch` class for efficient sprite batching with camera-based culling.
- Updated `RenderingUtils` with camera-specific coordinate conversions.
- NUnit tests for `Camera2D` and `SpriteBatch`.

### Modified
- Workflow file to use `self-hosted` instead of `ubuntu-latest`

## [0.2.0] - 2025-03-08

### Added
- **Rendering Module**: Introduced `GameBoost.Rendering` with:
  - `Sprite` struct for 2D sprite representation with position, size, rotation, and texture ID.
  - `Sprite.Translate`, `Sprite.Rotate`, and `Sprite.Scale` methods for basic transformations.
  - `RenderingUtils` class with `ScreenToWorld`, `WorldToScreen`, and `GetSpriteCenter` methods for coordinate conversions and sprite positioning.
- **Tests**: Added NUnit tests for `Sprite` and `RenderingUtils` in `GameBoost.Rendering.Tests`.
- **CI**: Updated GitHub Actions workflow to include `GameBoost.Rendering.Tests`.

## [0.1.0] - 2025-03-01

### Added
- **Core Module**: Initial `GameBoost.Core` with `Vector2D` struct for 2D vector math and `MathUtils` for clamping and interpolation.
- **Physics Module**: Initial `GameBoost.Physics` with `PhysicsBody` struct for 2D physics and `PhysicsUtils` for collision resolution.
- **Tests**: NUnit tests for `GameBoost.Core` and `GameBoost.Physics`.
- **CI**: Set up GitHub Actions for automated building and testing on push/pull requests.
- **Documentation**: Added `README.md` with build status badge and basic project info.