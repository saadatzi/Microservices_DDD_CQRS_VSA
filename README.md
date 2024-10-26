dotnet new sln -o NewSolution
dotnet new webapi -o ProjectName
dotnet new classlib -o ProjectContract/Domain/Infrastructure
dotnet sln add (ls -r **/*.csproj)
dotnet build
dotnet add ProjectName reference ProjectName2 ProjectName3
