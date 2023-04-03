$file_path = "ProductsController.cs"
$list_item = "Activity", "Avaliation", "ClientWorkout", "Contract", "DayOfTrain", "Manager", "Resource", "Role", "Client", "Plan"


foreach ($item in $list_item)
{

    $new_file_name = ((Get-Item "$file_path").Name -replace "Product", $item)

    Copy-Item -Path $file_path -Destination $new_file_name

    (Get-Content $new_file_name) | ForEach-Object {$_ -creplace 'Product',$item } | Set-Content $new_file_name

    (Get-Content $new_file_name) | ForEach-Object {$_ -creplace 'product',$item.ToLower() } | Set-Content $new_file_name

    (Get-Content $new_file_name) | ForEach-Object {$_ -creplace 'produto',$item.ToLower() } | Set-Content $new_file_name

    (Get-Content $new_file_name) | ForEach-Object {$_ -creplace 'Client',$item } | Set-Content $new_file_name

    (Get-Content $new_file_name) | ForEach-Object {$_ -creplace 'client',$item.ToLower() } | Set-Content $new_file_name


}
pause