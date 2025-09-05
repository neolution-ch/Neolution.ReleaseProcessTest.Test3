# Release Process Testing Scenarios

This document provides a chronological set of release scenarios to test the implementation of the `release-process.md` document. Each step should be performed in order to simulate a complex, real-world release history.

The "Process to Use" column refers to the paths defined in `release-process.md`.

Step | Version Number | Process to Use | Source Branch  | Key Actions / Notes
-----|----------------|----------------|----------------|----------------------
1    | v0.1.0-alpha.0 | Standard       | main           | Initial release of a new feature.
2    | v0.1.0-alpha.1 | Standard       | main           | Bug fixes for the alpha.
3    | v0.1.0-beta.0  | Standard       | main           | Feature is now considered complete, entering beta.
4    | v0.1.0-rc.0    | Standard       | main           | Beta is stable, creating release candidate.
5    | v0.1.0         | Standard       | main           | First stable release.
6    | v0.2.0-alpha.0 | Standard       | main           | Start of the next feature release.
7    | v0.2.0-alpha.1 | Standard       | main           |
8    | v0.2.0-beta.0  | Standard       | main           |
9    | v0.2.0         | Standard       | main           | Second stable release.
10   | v0.2.1-beta.0  | Standard       | main           | A patch is being prepared and tested.
11   | v0.2.1         | Standard       | main           | Stable patch release.
12   | v1.0.0-alpha.0 | Standard       | main           | main now contains breaking changes for v1.
13   | v0.2.2-alpha.0 | Hotfix         | hotfix/v0.2.2  | Action: Create hotfix/v0.2.2 from v0.2.1 tag.
14   | v1.0.0-alpha.1 | Standard       | main           |
15   | v0.2.2-beta.0  | Hotfix         | hotfix/v0.2.2  |
16   | v1.0.0-alpha.2 | Standard       | main           |
17   | v0.2.2         | Hotfix         | hotfix/v0.2.2  | Action: Merge hotfix/v0.2.2 into main and delete.
18   | v1.0.0-alpha.3 | Standard       | main           |
19   | v0.3.0-alpha.0 | Hotfix         | hotfix/v0.3.0  | Action: Create hotfix/v0.3.0 from v0.2.2 tag.
20   | v0.3.0-beta.0  | Hotfix         | hotfix/v0.3.0  |
21   | v1.0.0-beta.0  | Stabilization  | release/v1.0.0 | Reason: main already contains v1.1.0 work. Action: Create release/v1.0.0 from main.
22   | v1.1.0-alpha.0 | Standard       | main           | main is now working on v1.1 features.
23   | v1.0.0-beta.1  | Stabilization  | release/v1.0.0 | Fix a bug on release/v1.0.0 and merge back to main.
24   | v0.3.0         | Hotfix         | hotfix/v0.3.0  | Action: Merge hotfix/v0.3.0 into main and delete.
25   | v1.0.0         | Stabilization  | release/v1.0.0 | Action: Final stable release. Merge and delete release/v1.0.0.
26   | v1.1.0-alpha.1 | Standard       | main           |
27   | v0.3.1-beta.0  | Hotfix         | hotfix/v0.3.1  | Action: Create hotfix/v0.3.1 from v0.3.0 tag.
28   | v0.2.3-beta.0  | Hotfix         | hotfix/v0.2.3  | Action: Create hotfix/v0.2.3 from v0.2.2 tag.
29   | v0.3.1         | Hotfix         | hotfix/v0.3.1  | Action: Merge hotfix/v0.3.1 into main and delete.
30   | v0.2.3         | Hotfix         | hotfix/v0.2.3  | Action: Merge hotfix/v0.2.3 into main and delete.
31   | v1.1.0-beta.0  | Standard       | main           |
32   | v0.3.2-beta.0  | Hotfix         | hotfix/v0.3.2  | Action: Create hotfix/v0.3.2 from v0.3.1 tag.
33   | v0.2.4-beta.0  | Hotfix         | hotfix/v0.2.4  | Action: Create hotfix/v0.2.4 from v0.2.3 tag.
34   | v1.1.0         | Standard       | main           |
35   | v0.3.2         | Hotfix         | hotfix/v0.3.2  | Action: Merge hotfix/v0.3.2 into main and delete.
36   | v0.2.4         | Hotfix         | hotfix/v0.2.4  | Action: Merge hotfix/v0.2.4 into main and delete.