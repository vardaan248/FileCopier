namespace FilesCopier
{
    public class FileCopier
    {
        public static void CopyFilesToTargetSize(string sourceDir, long targetSize, string outputDir, int totalFilesCount)
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Get all the files in the source directory
            string[] sourceFiles = Directory.GetFiles(sourceDir);

            // Ensure there are source files in the folder
            if (sourceFiles.Length == 0)
            {
                Console.WriteLine("Source folder is empty.");
                return;
            }

            // Calculate the current number of files in the output directory
            int currentFileCount = Directory.GetFiles(outputDir).Length;

            // If the number of required files is less than the existing files, exit
            if (totalFilesCount <= currentFileCount)
            {
                Console.WriteLine("The folder already has the required number of files.");
                return;
            }

            // Calculate how many files need to be created
            int filesToCreate = totalFilesCount - currentFileCount;

            // Calculate the total size of the source files
            long totalSourceSize = 0;
            List<FileInfo> fileInfos = new List<FileInfo>();
            foreach (var filePath in sourceFiles)
            {
                FileInfo fileInfo = new FileInfo(filePath);
                fileInfos.Add(fileInfo);
                totalSourceSize += fileInfo.Length;
            }

            // Calculate the remaining size to achieve the target size
            long remainingSize = targetSize;

            // Calculate how many full cycles of source files will be needed to achieve the target size
            int cyclesRequired = (int)(remainingSize / totalSourceSize);
            long totalSizeCreated = cyclesRequired * totalSourceSize;
            int outputFileCounter = currentFileCount + 1;

            // Create files until we reach the required number of files
            while (filesToCreate > 0)
            {
                for (int i = 0; i < fileInfos.Count && filesToCreate > 0; i++)
                {
                    FileInfo fileInfo = fileInfos[i];
                    string outputFilePath = Path.Combine(outputDir, $"F{outputFileCounter}.pid");

                    // Copy the file into the output directory
                    File.Copy(fileInfo.FullName, outputFilePath);
                    totalSizeCreated += fileInfo.Length;

                    outputFileCounter++; // Increment the counter for the next file
                    filesToCreate--; // Decrement the number of remaining files to create
                }
            }

            // Output the final status
            Console.WriteLine($"File splitting completed. Total files created: {totalFilesCount}");
            Console.WriteLine($"Total size created: {totalSizeCreated} bytes, {(totalSizeCreated / 1024) / 1024} MB.");

            long totalSizeOutputFolder = 0;
            foreach (var file in Directory.GetFiles(outputDir))
            {
                totalSizeOutputFolder += new FileInfo(file).Length;
            }

            Console.WriteLine($"Total size of output folder: {(totalSizeOutputFolder / 1024) / 1024} MB");
        }
    }
}


//Console.WriteLine($"File splitting completed. Total files created: {totalFilesCount}");
//Console.WriteLine($"Total size created: {totalSizeCreated} bytes, {(totalSizeCreated / 1024) / 1024} MB.");

//long totalSizeOutputFolder = 0;
//foreach (var file in Directory.GetFiles(outputDir))
//{
//    totalSizeOutputFolder += new FileInfo(file).Length;
//}

//Console.WriteLine($"Total size of output folder: {(totalSizeOutputFolder / 1024) / 1024} MB");