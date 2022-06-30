using System;
using System.IO;
using Aspose.Words;
using Aspose.Words.Replacing;

namespace ConsolePOCforWordDocumentManipulation
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ActivateAsposeLicense();
            CreateWordFile();
        }

        private static void CreateWordFile()
        {
            Console.WriteLine("Generate Document");
            do
            {
                string templateFile = "TemplateWithNoCustomFields.docx";
                string assemblyFolder = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                //string templatePath = @"D:\\Old-Attachment.doc";
                string templatePath = Path.Combine(assemblyFolder, templateFile);
                Document docA = new Document(templatePath);

                string todaysDate = DateTime.Now.ToString("MM/dd/yyyy");
                Console.WriteLine($"Today's date is: {todaysDate}");

                Console.Write("\nEnter ContractId: ");
                string contractId = Console.ReadLine();

                Console.Write("\nEnter Name of Contract: ");
                string contractName = Console.ReadLine();

                Console.Write("\nEnter FolderName: ");
                string folderName = Console.ReadLine();

                Console.Write("\nEnter Stage: ");
                string stage = Console.ReadLine();

                Console.Write("\nEnter Term type: ");
                string termType = Console.ReadLine();

                Console.Write("\nEnter Terms Start date: ");
                string termStartDate = Console.ReadLine();

                Console.Write("\nEnter Term End date: ");
                string termEndDate = Console.ReadLine();


                docA.Range.Replace("{ContractID}", contractId, new FindReplaceOptions());
                docA.Range.Replace("{Name}", contractName, new FindReplaceOptions());
                docA.Range.Replace("{FolderName}", folderName, new FindReplaceOptions());
                docA.Range.Replace("{Stage}", stage, new FindReplaceOptions());

                docA.Range.Replace("{Terms_StartDate}", termStartDate, new FindReplaceOptions());
                docA.Range.Replace("{Terms_EndDate}", termEndDate, new FindReplaceOptions());
                docA.Range.Replace("{Term_Type}", termType, new FindReplaceOptions());
                docA.Range.Replace("{TodaysDate}", todaysDate, new FindReplaceOptions());

                Console.WriteLine("\r\n\r\nGenerating New Document from template...");
                FileInfo file = new FileInfo(templatePath);
                string orgFilename = Path.GetFileNameWithoutExtension(templatePath);
                string newFilename = $"{orgFilename}_{DateTime.Now:yyyy-MM-dd hhmmsstt}{file.Extension}";
                string newFilePath = Path.Combine(assemblyFolder, newFilename);
                docA.Save(newFilePath);
                //docA.Save($"D:\\{orgFilename}-{DateTime.Now:dd-MM-yyyy hh-mm-ss}.{file.Extension}");
                Console.WriteLine($"New Document generated, filename = {newFilename}");

                Console.Write("\r\n\r\nPress ENTER to create new document OR type EXIT to terminate the process. Choice ? ");
            } while (Console.ReadLine().ToLower() != "exit");
        }

        private static void ActivateAsposeLicense()
        {
            // For complete examples and data files, please go to https://github.com/aspose-words/Aspose.Words-for-.NET
            License license = new License();

            // This line attempts to set a license from several locations relative to the executable and Aspose.Words.dll.
            // You can also use the additional overload to load a license from a stream, this is useful for instance when the 
            // license is stored as an embedded resource
            try
            {
                license.SetLicense("Aspose.Words.lic");
                Console.WriteLine("License set successfully.");
            }
            catch (Exception e)
            {
                // We do not ship any license with this example, visit the Aspose site to obtain either a temporary or permanent license. 
                Console.WriteLine("\nThere was an error setting the license: " + e.Message);
            }
        }
    }
}