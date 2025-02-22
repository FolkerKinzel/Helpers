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
}
