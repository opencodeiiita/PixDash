# Contributing to PixDash

Thanks for wanting to contribute! This document explains how to set up the project locally and how to submit the required verification for onboarding issues.

## Required Unity Version
- Unity Hub
- Unity Editor: **6.3 LTS (6000.3.2f1)**

Using a different Unity version may cause project errors. Install the correct version via Unity Hub before opening the project.

## Quick Setup
1. Fork this repository and clone your fork:

   git clone https://github.com/<your-username>/PixDash.git

2. Open Unity Hub → `Projects` → `Add` → select the cloned `PixDash` folder.
3. Do not create a new project — open the repository as-is.

## Onboarding Issue (Unity Setup)
For the onboarding issue (see Issue #27), we require a screenshot proving you opened the project in Unity Hub with the correct Unity version visible.

Steps to submit proof:
1. In Unity Hub, open `Projects` and ensure `PixDash` appears with `Unity 6.3 LTS (6000.3.2f1)`.
2. Take a screenshot that clearly shows the project name and Unity version.
3. Add the screenshot link or short description to a text file in the `contributors/` folder named exactly with your roll number (for example `24CS0160.txt`). If you don't already have a file in `contributors/`, create one using your roll number as filename.
4. Commit only your text file (do not commit Unity generated files) and open a Pull Request with the screenshot included in the PR description.

Example content for `contributors/<your_roll_number>.txt`:

```
Name: Your Name
Roll: 24CS0160
Unity: Unity 6.3 LTS (6000.3.2f1)
Proof: https://imgur.com/your-upload or GitHub PR screenshot
```

## PR Checklist
- [ ] Claim the issue in the repository before starting work
- [ ] Add only the intended `contributors/<roll>.txt` file for onboarding
- [ ] Include the Unity Hub screenshot in the PR description
- [ ] Keep changes focused to the issue scope

If you need help, open a thread on the project's Discord or create an issue asking for guidance.

Thank you — we look forward to your contributions!
