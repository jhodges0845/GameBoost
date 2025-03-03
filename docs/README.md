# GameBoost

![Build Status](https://github.com/jhodges0845/GameBoost/actions/workflows/build.yml/badge.svg)

**GameBoost** is an open-source .NET library designed to accelerate game development by providing lightweight, modular utilities. Whether you're an indie developer, part of an AA team, or working at a AAA studio, GameBoost offers tools to streamline common tasks without forcing you into a full engine. Our mission is to support the game industry with free, community-driven solutions—no profits, just progress.

## Features
- **Core Utilities**: Vector math (`Vector2D`) and helper functions (`MathUtils`) for clamping and interpolation.
- **Physics Helpers**: Basic 2D physics with `PhysicsBody` (movement, collision) and `PhysicsUtils` (collision resolution).
- **Extensible**: Modular design lets you add new features easily (e.g., rendering, audio).
- **Cross-Platform**: Built on .NET 8.0 for compatibility across Windows, macOS, and Linux.

## Getting Started

### Prerequisites
- .NET SDK 8.0.100 or later
- Git (to clone the repo)

### Installation
1. **Clone the Repository**:
``` git clone https://github.com/jhodges0845/GameBoost.git```
1. Navigate to the directory
``` cd GameBoost ```
1. Build solution
``` dotnet build ```
1. Run Unit Tests
``` dotnet test ``` 

# Usage
```csharp
using GameBoost.Core;
using GameBoost.Physics;

var body = new PhysicsBody(new Vector2D(0, 0), new Vector2D(10, 0), 1f, 2f, 2f);
body = body.Move(0.1f); // Move for 0.1 seconds
Console.WriteLine($"New Position: ({body.Position.X}, {body.Position.Y})");
```

# Project Structure
GameBoost/
|-- src/                    # Library source code
|-- |--- GameBoost.Core/     # Shared utilities
|-- |-- GameBoost.Physics/  # Physics helpers
|-- tests/                  # Unit tests (NUnit)
|-- |-- GameBoost.Core.Tests/
|-- |-- GameBoost.Physics.Tests/
|-- samples/                # Example projects
|-- |-- PhysicsDemo/
|-- docs/                   # Documentation
|-- GameBoost.sln           # Solution file


## Contributing
We’d love your help! See CONTRIBUTING.md for guidelines on how to contribute code, report issues, or suggest features.

### Building Locally
* Restoure: ```bash dotnet restore```
* Build: ```bash dotnet build --configuration Release ```
* Test: ```bash dotnet test ```

## Build Status
GameBoost uses GitHub Actions to ensure every push and pull request builds and tests successfully. The badge at the top shows the latest status:
* Green = All buids and tests passed
* Red Somthing failed (Check the actions tab)

## License
This project is licensed under the MIT License—free to use, modify, and distribute.

## Acknowledgments
Built with .NET 8.0 for modern performance.
Thanks to contributors and the game dev community for inspiring this effort!