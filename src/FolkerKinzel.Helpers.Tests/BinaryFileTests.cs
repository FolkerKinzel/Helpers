using Microsoft.VisualStudio.TestTools.UnitTesting;
using FolkerKinzel.Helpers;
using System.Diagnostics.CodeAnalysis;

namespace FolkerKinzel.Helpers.Tests;

[TestClass]
public class BinaryFileTests
{
    [NotNull]
    public TestContext? TestContext { get; set; }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void SaveTest1()
    {
        BinaryFile.Save(null!, []);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void SaveTest2()
    {
        string path = Path.Combine(TestContext.TestRunResultsDirectory!, "SaveTest2.bin");
        BinaryFile.Save(path, null!);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void SaveTest3()
    {
        BinaryFile.Save("", []);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void SaveTest4()
    {
        BinaryFile.Save("   ", []);
    }

    [TestMethod]
    public void SaveTest5()
    {
        byte[] bytes = [1, 2, 3];
        string path = Path.Combine(TestContext.TestRunResultsDirectory!, "SaveTest5.bin");
        BinaryFile.Save(path, bytes);

        CollectionAssert.AreEqual(bytes, BinaryFile.Load(path));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void LoadTest1() => _ = BinaryFile.Load(null!);

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void LoadTest2() => _ = BinaryFile.Load("");

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void LoadTest3() => _ = BinaryFile.Load("   ");

    [TestMethod()]
    [ExpectedException(typeof(ArgumentNullException))]
    public void OpenTest1()
    {
        using FileStream stream = BinaryFile.Open(null!, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
    }

    [TestMethod()]
    [ExpectedException(typeof(ArgumentException))]
    public void OpenTest2()
    {
        using FileStream stream = BinaryFile.Open("", FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
    }

    [TestMethod()]
    [ExpectedException(typeof(ArgumentException))]
    public void OpenTest3()
    {
        using FileStream stream = BinaryFile.Open("  ", FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
    }

    [TestMethod()]
    [ExpectedException(typeof(IOException))]
    public void OpenTest4()
    {
        using FileStream stream = BinaryFile.Open("nixDa", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
    }

    [TestMethod()]
    public void OpenTest5()
    {
        string path = Path.Combine(TestContext.TestRunResultsDirectory!, "OpenTest5.bin");
        using FileStream stream = BinaryFile.Open(path, FileMode.Create, FileAccess.Write, FileShare.None);
        {
            Assert.IsNotNull(stream);
            Assert.IsTrue(stream.CanWrite);
        }

        Assert.IsTrue(File.Exists(path));
    }

    [TestMethod()]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void OpenTest6()
    {
        string path = Path.Combine(TestContext.TestRunResultsDirectory!, "OpenTest6.bin");
        using FileStream stream = BinaryFile.Open(path, (FileMode)4711, FileAccess.Write, FileShare.None);
        
    }
}
