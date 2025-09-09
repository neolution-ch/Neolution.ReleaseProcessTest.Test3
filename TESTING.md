# Sequential Release Process Testing Guide

This document provides a comprehensive, step-by-step testing guide for the release process workflows. The guide is structured to follow the natural progression of software development, from initial releases through stabilization and hotfix scenarios.

## Overview

This testing guide covers **three sequential phases** that build upon each other:

1. **Phase 1 (Steps 1-9)**: Initial development and first releases from main branch
2. **Phase 2 (Steps 10-17)**: Stabilization releases using release/* branches  
3. **Phase 3 (Steps 18-27)**: Hotfix releases using hotfix/* branches

Each step includes:
- **Repository State Before**: Exact prerequisites needed
- **Developer Actions**: Local changes, commits, pushes (following changelog contract)
- **GitHub Actions**: Which workflow to run with exact inputs
- **Expected Repository State After**: What should be created
- **Verification**: How to confirm success

## Prerequisites

Before starting the testing sequence:

1. **Fork** the Neolution.ReleaseProcessTest repository
2. **Clone** your fork locally
3. **Enable GitHub Actions** in your fork (Settings > Actions > General > Allow all actions)
4. Ensure you have **write permissions** to create releases and tags

## Testing Steps Overview

The "Process to Use" column refers to the three release paths defined in README.md.

| Step | Version Number | Process to Use | Source Branch | Workflow | Key Actions / Notes |
|------|----------------|----------------|---------------|----------|---------------------|
| 1 | v0.1.0-alpha.0 | Standard | main | Create Pre-Release | First pre-release (alpha) |
| 2 | v0.1.0-alpha.1 | Standard | main | Create Pre-Release | Continue alpha pre-release |
| 3 | v0.1.0-beta.0 | Standard | main | Create Pre-Release | Transition to beta pre-release |
| 4 | v0.1.0-beta.1 | Standard | main | Create Pre-Release | Continue beta pre-release |
| 5 | v0.1.0-rc.0 | Standard | main | Create Pre-Release | Transition to release candidate |
| 6 | v0.1.0 | Standard | main | Create Stable Release | First stable release |
| 7 | v0.1.1 | Standard | main | Create Stable Release | Patch release development |
| 8 | v0.2.0 | Standard | main | Create Stable Release | Minor release with new features |
| 9 | v1.0.0-alpha.0 | Standard | main | Create Pre-Release | Pre-release for next major version |
| 10 | v1.0.0-alpha.1 | Stabilization | release/v1.0.0 | Create Branch Release | Alpha from release branch (create branch first) |
| 11 | v1.0.0-beta.0 | Stabilization | release/v1.0.0 | Create Branch Release | Beta from release branch (includes bug fix and merge) |
| 12 | v1.0.0-rc.0 | Stabilization | release/v1.0.0 | Create Branch Release | RC from release branch (parallel main development) |
| 13 | v1.0.0 | Stabilization | release/v1.0.0 | Create Branch Release | Final stable release from release branch |
| 14 | - | Stabilization | main | - | Merge release branch back to main |
| 15 | v1.0.1 | Hotfix | hotfix/v1.0.0 | Create Branch Release | First hotfix release (create branch, apply fix) |
| 16 | v1.0.2 | Hotfix | hotfix/v1.0.1 | Create Branch Release | Second hotfix release (cherry-pick to main) |
| 17 | v1.0.3-rc.0 | Hotfix | hotfix/v1.0.2 | Create Branch Release | Hotfix pre-release |
| 18 | v1.0.3 | Hotfix | hotfix/v1.0.2 | Create Branch Release | Stabilize hotfix pre-release |
| 19 | - | Hotfix | main | - | Final merge of all hotfixes to main |

---

## Phase 1: Initial Development and First Releases (Steps 1-9)

This phase starts with a repository that has no tags and follows the progression from first pre-release to stable releases.

### Step 1: First Pre-Release (Alpha)

**Repository State Before:**
- Repository with no tags
- CHANGELOG.md with [Unreleased] section containing initial changes

**Developer Actions:**
- Repository is ready; no additional changes needed

**GitHub Actions:**
1. Navigate to **Actions** tab in GitHub
2. Select **"Create Pre-Release"** workflow
3. Click **"Run workflow"**
4. Inputs:
   - **action**: `new`
   - **type**: `alpha`
   - **level**: `minor` (creates first version 0.1.0-alpha.0)
5. Click **"Run workflow"**

**Expected Repository State After:**
- New tag: `v0.1.0-alpha.0`
- GitHub pre-release created
- CHANGELOG.md unchanged (pre-releases don't modify changelog)

**Verification:**
- Check v0.1.0-alpha.0 tag exists in repository tags
- Verify pre-release in Releases section
- Confirm CHANGELOG.md [Unreleased] section unchanged

---

### Step 2: Continue Alpha Pre-Release

**Repository State Before:**
- Existing tag: `v0.1.0-alpha.0`
- CHANGELOG.md with [Unreleased] section

**Developer Actions:**
1. Make additional code changes (new features, bug fixes)
2. Update CHANGELOG.md [Unreleased] section with new changes (add appropriate entries under Added, Changed, Fixed, etc.)
3. Commit and push to main

**GitHub Actions:**
1. Navigate to **Actions** tab
2. Select **"Create Pre-Release"** workflow
3. Inputs:
   - **action**: `continue`
   - **type**: `alpha`
4. Run workflow

**Expected Repository State After:**
- New tag: `v0.1.0-alpha.1`
- Previous tag `v0.1.0-alpha.0` remains
- New pre-release created

**Verification:**
- Check both v0.1.0-alpha.0 and v0.1.0-alpha.1 tags exist
- Verify new pre-release with correct version

---

### Step 3: Transition to Beta Pre-Release

**Repository State Before:**
- Latest tag: `v0.1.0-alpha.1`
- CHANGELOG.md with accumulated changes in [Unreleased]

**Developer Actions:**
1. Add more changes indicating readiness for beta
2. Update CHANGELOG.md [Unreleased] section with additional entries
3. Commit and push

**GitHub Actions:**
1. Select **"Create Pre-Release"** workflow
2. Inputs:
   - **action**: `transition`
   - **type**: `beta`
3. Run workflow

**Expected Repository State After:**
- New tag: `v0.1.0-beta.0`
- Beta pre-release created
- Alpha tags remain unchanged

**Verification:**
- Check v0.1.0-beta.0 tag exists
- Confirm beta pre-release created
- Verify transition from alpha to beta numbering

---

### Step 4: Continue Beta Pre-Release

**Repository State Before:**
- Latest tag: `v0.1.0-beta.0`
- CHANGELOG.md with [Unreleased] changes

**Developer Actions:**
1. Make final bug fixes for beta
2. Update CHANGELOG.md [Unreleased] section with bug fixes
3. Commit and push

**GitHub Actions:**
1. Select **"Create Pre-Release"** workflow
2. Inputs:
   - **action**: `continue`
   - **type**: `beta`
3. Run workflow

**Expected Repository State After:**
- New tag: `v0.1.0-beta.1`
- New beta pre-release

**Verification:**
- Check v0.1.0-beta.1 tag exists
- Verify beta.1 pre-release

---

### Step 5: Transition to Release Candidate

**Repository State Before:**
- Latest tag: `v0.1.0-beta.1`
- CHANGELOG.md ready for release candidate

**Developer Actions:**
1. Perform final testing and minimal changes
2. Update CHANGELOG.md if needed with any final adjustments
3. Commit and push

**GitHub Actions:**
1. Select **"Create Pre-Release"** workflow
2. Inputs:
   - **action**: `transition`
   - **type**: `rc`
3. Run workflow

**Expected Repository State After:**
- New tag: `v0.1.0-rc.0`
- Release candidate pre-release created

**Verification:**
- Check v0.1.0-rc.0 tag exists
- Verify rc.0 pre-release

---

### Step 6: First Stable Release

**Repository State Before:**
- Latest tag: `v0.1.0-rc.0`
- CHANGELOG.md with [Unreleased] section ready for release

**Developer Actions:**
1. Ensure CHANGELOG.md [Unreleased] section is complete and ready
2. No code changes needed (release candidate is stable)

**GitHub Actions:**
1. Select **"Create Stable Release"** workflow
2. Inputs:
   - **level**: `patch` (or any level - will stabilize from RC to v0.1.0)
3. Run workflow

**Expected Repository State After:**
- New tag: `v0.1.0` (stable)
- CHANGELOG.md updated with [0.1.0] section and new empty [Unreleased]
- Stable GitHub release created
- Commit pushed to main with changelog update

**Verification:**
- Check v0.1.0 stable tag exists
- Verify stable release (not marked as pre-release)
- Confirm CHANGELOG.md now has ## [0.1.0] section and empty [Unreleased]
- Check new commit on main with changelog update

---

### Step 7: Patch Release Development

**Repository State Before:**
- Latest stable tag: `v0.1.0`
- CHANGELOG.md with empty [Unreleased] section

**Developer Actions:**
1. Make bug fixes or small improvements
2. Update CHANGELOG.md [Unreleased] section with appropriate entries in Fixed category
3. Commit and push to main

**GitHub Actions:**
1. Select **"Create Stable Release"** workflow
2. Inputs:
   - **level**: `patch`
3. Run workflow

**Expected Repository State After:**
- New tag: `v0.1.1`
- CHANGELOG.md updated with [0.1.1] section
- New stable release

**Verification:**
- Check v0.1.1 tag exists
- Verify 0.1.1 release
- Confirm CHANGELOG.md structure with both [0.1.1] and [0.1.0] sections

---

### Step 8: Minor Release with New Features

**Repository State Before:**
- Latest stable tag: `v0.1.1`
- CHANGELOG.md with empty [Unreleased] section

**Developer Actions:**
1. Add new features (backward compatible)
2. Update CHANGELOG.md [Unreleased] section with entries in Added and Changed categories
3. Commit and push to main

**GitHub Actions:**
1. Select **"Create Stable Release"** workflow
2. Inputs:
   - **level**: `minor`
3. Run workflow

**Expected Repository State After:**
- New tag: `v0.2.0`
- CHANGELOG.md updated with [0.2.0] section
- Minor version release

**Verification:**
- Check v0.2.0 tag exists
- Verify 0.2.0 release
- Confirm minor version bump in changelog

---

### Step 9: Pre-Release for Next Major Version

**Repository State Before:**
- Latest stable tag: `v0.2.0`
- CHANGELOG.md with empty [Unreleased] section

**Developer Actions:**
1. Begin work on breaking changes for v1.0.0
2. Update CHANGELOG.md [Unreleased] section with breaking changes (use "BREAKING:" prefix)
3. Commit and push to main

**GitHub Actions:**
1. Select **"Create Pre-Release"** workflow
2. Inputs:
   - **action**: `new`
   - **type**: `alpha`
   - **level**: `major`
3. Run workflow

**Expected Repository State After:**
- New tag: `v1.0.0-alpha.0`
- Major version pre-release created
- CHANGELOG.md [Unreleased] section unchanged

**Verification:**
- Check v1.0.0-alpha.0 tag exists
- Verify 1.0.0-alpha.0 pre-release
- Confirm major version jump from 0.2.0 to 1.0.0-alpha.0

---

## Phase 2: Stabilization Releases (Steps 10-14)

This phase demonstrates using release/* branches for feature-frozen stabilization while allowing continued development on main.

### Step 10: Alpha Release from Release Branch

**Repository State Before:**
- Latest tag: `v1.0.0-alpha.0`
- Main branch contains v1.0.0 features ready for stabilization
- CHANGELOG.md with [Unreleased] containing v1.0.0 features

**Developer Actions:**
1. Create release branch locally:
   ```bash
   git checkout main
   git pull
   git checkout -b release/v1.0.0
   git push --set-upstream origin release/v1.0.0
   ```

**GitHub Actions:**
1. Navigate to **Actions** tab
2. Select **"Create Branch Release"** workflow
3. **Important**: Use branch dropdown to select `release/v1.0.0`
4. Inputs:
   - **type**: `alpha`
5. Run workflow

**Expected Repository State After:**
- New branch: `release/v1.0.0`
- New tag: `v1.0.0-alpha.1` (increments from existing alpha.0)
- Release created from `release/v1.0.0` branch
- Main branch unaffected

**Verification:**
- Check `release/v1.0.0` branch exists in GitHub
- Check v1.0.0-alpha.1 tag exists
- Verify alpha.1 pre-release created from release branch
- Confirm main branch unchanged

---

### Step 11: Beta Release with Bug Fix

**Repository State Before:**
- `release/v1.0.0` branch with `v1.0.0-alpha.1`
- Bug discovered during testing

**Developer Actions:**
1. Switch to `release/v1.0.0` branch locally
2. Fix the bug in code
3. Update CHANGELOG.md [Unreleased] section with fix details in Fixed category
4. Commit and push to `release/v1.0.0` branch

**GitHub Actions:**
1. Select **"Create Branch Release"** workflow
2. Select `release/v1.0.0` branch
3. Inputs:
   - **type**: `beta`
4. Run workflow

**Expected Repository State After:**
- New tag: `v1.0.0-beta.0`
- Beta pre-release created from release branch
- `release/v1.0.0` branch contains the bug fix
- Main branch does not yet have the bug fix (remains diverged)

**Verification:**
- Check v1.0.0-beta.0 tag exists
- Verify beta.0 pre-release
- Confirm `release/v1.0.0` branch contains the bug fix
- Verify main branch does not have the bug fix (demonstrates isolation)

---

### Step 12: Release Candidate with Parallel Development

**Repository State Before:**
- `release/v1.0.0` branch with beta testing complete
- Ready for release candidate

**Developer Actions:**
1. Switch to main branch locally
2. Add new features for v1.1.0 (post-v1.0.0 features)
3. Update CHANGELOG.md [Unreleased] section with new v1.1.0 features
4. Commit and push to main

**GitHub Actions:**
1. Select **"Create Branch Release"** workflow
2. Select `release/v1.0.0` branch
3. Inputs:
   - **type**: `rc`
4. Run workflow

**Expected Repository State After:**
- New tag: `v1.0.0-rc.0`
- Release candidate created
- Main branch has new v1.1.0 features
- `release/v1.0.0` branch remains feature-frozen

**Verification:**
- Check v1.0.0-rc.0 tag exists
- Verify rc.0 pre-release
- Check main branch has new features not in release branch
- Verify `release/v1.0.0` branch unchanged
- Confirm parallel development working

---

### Step 13: Final Stable Release from Release Branch

**Repository State Before:**
- `release/v1.0.0` branch with `v1.0.0-rc.0`
- Release candidate testing complete

**Developer Actions:**
- No code changes required

**GitHub Actions:**
1. Select **"Create Branch Release"** workflow
2. Select `release/v1.0.0` branch
3. Inputs:
   - **type**: `stable`
4. Run workflow

**Expected Repository State After:**
- New tag: `v1.0.0` (stable)
- CHANGELOG.md on release branch updated with [1.0.0] section
- Stable release created
- Commit with changelog update on release branch

**Verification:**
- Check v1.0.0 stable tag exists
- Verify 1.0.0 stable release (not pre-release)
- Confirm CHANGELOG.md updated on release branch

---

### Step 14: Merge Release Branch Back to Main

**Repository State Before:**
- `release/v1.0.0` branch with stable v1.0.0 release
- Main branch has newer v1.1.0 features but no v1.0.0 changelog update

**Developer Actions:**
- No code changes required

**GitHub Actions:**
1. Create Pull Request from `release/v1.0.0` to `main`
2. Title: "Merge v1.0.0 release back to main"
3. **Important**: Resolve CHANGELOG.md merge conflicts carefully
   - Keep v1.1.0 features in [Unreleased]
   - Keep v1.0.0 section from release branch
   - Do not remove any entries, only resolve conflicts
4. Merge the PR (branch will be automatically deleted)

**Expected Repository State After:**
- Main branch has both v1.0.0 release history and v1.1.0 features
- CHANGELOG.md on main has [1.0.0] section and [Unreleased] with v1.1.0 features
- `release/v1.0.0` branch automatically deleted after merge

**Verification:**
- Check main branch CHANGELOG.md has both [1.0.0] and [Unreleased] sections
- Verify v1.1.0 features still in [Unreleased]
- Confirm v1.0.0 release history preserved
- Check `release/v1.0.0` branch no longer exists

---

## Phase 3: Hotfix Releases (Steps 15-19)

This phase demonstrates creating hotfix releases for older versions while main continues development.

### Step 15: First Hotfix Release

**Repository State Before:**
- Latest stable: `v1.0.0`
- Main branch continuing development toward v1.1.0
- Critical security vulnerability discovered in v1.0.0

**Developer Actions:**
1. Continue adding v1.1.0 features to main to create divergence
2. Update CHANGELOG.md [Unreleased] section with additional v1.1.0 features
3. Commit several changes to main to create clear divergence from v1.0.0
4. Create hotfix branch from v1.0.0 tag:
   ```bash
   git checkout -b hotfix/v1.0.0 v1.0.0
   git push --set-upstream origin hotfix/v1.0.0
   ```
5. Apply the security fix (minimal code changes)
6. Update CHANGELOG.md [Unreleased] section with security fix details
7. Commit and push to hotfix branch
8. Switch to `hotfix/v1.0.0` branch in GitHub UI

**GitHub Actions:**
1. Select **"Create Branch Release"** workflow
2. Select `hotfix/v1.0.0` branch
3. Inputs:
   - **type**: `stable`
4. Run workflow

**Expected Repository State After:**
- New branch: `hotfix/v1.0.0` (based exactly on v1.0.0 tag)
- New tag: `v1.0.1` (patch version from v1.0.0)
- CHANGELOG.md on hotfix branch updated with [1.0.1] section
- Hotfix release created
- Main branch significantly ahead of v1.0.0
- Main branch still has the security vulnerability

**Verification:**
- Check `hotfix/v1.0.0` branch exists and matches v1.0.0 exactly
- Check v1.0.1 tag exists
- Verify 1.0.1 stable release
- Confirm security fix in release notes
- Verify CHANGELOG.md updated on hotfix branch
- Check main branch has multiple commits since v1.0.0 tag
- Confirm branch does not have main's new features

---

### Step 16: Second Hotfix with Cherry-pick to Main

**Repository State Before:**
- `v1.0.1` hotfix released
- Main branch still has the security vulnerability
- Another critical bug discovered in v1.0.1

**Developer Actions:**
1. Create Pull Request from `hotfix/v1.0.0` to `main`
2. Title: "Cherry-pick security fix from v1.0.1 to main"
3. **Important**: Resolve CHANGELOG.md merge conflicts:
   - Keep all v1.1.0 features in [Unreleased]
   - Add security fix to [Unreleased] section
   - Keep [1.0.1] section from hotfix
4. Merge the PR (branch will be automatically deleted)
5. Create new hotfix branch from v1.0.1:
   ```bash
   git checkout -b hotfix/v1.0.1 v1.0.1
   git push --set-upstream origin hotfix/v1.0.1
   ```
6. Apply data corruption fix
7. Update CHANGELOG.md [Unreleased] section with fix details
8. Commit and push to hotfix branch
9. Switch to `hotfix/v1.0.1` branch in GitHub UI

**GitHub Actions:**
1. Select **"Create Branch Release"** workflow
2. Select `hotfix/v1.0.1` branch
3. Inputs:
   - **type**: `stable`
4. Run workflow

**Expected Repository State After:**
- Main branch has security fix and retains v1.1.0 features
- CHANGELOG.md on main shows fix in [Unreleased] and has [1.0.1] section
- `hotfix/v1.0.0` branch automatically deleted after merge
- New branch: `hotfix/v1.0.1`
- New tag: `v1.0.2`
- Second hotfix release created
- Chain of hotfix releases: v1.0.0 → v1.0.1 → v1.0.2

**Verification:**
- Check main branch has security fix
- Verify v1.1.0 features still present on main
- Confirm CHANGELOG.md properly merged
- Check `hotfix/v1.0.0` branch no longer exists
- Check v1.0.2 tag exists
- Verify 1.0.2 release
- Confirm progression from v1.0.1 to v1.0.2

---

### Step 17: Hotfix Pre-Release

**Repository State Before:**
- Complex hotfix needed for v1.0.2
- Hotfix requires testing before release

**Developer Actions:**
1. Create hotfix branch from v1.0.2:
   ```bash
   git checkout -b hotfix/v1.0.2 v1.0.2
   git push --set-upstream origin hotfix/v1.0.2
   ```
2. Apply complex fix requiring testing
3. Update CHANGELOG.md [Unreleased] section
4. Commit and push
5. Switch to `hotfix/v1.0.2` branch in GitHub UI

**GitHub Actions:**
1. Select **"Create Branch Release"** workflow
2. Select `hotfix/v1.0.2` branch
3. Inputs:
   - **type**: `rc`
4. Run workflow

**Expected Repository State After:**
- New branch: `hotfix/v1.0.2`
- New tag: `v1.0.3-rc.0`
- Hotfix release candidate created
- Allows testing before stable hotfix

**Verification:**
- Check `hotfix/v1.0.2` branch exists
- Check v1.0.3-rc.0 tag exists
- Verify 1.0.3-rc.0 pre-release

---

### Step 18: Stabilize Hotfix Pre-Release

**Repository State Before:**
- `v1.0.3-rc.0` tested and approved
- Ready for stable hotfix release

**Developer Actions:**
- Switch to `hotfix/v1.0.2` branch in GitHub UI

**GitHub Actions:**
1. Select **"Create Branch Release"** workflow
2. Select `hotfix/v1.0.2` branch
3. Inputs:
   - **type**: `stable`
4. Run workflow

**Expected Repository State After:**
- New tag: `v1.0.3` (stable)
- CHANGELOG.md updated with [1.0.3] section
- Stable hotfix release

**Verification:**
- Check v1.0.3 stable tag exists
- Verify 1.0.3 stable release
- Confirm stabilization from rc to stable

---

### Step 19: Final Merge of All Hotfixes to Main

**Repository State Before:**
- Multiple hotfix releases: v1.0.1, v1.0.2, v1.0.3
- Main branch missing some hotfixes
- `hotfix/v1.0.1` branch already merged and deleted
- `hotfix/v1.0.2` branch exists with all recent hotfixes

**Developer Actions:**
1. Create comprehensive PR from `hotfix/v1.0.2` to `main`
2. Title: "Merge remaining hotfixes v1.0.2 and v1.0.3 to main"
3. Resolve CHANGELOG.md conflicts to include all hotfix entries
4. Merge the PR (branch will be automatically deleted)

**GitHub Actions:**
- No workflow execution required

**Expected Repository State After:**
- Main branch has all hotfixes
- CHANGELOG.md has all hotfix sections: [1.0.3], [1.0.2], [1.0.1]
- Main ready for v1.1.0 development
- All hotfix branches automatically deleted after merges
- Complete release history: v1.0.0, v1.0.1, v1.0.2, v1.0.3

**Verification:**
- Check main has all hotfix changes
- Verify CHANGELOG.md has complete hotfix history
- Confirm [Unreleased] still has v1.1.0 features
- Check all hotfix branches no longer exist
- Verify complete tag history exists
- Confirm main branch clean and ready for continued development

---

## Workflow Input Coverage Matrix

### Create Stable Release Workflow

| Test Step | Branch | Level | Expected Outcome | Changelog Update |
|-----------|--------|-------|------------------|------------------|
| 6 | main | patch | v0.1.0 (stabilize from RC) | Yes |
| 7 | main | patch | v0.1.1 | Yes |
| 8 | main | minor | v0.2.0 | Yes |
| 13 | release/v1.0.0 | stable | v1.0.0 | Yes |
| 15 | hotfix/v1.0.0 | stable | v1.0.1 | Yes |
| 16 | hotfix/v1.0.1 | stable | v1.0.2 | Yes |
| 18 | hotfix/v1.0.2 | stable | v1.0.3 | Yes |

### Create Pre-Release Workflow

| Test Step | Branch | Action | Type | Level | Expected Outcome |
|-----------|--------|--------|------|-------|------------------|
| 1 | main | new | alpha | minor | v0.1.0-alpha.0 |
| 2 | main | continue | alpha | - | v0.1.0-alpha.1 |
| 3 | main | transition | beta | - | v0.1.0-beta.0 |
| 4 | main | continue | beta | - | v0.1.0-beta.1 |
| 5 | main | transition | rc | - | v0.1.0-rc.0 |
| 9 | main | new | alpha | major | v1.0.0-alpha.0 |

### Create Branch Release Workflow

| Test Step | Branch Type | Branch Name | Type | Expected Outcome |
|-----------|-------------|-------------|------|------------------|
| 10 | release | release/v1.0.0 | alpha | v1.0.0-alpha.1 |
| 11 | release | release/v1.0.0 | beta | v1.0.0-beta.0 |
| 12 | release | release/v1.0.0 | rc | v1.0.0-rc.0 |
| 13 | release | release/v1.0.0 | stable | v1.0.0 |
| 15 | hotfix | hotfix/v1.0.0 | stable | v1.0.1 |
| 16 | hotfix | hotfix/v1.0.1 | stable | v1.0.2 |
| 17 | hotfix | hotfix/v1.0.2 | rc | v1.0.3-rc.0 |
| 18 | hotfix | hotfix/v1.0.2 | stable | v1.0.3 |

## Error Scenarios Testing

### Expected Failures

These scenarios should be tested to ensure proper error handling:

1. **Wrong Branch for Workflow**:
   - Try running "Create Stable Release" from a feature branch → Should fail
   - Try running "Create Pre-Release" from a release branch → Should fail

2. **Invalid Pre-Release Actions**:
   - Try `action=continue` with no existing pre-release → Should fail
   - Try `action=transition` with no existing pre-release → Should fail
   - Try `action=new` when pre-release already exists → Should fail

3. **Invalid Branch Names**:
   - Try "Create Branch Release" from `feature/new-auth` → Should fail
   - Try with branch name not matching `release/*` or `hotfix/*` → Should fail

## Verification Procedures

### After Each Step

1. **Check Tags**: Verify new tag created with correct version
2. **Check Releases**: Verify GitHub release created with correct type (stable/pre-release)
3. **Check Changelog**: Verify CHANGELOG.md updated correctly (stable releases only)
4. **Check Commits**: Verify changelog commits pushed to correct branch (stable releases only)
5. **Check Workflow Logs**: Review GitHub Actions logs for any errors or warnings

### Repository State Verification Commands

```bash
# List all tags
git tag --list

# Check current branch
git branch --show-current

# Check changelog
cat CHANGELOG.md

# Check recent commits
git log --oneline -10

# Check all branches
git branch -a
```

### GitHub UI Verification

- **Tags**: Repository → Tags section
- **Releases**: Repository → Releases section
- **Branches**: Repository → Branches (for release/hotfix branches)
- **Actions**: Repository → Actions (for workflow run logs)

## Completion Criteria

Testing is considered complete when:

- ✅ All 19 steps executed successfully in sequence
- ✅ All three workflow types used with various input combinations
- ✅ All three release paths demonstrated (standard, stabilization, hotfix)
- ✅ Changelog contract followed throughout all steps
- ✅ Error scenarios tested and handled properly
- ✅ Repository state consistent and clean after each phase
- ✅ Version numbering follows semantic versioning correctly
- ✅ All verification procedures pass

### Success Metrics

- **Version Progression**: Logical sequence from 0.1.0-alpha.0 through 1.0.3
- **Branch Management**: Proper creation and automatic cleanup of release/hotfix branches
- **Changelog Integrity**: Accurate CHANGELOG.md maintenance throughout
- **Parallel Development**: Successful demonstration of main/release branch separation
- **Hotfix Integration**: Proper merge of hotfixes back to main
- **Workflow Reliability**: All workflows complete without unexpected failures

---

This sequential testing guide ensures comprehensive coverage of all release scenarios while following the natural progression of software development from initial releases through production hotfixes.
