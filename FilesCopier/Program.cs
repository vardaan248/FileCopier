using FilesCopier;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");


        // List of source files to be copied
        string sourceFile = "D:\\DriveboxPOC\\MainFolder3\\F1.txt";

        // Define the target size for each output file (in bytes)
        long targetSize = 5 * 1024; // 5 KB target size

        // Define the directory where output files will be saved
        string outputDir = "D:\\DriveboxPOC\\MainFolder3\\OutputFiles";

        // Define the output file extension
        string outputFileExtension = ".txt";

        // Call the method to copy files to the target size
        FileCopier.CopyFilesToTargetSize(sourceFile, targetSize, outputDir, outputFileExtension);
    }
}