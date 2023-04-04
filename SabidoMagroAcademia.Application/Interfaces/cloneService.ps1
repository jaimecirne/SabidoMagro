$file_path = "IClientService.cs"
$list_item = "Activity", "Avaliation", "ClientWorkout", "Contract", "DayOfTrain", "Manager", "Resource", "Role"
$posfix = "Service"
$prefix = "I"


$file_extension = [System.IO.Path]::GetExtension($file_path)

foreach ($item in $list_item)
{
    $new_file_name = "$prefix$item$posfix$file_extension"
    Copy-Item -Path $file_path -Destination $new_file_name

    (Get-Content $new_file_name) | ForEach-Object {$_ -creplace 'Client',$item } | Set-Content $new_file_name

    (Get-Content $new_file_name) | ForEach-Object {$_ -creplace 'client',$item.ToLower() } | Set-Content $new_file_name


}
pause