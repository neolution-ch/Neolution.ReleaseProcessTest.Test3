# Release Process for Packages

This document describes the simplified and automated release process for our Open Source packages.

## Requirements & Goals

Our release process is designed to achieve the following:

- **Automation:** Automate as much as possible to reduce human error. The act of releasing should be a routine, low-risk event.
- **Simplicity:** The process should be simple enough for any team member to perform a standard release with confidence.
- **Consistency:** The process is the same for all packages, ensuring predictable and reliable releases.
- **Clarity:** Maintain a clear and useful `CHANGELOG.md` for our users, following the Keep a Changelog standard.
- **Adherence to Standards:** Strictly follow Semantic Versioning (SemVer) to communicate the impact of our changes.

## Guiding Principles

1. **The `main` branch is the source of truth.** It always contains the code for the *next* potential release and should always be in a stable state.
2. **Developers interact with the GitHub UI, not complex Git commands.** Releases are triggered via a GitHub Actions workflow, not from a local machine.
3. **The `CHANGELOG.md` is our contract.** Every user-facing change must be accompanied by an entry in the changelog.
4. **Releases are marked by tags, not branches.** The `main` branch is the only long-lived branch. All other branches (e.g., `release/*`, `hotfix/*`, `feature/*`) are temporary and must be deleted after their purpose is served.
5. **`main` branch is protected - all merges must be via pull request. Only the GitHub release-bot may merge directly for changelog updates.**

## Tools

To achieve these goals, we will use the following tools and standards:
s

- [Semantic Versioning](https://semver.org/)
- [Keep a Changelog](https://keepachangelog.com/)

## The Developer's Responsibility: The Changelog Contract

This entire automated process relies on one simple rule for every developer.

> **Every Pull Request (PR) that introduces a user-facing change MUST include an update to the `[Unreleased]` section of the `CHANGELOG.md` file.**

PR reviewers are responsible for enforcing this.

### Example `CHANGELOG.md` on the `main` branch

```markdown
# Changelog
...
## [Unreleased]

### Added
- Feature to export user data to JSON.
- New CancellationToken parameter to `ProcessAsync` method.

### Fixed
- Resolved a null reference exception when the input string is empty.
```

### CHANGELOG Integrity Rules

- CHANGELOG.md must only be manually edited under the [Unreleased] section.
- During merge conflicts, only resolve conflicts without adding or removing entries, preserving both release history and ongoing development entries.

---

## How to Release: The Three Paths

There are three release scenarios. The first path will cover the vast majority of all releases, while the other two handle more advanced, less frequent scenarios.

### What the automation always handles

#### For pre-releases

- It calculates the new version number
- It reads the contents of the `[Unreleased]` section to use for the release notes.
- It creates a new Git tag (e.g., `v1.3.0-alpha.0`).
- It creates a formal GitHub Release, using the changelog content for the release notes.

#### For stable releases

- It calculates the new version number
- It reads the contents of the `[Unreleased]` section to use for the release notes.
- It updates `CHANGELOG.md`: The `[Unreleased]` content is moved under a new version heading (e.g., `[1.3.0] - 2023-10-27`).
- It creates a new, empty `[Unreleased]` section.
- It commits this updated file back to the `main` branch.
- It creates a new Git tag (e.g., `v1.3.0`).
- It creates a formal GitHub Release, using the changelog content for the release notes.

### Path 1: The Standard Release

Use this path when you want to release the current state of the `main` branch.

This process is the same for stable (`1.2.3`) and pre-releases (`-alpha.0`,`-beta.0`,`-rc.0`).

**Before running the automation:** Make sure that the `[Unreleased]` section of the `CHANGELOG.md` file includes all updates of the new release.

### Path 2: The Stabilization Release

Use this path when you need to prepare a major or minor release (e.g., `2.0.0`) while allowing new, unrelated feature development to continue on the `main` branch.

This involves creating a temporary `release/*` branch to act as a feature-frozen staging area.

**Before running the automation:** Create a Release Branch from `main` with the targeted version in the name (e.g., `release/v2.0.0`).

Use only stable version numbers in the name. You can still produce pre-releases from that branch, they will use that version number as the base.

*From this point, the `release/v2.0.0` branch is feature-frozen. Only fixes for this specific release are allowed. `main` is now free to accept features for the next version (e.g., `2.1.0`).*

Make sure that the `[Unreleased]` section of the `CHANGELOG.md` file includes all updates of the stabilized release.

Bug fixes can be cherry-picked into `main` at any point during the stabilization process.

**Critical**: The release branch must be preserved until a stable release is produced from it. Do not delete the release branch before that point in time, as it could make it impossible to continue isolated stabilization work.

### Path 3: The Hotfix Release

Use this path when you need to patch an older stable or pre-release version without including all the new features from `main`.** For example, fixing a critical bug in `v1.2.3` when `main` is already on its way to `v2.0.0`.

**Before running the automation:** Create a Hotfix Branch (e.g., `hotfix/stream-buffer-issue`). from the old version's Tag.

Make sure that the `[Unreleased]` section of the `CHANGELOG.md` file includes all updates of the hotfix release.

### Additional automation after Path 2 and 3

After a `release/*` or a `hotfix/*` branch has produced a stable release, a pull request is automatically created to merge that branch back into `main` to ensure all changes and fixes are included in future development.

Resolve any CHANGELOG.md merge conflicts carefully, preserving both release history and ongoing development entries.

With merging the pull request the branch can be safely deleted. The commit of the release has been tagged already.

---

## Implementation Details

All workflows use [release-it](https://github.com/release-it/release-it) with the [keep-a-changelog](https://github.com/release-it/keep-a-changelog) plugin to automate versioning, changelog management, and GitHub releases.

---

## Initial Release

To create the very first release of a package (e.g., `v0.1.0`):

1. Ensure your `CHANGELOG.md` file is created and has an `[Unreleased]` section with an entry like "Initial release 🎉".
2. Follow **Path 1: The Standard Release**.
