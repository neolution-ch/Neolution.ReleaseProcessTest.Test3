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

1.  **The `main` branch is the source of truth.** It always contains the code for the *next* potential release and should always be in a stable state.
2.  **Developers interact with the GitHub UI, not complex Git commands.** Releases are triggered via a GitHub Actions workflow, not from a local machine.
3.  **The `CHANGELOG.md` is our contract.** Every user-facing change must be accompanied by an entry in the changelog.
4.  **Releases are marked by tags, not branches.** The `main` branch is the only long-lived branch. All other branches (`feature/*`, `release/*`, `hotfix/*`) are temporary and must be deleted after their purpose is served.

## Tools

To achieve these goals, we will use the following tools and standards:
- [Semantic Versioning](https://semver.org/)
- [Keep a Changelog](https://keepachangelog.com/)
- A **single, manual-trigger GitHub Action** powered by standard command-line tools and actions.

## The Developer's Responsibility: The Changelog Contract

This entire automated process relies on one simple rule for every developer.

> **Every Pull Request (PR) that introduces a user-facing change MUST include an update to the `[Unreleased]` section of the `CHANGELOG.md` file.**

PR reviewers are responsible for enforcing this.

**Example `CHANGELOG.md` on the `main` branch:**
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

---

## How to Release: The Three Paths

There are three release scenarios. The first path will cover the vast majority of all releases, while the other two handle more advanced, less frequent scenarios.

### Path 1: The Standard Release (The Common Case)

**Use this path when you want to release all the new features and fixes that have been merged into the `main` branch.** This process is the same for stable (`1.2.3`), release candidate (`-rc.0`), beta, and alpha releases.

1.  **Go to your repository's "Actions" tab.**
2.  **Select the "Release OSS Package" workflow.**
3.  **Click the "Run workflow" button.** Make sure the `main` branch is selected.
4.  **Fill out the inputs:**
    *   **`level`**: Choose `patch`, `minor`, or `major` depending on the changes in the "Unreleased" section.
    *   **`type`**: Choose `stable` for a production release, or `rc`, `beta`, `alpha` for a pre-release.
5.  **Click "Run workflow".**

**That's it. The automation handles everything else:**
*   It calculates the new version number based on your input.
*   It reads the contents of the `[Unreleased]` section to use for the release notes.
*   **For `stable` releases only:**
    *   It updates `CHANGELOG.md`: The `[Unreleased]` content is moved under a new version heading (e.g., `[1.3.0] - 2023-10-27`).
    *   It creates a new, empty `[Unreleased]` section.
    *   It commits this updated file back to the `main` branch.
*   It creates a new Git tag (e.g., `v1.3.0` or `v1.3.0-rc.0`).
*   It creates a formal GitHub Release, using the changelog content for the release notes.
*   It builds, packages, and publishes the new version to NuGet.

### Path 2: The Stabilization Release (The Advanced Case)

**Use this path when you need to prepare a major or minor release (e.g., `2.0.0`) while allowing new, unrelated feature development to continue on the `main` branch.** This involves creating a temporary `release/*` branch to act as a feature-frozen staging area.

1.  **Create a Release Branch from `main`.**
    *   Once all features for the upcoming release are on `main`, create the stabilization branch.
    ```bash
    # On your local machine, ensure main is up-to-date
    git checkout main
    git pull
    
    # Create the release branch and push it
    git checkout -b release/v2.0.0
    git push --set-upstream origin release/v2.0.0
    ```
    *From this point, the `release/v2.0.0` branch is feature-frozen. Only fixes for this specific release are allowed. `main` is now free to accept features for the next version (e.g., `2.1.0`).*

2.  **Publish Pre-Releases (e.g., RCs) from the Release Branch.**
    *   Go to Actions, select the "Release OSS Package" workflow.
    *   **Crucially, use the "Branch" dropdown to select your `release/v2.0.0` branch.**
    *   For the inputs, specify the **exact version number** (e.g., `2.0.0-rc.0`) and set the `type` to `rc` (or `beta`).

3.  **Apply Bug Fixes to the Release Branch and `main`.**
    *   If a bug is found during testing, commit the fix to the `release/v2.0.0` branch first.
    *   **CRITICAL: Immediately merge the fix back into `main`** to prevent regressions.
    ```bash
    # After committing the fix to release/v2.0.0
    git checkout main
    git pull
    git merge --no-ff release/v2.0.0
    git push
    ```

4.  **Publish the Final Stable Release.**
    *   Run the workflow one last time from the `release/v2.0.0` branch.
    *   Specify the **exact version number** (e.g., `2.0.0`) and set the `type` to `stable`.

5.  **Clean up.** The `release/v2.0.0` branch can now be safely deleted.

### Path 3: The Hotfix Release (The Exceptional Case)

**Use this path ONLY when you need to patch an older stable or pre-release version without including all the new features from `main`.** For example, fixing a critical bug in `v1.2.3` when `main` is already on its way to `v2.0.0`.

This process involves a few manual Git commands because it is an exceptional event that requires deliberate, careful action.

1.  **Create a Hotfix Branch from the Old Version's Tag.**
    ```bash
    # On your local machine, check out the specific tag you need to patch
    git checkout -b hotfix/v1.2.4 v1.2.3
    ```

2.  **Apply the Fix.** There are two ways to do this:
    *   **A) The fix is already on `main`:** Cherry-pick the specific commit.
        ```bash
        git cherry-pick <commit-hash-of-the-fix-from-main>
        ```
    *   **B) The fix is new:** Make the code changes directly on this hotfix branch and commit them.

3.  **Manually Update the Changelog.** On the `hotfix/v1.2.4` branch, edit `CHANGELOG.md` to document the fix under a new version heading. This is a rare manual edit for an exceptional case.

4.  **Push the Hotfix Branch.**
    ```bash
    git push --set-upstream origin hotfix/v1.2.4
    ```

5.  **Run the Release Workflow from the Hotfix Branch.**
    *   Go to the "Actions" tab and select the "Release OSS Package" workflow.
    *   **Crucially, use the "Branch" dropdown to select your `hotfix/v1.2.4` branch.**
    *   For the inputs, specify the **exact version number** (e.g., `1.2.4`) and set the type to `stable`.

6.  **Merge the Hotfix Back into `main`.** This is a critical final step to ensure the fix is not lost in future releases.
    ```bash
    # Switch back to main and make sure it's up-to-date
    git checkout main
    git pull

    # Merge the completed hotfix branch
    git merge --no-ff hotfix/v1.2.4
    git push
    ```
    *You may need to resolve a small merge conflict in `CHANGELOG.md`. This is expected. Simply ensure the fix is noted in the `[Unreleased]` section of `main`'s changelog.*

7.  **Clean up.** The `hotfix/v1.2.4` branch can now be safely deleted from GitHub and your local machine.

---
### Initial Release

To create the very first release of a package (e.g., `0.1.0`):
1. Ensure your `CHANGELOG.md` file is created and has an `[Unreleased]` section with an entry like "Initial release 🎉".
2. Follow **Path 1: The Standard Release**.
3. Set the `level` input to `minor` and the `type` to `stable`. This will create the `0.1.0` release.
