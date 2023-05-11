$connectionString = "Server=tcp:kioskjo.database.windows.net;Database=kioskjodb;User ID=kioskjo;Password=sMJJeL8GJ5vNHYY;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
$envVariableName = "MY_CONNECTION_STRING"

# Create a new environment variable or update the existing one
$existingValue = [Environment]::GetEnvironmentVariable($envVariableName, "Machine")
if ($existingValue -eq $null -or $existingValue -eq "") {
    [Environment]::SetEnvironmentVariable($envVariableName, $connectionString, "Machine")
    Write-Host "Environment variable '$envVariableName' has been created."
} else {
    [Environment]::SetEnvironmentVariable($envVariableName, $connectionString, "Machine")
    Write-Host "Environment variable '$envVariableName' has been updated."
}

# Notify the user about the completion
Write-Host "Please restart your application for the changes to take effect."

# Pause the script execution
Read-Host "Press Enter to exit."