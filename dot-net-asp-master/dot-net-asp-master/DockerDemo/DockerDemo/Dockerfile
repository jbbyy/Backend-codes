#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443

#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
#COPY ["DockerDemo/DockerDemo.csproj", "DockerDemo/"]
#RUN dotnet restore "DockerDemo/DockerDemo.csproj"
#COPY . .
#WORKDIR "/src/DockerDemo"
#RUN dotnet build "DockerDemo.csproj" -c Release -o /app/build

#FROM build AS publish
#RUN dotnet publish "DockerDemo.csproj" -c Release -o /app/publish /p:UseAppHost=false

#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "DockerDemo.dll"]

FROM mcr.microsoft.com/dotnet/sdk:6.0 as buildStage 
#from docker image, SDK is to compile
WORKDIR /app 
#from where it will deploy all your app
COPY *.csproj ./ 
#at the same place where docker file is at . cs.proj contains all the dependencies of the project 
RUN dotnet restore 
COPY . ./  
#copy all the files from current location
RUN dotnet publish -c Release -o out 
#publish will build project and want the released version of this app at the out folder at container in docker. 
#out = Name of folder that generates output files. 

FROM mcr.microsoft.com/dotnet/aspnet:6.0 
#asp is to run 
WORKDIR /deploy
COPY --from=buildStage /app/out . 
#buildstage is any name. copy from current location which is represented by .
ENTRYPOINT ["dotnet", "DockerDemo.dll"] 
#insert name of app from vs 

