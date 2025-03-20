using FilesCopier;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        // Sample file name
        string sampleFileName = "sample1";

        // Define the output file extension
        string fileExtension = ".dng";

        // List of source files to be copied
        string sourceFilesDir = "D:\\CopyFilesPOC\\PIDs";

        // Define the target size for each output file (in bytes)
        long targetSize = 500 * 1024 * 1024; // 500 MB target size

        // Define the directory where output files will be saved
        string outputDir = "D:\\CopyFilesPOC\\PIDs";

        // Total files count for output
        int totalFileCount = 50;

        // Call the method to copy files to the target size
        FileCopier.CopyFilesToTargetSize(sourceFilesDir, targetSize, outputDir, totalFileCount);
    }
}