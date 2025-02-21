using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkerKinzel.Helpers.Tests;

[TestClass]
public class StreamHelperTests
{
    [NotNull]
    public TestContext? TestContext { get; set; }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void InitStreamWriterTest1()
    {
        using StreamWriter writer = StreamHelper.InitStreamWriter(null!, null, null);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void InitStreamWriterTest2()
    {
        using StreamWriter writer = StreamHelper.InitStreamWriter("", null, null);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void InitStreamWriterTest3()
    {
        using StreamWriter writer = StreamHelper.InitStreamWriter("  ", null, null);
    }

    [TestMethod]
    public void InitStreamWriterTest4()
    {
        string path = Path.Combine(TestContext.TestRunResultsDirectory!, "InitStreamWriterTest4.txt");
        using StreamWriter writer = StreamHelper.InitStreamWriter(path, null, null);
        Assert.IsNotNull(writer);
        Assert.AreEqual(Encoding.UTF8, writer.Encoding);
        Assert.AreEqual(Environment.NewLine, writer.NewLine);
    }

    [TestMethod]
    public void InitStreamWriterTest5()
    {
        string path = Path.Combine(TestContext.TestRunResultsDirectory!, "InitStreamWriterTest5.txt");
        using StreamWriter writer = StreamHelper.InitStreamWriter(path, Encoding.Unicode, "::");
        Assert.IsNotNull(writer);
        Assert.AreEqual(Encoding.Unicode, writer.Encoding);
        Assert.AreEqual("::", writer.NewLine);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void InitStreamReaderTest1()
    {
        using StreamReader reader = StreamHelper.InitStreamReader(null!, null);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void InitStreamReaderTest2()
    {
        using StreamReader reader = StreamHelper.InitStreamReader("", null);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void InitStreamReaderTest3()
    {
        using StreamReader reader = StreamHelper.InitStreamReader("  ", null);
    }

    [TestMethod]
    public void InitStreamReaderTest4()
    {
        using StreamReader reader = StreamHelper.InitStreamReader(TestFiles.TestTxt, null);
        Assert.IsNotNull(reader);
        Assert.AreEqual(Encoding.UTF8, reader.CurrentEncoding);
    }

    [TestMethod]
    public void InitStreamReaderTest5()
    {
        using StreamReader reader = StreamHelper.InitStreamReader(TestFiles.TestTxt, Encoding.Unicode);
        Assert.IsNotNull(reader);
        Assert.AreEqual(Encoding.Unicode, reader.CurrentEncoding);
    }
}
