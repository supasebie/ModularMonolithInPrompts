#1 Stage: Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
#restore
COPY ["./src/InPrompts.Users/InPrompts.Users.csproj", "InPrompts.Users/InPrompts.Users.csproj"]
COPY ["./src/InPrompts.Web/InPrompts.Web.csproj", "InPrompts.Web/InPrompts.Web.csproj"] 
COPY ["./src/InPrompts.Prompts/InPrompts.Prompts.csproj", "InPrompts.Prompts/InPrompts.Prompts.csproj"] 
COPY ["./src/InPrompts.Prompts.Contracts/InPrompts.Prompts.Contracts.csproj", "InPrompts.Prompts.Contracts/InPrompts.Prompts.Contracts.csproj"] 
COPY ["./src/InPrompts.SharedKernel/InPrompts.SharedKernel.csproj", "InPrompts.SharedKernel/InPrompts.SharedKernel.csproj"] 
COPY ["Directory.Build.props", "Directory.Build.props/"]
COPY ["Directory.Build.props", "./src/Directory.Build.props/"]
COPY ["InPrompts.sln", "InPrompts.sln"]

WORKDIR /.
RUN dotnet restore  

#build
RUN dotnet build 'InPrompts.Web.csproj' -c Release -o /app/build

#Stage 2: Publish
FROM build as publish
RUN dotnet publish 'InPrompts.Web.csproj' -c Release -o /app/publish

#Stage 3: Run
FROM mcr.microsoft.com/dotnet/aspnet:8.0
ENV ASPNETCORE_HTTP_PORTS=7001
EXPOSE 7001
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "InPrompts.Web.dll" ]