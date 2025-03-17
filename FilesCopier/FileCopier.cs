namespace FilesCopier
{
    public class FileCopier
    {
        public static void CopyFilesToTargetSize(string sourceFile, long targetSize, string outputDir, string outputFileExtension)
        {
            // Creating directory if it is not there
            Directory.CreateDirectory(outputDir);

            FileInfo sourceFileInfo = new(sourceFile);
            long sourceFileSize = sourceFileInfo.Length;

            // Source file size must not larger than the target size
            if (sourceFileSize > targetSize)
            {
                Console.WriteLine("Source file is larger than the target size.");
                return;
            }

            int outputFileCounter = 1;
            long totalSize = sourceFileSize;

            // Repeat the process of copying the file until total size reaches the target size
            while (totalSize < targetSize)
            {
                string outputFilePath = Path.Combine(outputDir, $"F{outputFileCounter}${outputFileExtension}");

                // Copy the source file to the new output file
                File.Copy(sourceFile, outputFilePath);

                totalSize += sourceFileSize; // Update the total size

                outputFileCounter++; // Increment the counter for the next file
            }

            Console.WriteLine($"File splitting completed. Total files created: {outputFileCounter - 1}");
        }
    }
}