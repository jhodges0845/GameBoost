# GameBoost

![Build Status](https://github.com/jhodges0845/GameBoost/actions/workflows/build.yaml/badge.svg)

**GameBoost** is a modular .NET game-development framework focused on reusable systems, clean abstractions, and lightweight tooling without requiring a full game engine.

The project is structured so core game logic, rendering concerns, and physics can evolve independently behind well-defined interfaces. It serves both as a practical library and as an engineering sandbox for exploring portable game architecture in C#.

## Why GameBoost Exists

Game development often starts simple and becomes tightly coupled as rendering, physics, input, scene logic, and platform-specific concerns grow together.

GameBoost explores a different approach: separate those responsibilities into reusable modules so systems can be tested, replaced, and extended without rewriting the entire application.

## Current Modules

### GameBoost.Core
Shared game-development primitives and utilities used across the framework.

### GameBoost.Rendering
Rendering abstractions designed to keep game logic independent from a specific rendering implementation.

### GameBoost.Physics
Lightweight 2D physics helpers for movement, collision behavior, and related calculations.

## Samples

The repository includes small applications that exercise the framework in realistic scenarios:

- **PongClone** - demonstrates a complete small game built using GameBoost components
- **PhysicsDemo** - exercises physics and collision behavior
- **TextureDemo** - demonstrates rendering and texture abstractions

## Architecture

```text
GameBoost/
├── modules/
│   ├── GameBoost.Core/
│   ├── GameBoost.Rendering/
│   └── GameBoost.Physics/
├── samples/
│   ├── PongClone/
│   ├── PhysicsDemo/
│   └── TextureDemo/
├── tests/
│   ├── GameBoost.Core.Tests/
│   ├── GameBoost.Rendering.Tests/
│   └── GameBoost.Physics.Tests/
├── docs/
├── GameBoost.sln
└── global.json
```

The design goal is to keep framework concerns modular and implementation details replaceable. Rendering, physics, and core systems are separated rather than embedded into a single monolithic engine layer.

## Engineering Focus

GameBoost is particularly focused on:

- Interface-driven design
- Separation of concerns
- Reusable game systems
- Rendering abstraction
- 2D physics and collision behavior
- Cross-platform .NET development
- Unit testing
- CI-driven validation

## Requirements

The repository currently targets the .NET 8 SDK and pins SDK version `8.0.114` through `global.json`.

## Getting Started

Clone the repository:

```bash
git clone https://github.com/jhodges0845/GameBoost.git
cd GameBoost
```

Restore dependencies:

```bash
dotnet restore
```

Build the solution:

```bash
dotnet build
```

Run the tests:

```bash
dotnet test
```

To explore the framework, open `GameBoost.sln` or run one of the projects under `samples/`.

## Project Status

GameBoost is an evolving project and engineering sandbox. The focus is currently on strengthening the core abstractions, expanding reusable game systems, and using sample projects to validate the framework's design.

## Documentation

Additional historical documentation and the project changelog are available in the [`docs`](./docs) directory.

## About the Project

GameBoost is part of my broader work exploring software architecture, reusable developer tooling, and game-development systems in C# and .NET.
