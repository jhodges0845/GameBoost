# Changelog

All notable changes to **GameBoost** will be documented in this file.
## [Unreleased]


## [0.4.0] - 2025-03-08

### Added
- Added IScreen to handle screen sizing for rendering
- Updated summary to DrawText in IRenderContent
- Added Dot method in Vector2D to handle determining direction of 2 vector2Ds
- Added TextureDemo to support rendering Textures.

### Modified
- Modified PhysicsDemo to use new IRendering, ITexture, and IScreen
- Fixed Test for Physics to handle the changes to Move.
- Modified Move method in PhysicsBody to fix issue when testing with PongDemo. 
- replaced pong demo to use new Texture logic instead of grid console.
- Fixed Gravity in PhysicsBody.cs
- Modifyed PhsyicsDemo to showcase Rendering methods added

### Removed
- Removed RenderContext to remove dependency to specifc versions of windows.


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