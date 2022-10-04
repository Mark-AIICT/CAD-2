Add-Type -AssemblyName System.IO.Compression.FileSystem
function Unzip
{
    param([string]$zipfile, [string]$outpath)

        [System.IO.Compression.ZipFile]::ExtractToDirectory($zipfile, $outpath)
}

Unzip "C:\Users\Admin\Desktop\MarksFiles\MarksCode\DatabaseFiles\adventureworks.zip" "C:\Adworks"

# Connection string will be "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Adworks\AdventureWorks_Data.mdf;Integrated Security=True"
