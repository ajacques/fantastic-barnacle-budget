$RootPath = (Get-Item -Path ".\" -Verbose).FullName

Invoke-Expression "docker run --rm -ti -w /sln -v '${RootPath}:/sln' -t microsoft/aspnetcore-build:1.1.0-projectjson /bin/sh build.sh"

Invoke-Expression "docker build --network=none -t barnacle-budget publish/web"