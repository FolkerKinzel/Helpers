using System.Globalization;
using System.IO;
using System.Text;

namespace FolkerKinzel.Helpers.Tests;

internal static class TestFiles
{
    private const string TEST_FILE_DIRECTORY_NAME = "TestFiles";
    private static readonly string _testFileDirectory;

    static TestFiles()
    {
        ProjectDirectory = Encoding.UTF8.GetString(Resources.Res.ProjDir).Trim();
        _testFileDirectory = Path.Combine(ProjectDirectory, TEST_FILE_DIRECTORY_NAME);
    }

    internal static string[] GetAll() => Directory.GetFiles(_testFileDirectory);

    internal static string ProjectDirectory { get; }

    internal static string TestTxt => Path.Combine(_testFileDirectory, "Test.txt");
}
