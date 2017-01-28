$RootPath = (Get-Item -Path ".\" -Verbose).FullName
$RootPath

$cmd = "docker run --rm -ti -w /sln -v '${RootPath}:/sln' -t microsoft/aspnetcore-build:1.1.0-projectjson /bin/sh build.sh"

echo $cmd
Invoke-Expression $cmd

Invoke-Expression "docker build --network=none -t barnacle-budget publish/web"