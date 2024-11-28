# This will use the SDK image to build the project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app 

# This will copy the csproj file to the container
COPY src/ .

# This will change the directory to the API project
WORKDIR /app/CashFlow.API 

#This will restore the dependencies
RUN dotnet restore

#This will create the out folder with the compiled code
RUN dotnet publish -c Release -o /app/out 

# This will use the ASP.NET image to run the project
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app 

# This will copy the compiled code to the container
COPY --from=build-env /app/out . // This will copy the compiled code to the container

# This will run the API project
ENTRYPOINT ["dotnet", "Onboarding.API.dll"]