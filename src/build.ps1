dotnet restore Readify.KnockKnock.sln
dotnet publish Readify.KnockKnock.sln -c Release -o obj/Docker/publish
cd Readify.KnockKnock.Endpoint
docker build -t readify.knockknock:1.1.3 -t readify.knockknock:latest .
docker tag readify.knockknock:latest 413523207417.dkr.ecr.us-west-2.amazonaws.com/readify.knockknock:latest
docker tag readify.knockknock:latest 413523207417.dkr.ecr.us-west-2.amazonaws.com/readify.knockknock:1.1.3
Invoke-Expression -Command (aws ecr get-login --no-include-email --region us-west-2)
docker push 413523207417.dkr.ecr.us-west-2.amazonaws.com/readify.knockknock:1.1.3
docker push 413523207417.dkr.ecr.us-west-2.amazonaws.com/readify.knockknock:latest