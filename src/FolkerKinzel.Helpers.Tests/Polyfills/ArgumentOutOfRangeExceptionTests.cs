using Microsoft.VisualStudio.TestTools.UnitTesting;
using FolkerKinzel.Helpers.Polyfills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void ThrowIfNegativeTest2()
    {
        _ArgumentOutOfRangeException.ThrowIfNegative(-1, "paramName");
    }

    [TestMethod()]
    public void ThrowIfNegativeOrZeroTest1()
    {
        _ArgumentOutOfRangeException.ThrowIfNegativeOrZero(1, "paramName");
    }

    [TestMethod()]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void ThrowIfNegativeOrZeroTest2()
    {
        _ArgumentOutOfRangeException.ThrowIfNegativeOrZero(-1, "paramName");
    }

    [TestMethod()]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void ThrowIfNegativeOrZeroTest3()
    {
        _ArgumentOutOfRangeException.ThrowIfNegativeOrZero(0, "paramName");
    }
}