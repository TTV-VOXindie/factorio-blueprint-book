# Set the base image as the .NET 7.0 SDK (this includes the runtime)
FROM mcr.microsoft.com/dotnet/sdk:7.0 as build-env

# Copy everything and publish the release (publish implicitly restores and builds)
COPY . ./SolutionItems
RUN dotnet publish ./SolutionItems/BlueprintStringToJsonGitHubAction/BlueprintStringToJsonGitHubAction.csproj -c Release -o out --no-self-contained

# Label the container
LABEL maintainer="TTV VOXindie <twitch.tv/VOXindie>"
LABEL repository="https://github.com/TTV-VOXindie/factorio-blueprint-book"
LABEL homepage="https://github.com/TTV-VOXindie/factorio-blueprint-book"

# Label as GitHub action
LABEL com.github.actions.name="Convert Blueprint String to JSON"
LABEL com.github.actions.description="A Github action that converts the blueprint string to JSON."
LABEL com.github.actions.icon="code"
LABEL com.github.actions.color="blue"

RUN ls

# Relayer the .NET SDK, anew with the build output
FROM mcr.microsoft.com/dotnet/sdk:7.0
COPY --from=build-env /out .
ENTRYPOINT [ "dotnet", "/BlueprintStringToJsonGitHubAction.dll" ]