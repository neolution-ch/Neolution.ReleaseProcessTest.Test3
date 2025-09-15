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
5. **`main` branch is protected - all merges must be via pull request.** Only the GitHub release-bot may merge directly for changelog updates.

## Tools

To achieve these goals, we will use the following tools and standards:

- [Google Release Please](https://github.com/googleapis/release-please)
- [Semantic Versioning](https://semver.org/)
- [Keep a Changelog](https://keepachangelog.com/)

## The Developer's Responsibility: The Changelog Contract

This entire automated process relies on one simple rule for every developer.

> **Every Pull Request (PR) that introduces a user-facing change MUST include an update to the `[Unreleased]` section of the `CHANGELOG.md` file.**

PR reviewers are responsible for enforcing this.

### Controlling the Version Bump

The automation determines the next version number (patch, minor, or major) based on the section headings you use in the `[Unreleased]` block of the `CHANGELOG.md`.

- **Patch Release (`x.y.Z`):** The automation will propose a patch release if `[Unreleased]` only contains sections like `### Changed`, `### Fixed`, `### Deprecated`, `### Removed`, or `### Security`.
- **Minor Release (`x.Y.0`):** The automation will propose a minor release if `[Unresolved]` contains a `### Added` section.
- **Major Release (`X.0.0`):** To trigger a major release, you must add a line starting with `BREAKING CHANGE:` to the description of a changelog entry.

**Example for a Major Bump:**

```markdown
### Changed
- The `ProcessAsync` method now requires a `priority` parameter.
  BREAKING CHANGE: The method signature for `ProcessAsync` has changed.
```

### CHANGELOG Integrity Rules

- `CHANGELOG.md` must only be manually edited under the `[Unreleased]` section.
- During merge conflicts, only resolve conflicts without adding or removing entries, preserving both release history and ongoing development entries.

---

## How to Create a Release

All releases are created by manually running the **Release** workflow from the GitHub "Actions" tab.

1. Navigate to the **Actions** tab in the GitHub repository.
2. Select the **Release** workflow in the left sidebar.
3. Click the **"Run workflow"** dropdown.
4. Select the branch you wish to release from (`main`, `release/*`, or `hotfix/*`).
5. For pre-releases, choose a type (`alpha`, `beta`, `rc`). For a final, stable release, leave it as `stable`.
6. Click **"Run workflow"**.

The automation will then open a "Release PR" with the proposed version number and changelog. Once this PR is merged, the workflow will tag the release and create a formal GitHub Release.

### What the automation always handles

- It calculates the new version number based on the `CHANGELOG.md`.
- It reads the contents of the `[Unreleased]` section to use for the release notes.
- It updates `CHANGELOG.md`: The `[Unreleased]` content is moved under a new version heading (e.g., `[1.3.0] - 2023-10-27`).
- It creates a new, empty `[Unreleased]` section.
- It commits this updated file back to the branch.
- It creates a new Git tag (e.g., `v1.3.0` or `v1.3.0-alpha.0`).
- It creates a formal GitHub Release, using the changelog content for the release notes.

## The Three Release Paths

### Path 1: The Standard Release

Use this path when you want to release the current state of the `main` branch. This process is the same for stable (`1.2.3`) and pre-releases (`-alpha.0`, `-beta.0`, `-rc.0`).

**To run the automation:** Trigger the **Release** workflow on the `main` branch.

### Path 2: The Stabilization Release

Use this path when you need to prepare a major or minor release (e.g., `2.0.0`) while allowing new, unrelated feature development to continue on the `main` branch.

**Before running the automation:** Create a release branch from `main` with the targeted stable version in the name (e.g., `release/v2.0.0`). From this point, the release branch is feature-frozen.

**To run the automation:** Trigger the **Release** workflow on the `release/v2.0.0` branch. You can create multiple pre-releases (`alpha`, `beta`, `rc`) before the final stable release.

### Path 3: The Hotfix Release

Use this path when you need to patch an older release without including all the new features from `main`.

**Before running the automation:** Create a hotfix branch from the old version's Git tag (e.g., `hotfix/stream-buffer-issue`).

**To run the automation:** Trigger the **Release** workflow on the `hotfix/stream-buffer-issue` branch.

### Automatic Merge-Back of Release and Hotfix Branches

After a `release/*` or `hotfix/*` branch has produced a stable release, a pull request is automatically created to merge that branch back into `main` to ensure all changes and fixes are included in future development.

---

## Initial Release

To create the very first release of a package (e.g., `v0.1.0`):

1. Ensure your `CHANGELOG.md` file is created and has an `[Unreleased]` section with an entry like "Initial release 🎉".
2. Follow **Path 1: The Standard Release**.
