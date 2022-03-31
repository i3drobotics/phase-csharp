# Maintainer
A maintainer is a person who is responsible for maintaining the code repository.
## Approve pull request
1. Find an open [GitHub pull request](https://github.com/i3drobotics/phase-sharp/pulls).
2. Check automatic tests have passed.
3. Manually review code changes.
4. Merge pull request.
5. Code will be full tested on all deployment platforms using docker and latest development docker images will be updated.
## Deploy release
GitHub workflow is provided to trigger releases on manual request using [workflow_dispatch](https://docs.github.com/en/actions/managing-workflow-runs/manually-running-a-workflow).
1. Go to [actions](https://github.com/i3drobotics/phase-sharp/actions) tab of this repository.
2. Select the 'release' workflow and click 'Run workflow'. You will need to pick the release type (major, minor or patch).
3. Code will be deployed. On succesfull deployment, 'main' is merged to 'prod'. Deployment creates a GitHub Release which includes libraries and samples for supported languages / OS's as well as python wheels for different versions. The python wheels are also published to pip. The message used for the release will be taken from the 'release.md' file in the root of the repository.