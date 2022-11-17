REPOSITORIES=(PackIt)

for REPOSITORY in ${REPOSITORIES[*]}
do
	 echo ========================================================
	 echo Cloning the repository: $REPOSITORY
	 echo ========================================================
	 REPO_URL=https://github.com/AnastasKosstow/$REPOSITORY.git
	 git clone $REPO_URL
done