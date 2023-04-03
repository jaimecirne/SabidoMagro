$file_path = "Clients"
$list_item = "Activity", "Avaliation", "ClientWorkout", "Contract", "DayOfTrain", "Manager", "Resource", "Role"
$commandpath = "\Commands\"
$querypath = "\Queries\"
$handlerpath = "\Handlers\"


$file_extension = [System.IO.Path]::GetExtension($file_path)

foreach ($item in $list_item)
{
    Copy-Item -Recurse -Path $file_path -Destination $item
    
    foreach ($file in Get-ChildItem "$item$commandpath")
    {
        (Get-Content "$item$commandpath$file") | ForEach-Object {$_ -creplace 'Client',$item } | Set-Content "$item$commandpath$file"

        (Get-Content "$item$commandpath$file") | ForEach-Object {$_ -creplace 'client',$item.ToLower() } | Set-Content "$item$commandpath$file"
        
        Rename-Item -Path "$item$commandpath$file" -NewName ((Get-Item "$item$commandpath$file").Name -replace "Client", $item)

    }

    foreach ($file in Get-ChildItem "$item$querypath")
    {
        (Get-Content "$item$querypath$file") | ForEach-Object {$_ -creplace 'Client',$item } | Set-Content "$item$querypath$file"

        (Get-Content "$item$querypath$file") | ForEach-Object {$_ -creplace 'client',$item.ToLower() } | Set-Content "$item$querypath$file"
        
        Rename-Item -Path "$item$querypath$file" -NewName ((Get-Item "$item$querypath$file").Name -replace "Client", $item)

    }


    foreach ($file in Get-ChildItem "$item$handlerpath")
    {
        (Get-Content "$item$handlerpath$file") | ForEach-Object {$_ -creplace 'Client',$item } | Set-Content "$item$handlerpath$file"

        (Get-Content "$item$handlerpath$file") | ForEach-Object {$_ -creplace 'client',$item.ToLower() } | Set-Content "$item$handlerpath$file"
        
        Rename-Item -Path "$item$handlerpath$file" -NewName ((Get-Item "$item$handlerpath$file").Name -replace "Client", $item)

    }

}
pause