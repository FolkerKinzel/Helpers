namespace FolkerKinzel.Helpers.Polyfills.Tests;

[TestClass()]
public class ArgumentNullExceptionTests
{
    [TestMethod()]
    public void ThrowIfNullTest1()
    {
        _ArgumentNullException.ThrowIfNull("", "paramName");
    }

    [TestMethod()]
    public void ThrowIfNullTest2()
    {
        Assert.ThrowsExactly<ArgumentNullException>(() => _ArgumentNullException.ThrowIfNull(null, "paramName"));
    }
}