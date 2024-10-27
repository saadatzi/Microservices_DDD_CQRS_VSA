dotnet new sln -o NewSolution
dotnet new webapi -o ProjectName
dotnet new classlib -o ProjectContract/Domain/Infrastructure
dotnet sln add (ls -r **/*.csproj)
dotnet build
dotnet add ProjectName reference ProjectName2 ProjectName3

docker build -t todo-api-image .
docker run -d --name todo-api-container -p 5000:8080 todo-api-image


cat Directory.Build.props
cat .editorconfig