param (
    [string[]]$modelNames
)

foreach ($modelName in $modelNames) {
    Write-Host "Generating controller for model: $modelName"
    dotnet-aspnet-codegenerator controller --controllerName "${modelName}Controller" --controllerNamespace TiendaAPI.Controllers --relativeFolderPath Controllers --model $modelName --dataContext TiendaAPI.Data.TiendaContext -api -async
}

Write-Host "Controller generation completed."
