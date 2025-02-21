using Microsoft.VisualStudio.TestTools.UnitTesting;
using FolkerKinzel.Helpers.Polyfills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    [ExpectedException(typeof(ArgumentNullException))]
    public void ThrowIfNullTest2()
    {
        _ArgumentNullException.ThrowIfNull(null, "paramName");
    }
}