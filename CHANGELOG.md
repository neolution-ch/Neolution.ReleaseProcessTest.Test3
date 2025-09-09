# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added

- Added SquareRoot method to Calculator class
- Added Logarithm method to Calculator class

## [1.0.3] - 2025-09-09

### Fixed

- Removed unnecessary exception in Power method for base == 2, allowing negative exponents

## [1.0.2] - 2025-09-09

### Fixed

- Added exception handling in Power method for base == 2 to prevent data corruption

## [1.0.1] - 2025-09-09

### Fixed

- Fixed Add method test to use correct out parameter syntax

## [1.0.0] - 2025-09-08

### Changed

- BREAKING: Changed Add method signature to use out parameter instead of return value

### Fixed

- Added error handling for division by zero in Divide method

## [0.2.0] - 2025-09-08

### Added

- Added Power method to Calculator class

## [0.1.1] - 2025-09-08

### Added

- Added Divide method to Calculator class

## [0.1.0] - 2025-09-08

### Added

- Sample Calculator library for release process testing
- .NET 8.0 project structure with solution file and test project
- Basic arithmetic operations (Add, Subtract, Multiply) with comprehensive unit tests
- Added comprehensive unit tests for Multiply method
- Added XML documentation comments to test methods and constructor for improved code maintainability

[unreleased]: https://github.com/neolution-ch/Neolution.ReleaseProcessTest.Test2/compare/v1.0.3...HEAD
[0.2.0]: https://github.com/neolution-ch/Neolution.ReleaseProcessTest.Test2/compare/v0.1.1...v0.2.0
[0.1.1]: https://github.com/neolution-ch/Neolution.ReleaseProcessTest.Test2/compare/v0.1.0...v0.1.1
[0.1.0]: https://github.com/neolution-ch/Neolution.ReleaseProcessTest.Test2/compare/v0.1.0-rc.0...v0.1.0

[1.0.2]: https://github.com/neolution-ch/Neolution.ReleaseProcessTest.Test2/compare/v1.0.1...v1.0.2
[1.0.1]: https://github.com/neolution-ch/Neolution.ReleaseProcessTest.Test2/compare/v1.0.0...v1.0.1
[1.0.0]: https://github.com/neolution-ch/Neolution.ReleaseProcessTest.Test2/compare/v1.0.0-rc.0...v1.0.0

[1.0.3]: https://github.com/neolution-ch/Neolution.ReleaseProcessTest.Test2/compare/v1.0.3-rc.0...v1.0.3
