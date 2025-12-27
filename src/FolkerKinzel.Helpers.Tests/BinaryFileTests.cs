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
    public void SaveTest1()
    {
        Assert.ThrowsExactly<ArgumentNullException>(() => BinaryFile.Save(null!, []));
    }

    [TestMethod]
    public void SaveTest2()
    {
        string path = Path.Combine(TestContext.TestRunResultsDirectory!, "SaveTest2.bin");
        Assert.ThrowsExactly<ArgumentNullException>(() => BinaryFile.Save(path, null!));
    }

    [TestMethod]
    public void SaveTest3()
    {
        Assert.ThrowsExactly<ArgumentException>(() => BinaryFile.Save("", []));
    }

    [TestMethod]
    public void SaveTest4()
    {
        Assert.ThrowsExactly<ArgumentException>(() => BinaryFile.Save("   ", []));
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
    public void LoadTest1()
    {
        Assert.ThrowsExactly<ArgumentNullException>(() => BinaryFile.Load(null!));
    }

    [TestMethod]
    public void LoadTest2()
    {
        Assert.ThrowsExactly<ArgumentException>(() => BinaryFile.Load(""));
    }

    [TestMethod]
    public void LoadTest3()
    {
        Assert.ThrowsExactly<ArgumentException>(() => BinaryFile.Load("   "));
    }

    [TestMethod()]
    public void OpenTest1()
    {
        Assert.ThrowsExactly<ArgumentNullException>(() => BinaryFile.Open(null!, FileMode.Create, FileAccess.Write, FileShare.ReadWrite));
    }

    [TestMethod()]
    public void OpenTest2()
    {
        Assert.ThrowsExactly<ArgumentException>(() => BinaryFile.Open("", FileMode.Create, FileAccess.Write, FileShare.ReadWrite));
    }

    [TestMethod()]
    public void OpenTest3()
    {
        Assert.ThrowsExactly<ArgumentException>(() => BinaryFile.Open("  ", FileMode.Create, FileAccess.Write, FileShare.ReadWrite));
    }

    [TestMethod()]
    public void OpenTest4()
    {
        Assert.ThrowsExactly<IOException>(() => BinaryFile.Open("nixDa", FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
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
    public void OpenTest6()
    {
        string path = Path.Combine(TestContext.TestRunResultsDirectory!, "OpenTest6.bin");
        Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => BinaryFile.Open(path, (FileMode)4711, FileAccess.Write, FileShare.None));
        
    }
}
