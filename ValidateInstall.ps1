sl C:\OpenRailData\

# Restore the nuget references
& "C:\Program Files\dotnet\dotnet.exe" restore

# Run the unit tests
& "C:\Program Files\dotnet\dotnet.exe" test .\OpenRailData.UnitTests\

# Run the integration tests
& "C:\Program Files\dotnet\dotnet.exe" test .\OpenRailData.IntegrationTests\

exit $LastExitCode