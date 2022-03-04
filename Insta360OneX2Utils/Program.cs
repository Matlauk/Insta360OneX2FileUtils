
var folderPath = Directory.GetCurrentDirectory();
var cameraFolderPaths = Directory.EnumerateDirectories(folderPath);

var idxFile = 0;

Console.WriteLine("Working...");

foreach (var cameraFolderPath in cameraFolderPaths)
{
    if (Path.GetDirectoryName(cameraFolderPath)?.StartsWith("Camera") ?? false)
    {
        continue;
    }
    
    var fileGroups = Directory.EnumerateFiles(cameraFolderPath).GroupBy(Path.GetFileNameWithoutExtension).OrderBy(g => g.Key);
    
    foreach (var fileGroup in fileGroups)
    {
        foreach (var filePath in fileGroup)
        {
            var ext = Path.GetExtension(filePath);
            var newFilename = $"{idxFile}{ext}";
            var newFilePath = Path.Combine(folderPath, newFilename);
            File.Move(filePath, newFilePath);
        }

        idxFile++;
    }
}

Console.WriteLine("Complete!");