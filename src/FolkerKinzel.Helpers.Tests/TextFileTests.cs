using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace FolkerKinzel.Helpers.Tests;

[TestClass]
public class TextFileTests
{
    [NotNull]
    public TestContext? TestContext { get; set; }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void OpenWriteTest1()
    {
        using StreamWriter writer = TextFile.OpenWrite(null!, null, null, false);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void OpenWriteTest2()
    {
        using StreamWriter writer = TextFile.OpenWrite("", null, null, false);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void OpenWriteTest3()
    {
        using StreamWriter writer = TextFile.OpenWrite("  ", null, null, false);
    }

    [TestMethod]
    public void OpenWriteTest4()
    {
        string path = Path.Combine(TestContext.TestRunResultsDirectory!, "InitStreamWriterTest4.txt");
        using StreamWriter writer = TextFile.OpenWrite(path, null, null, false);
        Assert.IsNotNull(writer);
        Assert.AreEqual(Encoding.UTF8, writer.Encoding);
        Assert.AreEqual(Environment.NewLine, writer.NewLine);
    }

    [TestMethod]
    public void OpenWriteTest5()
    {
        string path = Path.Combine(TestContext.TestRunResultsDirectory!, "InitStreamWriterTest5.txt");
        using (StreamWriter writer = TextFile.OpenWrite(path, Encoding.Unicode, "::", false))
        {
            Assert.IsNotNull(writer);
            Assert.AreEqual(Encoding.Unicode, writer.Encoding);
            Assert.AreEqual("::", writer.NewLine);
            writer.WriteLine("one");
        }

        using (StreamWriter writer = TextFile.OpenWrite(path, Encoding.Unicode, "::", true))
        {
            writer.Write("two");
        }

        string text = File.ReadAllText(path, Encoding.Unicode);
        Assert.AreEqual("one::two", text);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void OpenReadTest1()
    {
        using StreamReader reader = TextFile.OpenRead(null!, null);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void OpenReadTest2()
    {
        using StreamReader reader = TextFile.OpenRead("", null);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void OpenReadTest3()
    {
        using StreamReader reader = TextFile.OpenRead("  ", null);
    }

    [TestMethod]
    public void OpenReadTest4()
    {
        using StreamReader reader = TextFile.OpenRead(TestFiles.TestTxt, null);
        Assert.IsNotNull(reader);
        Assert.AreEqual(Encoding.UTF8, reader.CurrentEncoding);
    }

    [TestMethod]
    public void OpenReadTest5()
    {
        using StreamReader reader = TextFile.OpenRead(TestFiles.TestTxt, Encoding.Unicode);
        Assert.IsNotNull(reader);
        Assert.AreEqual(Encoding.Unicode, reader.CurrentEncoding);
    }
}
