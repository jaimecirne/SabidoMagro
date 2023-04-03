$file_path = "ClientRepository.cs"
$list_item = "Activity", "Avaliation", "ClientWorkout", "Contract", "DayOfTrain", "Manager", "Resource", "Role"
$posfix = "Repository"

$file_extension = [System.IO.Path]::GetExtension($file_path)

foreach ($item in $list_item)
{
    $new_file_name = "$item$posfix$file_extension"
    Copy-Item -Path $file_path -Destination $new_file_name
}
pause