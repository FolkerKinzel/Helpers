namespace FolkerKinzel.Helpers.Polyfills.Tests;

[TestClass()]
public class ArgumentOutOfRangeExceptionTests
{
    [TestMethod()]
    public void ThrowIfNegativeTest1()
    {
        _ArgumentOutOfRangeException.ThrowIfNegative(0, "paramName");
    }

    [TestMethod()]
    public void ThrowIfNegativeTest2()
    {
        Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => _ArgumentOutOfRangeException.ThrowIfNegative(-1, "paramName"));
    }

    [TestMethod()]
    public void ThrowIfNegativeOrZeroTest1()
    {
        _ArgumentOutOfRangeException.ThrowIfNegativeOrZero(1, "paramName");
    }

    [TestMethod()]
    public void ThrowIfNegativeOrZeroTest2()
    {
        Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => _ArgumentOutOfRangeException.ThrowIfNegativeOrZero(-1, "paramName"));
    }

    [TestMethod()]
    public void ThrowIfNegativeOrZeroTest3()
    {
        Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => _ArgumentOutOfRangeException.ThrowIfNegativeOrZero(0, "paramName"));
    }
}