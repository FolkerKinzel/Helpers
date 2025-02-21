namespace FolkerKinzel.Helpers.Polyfills;

/// <summary>
/// Polyfill for <see cref="ArgumentOutOfRangeException"/>.
/// </summary>
[SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
public static class _ArgumentOutOfRangeException
{
    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument"/> is negative.
    /// </summary>
    /// <param name="argument">The argument to check.</param>
    /// <param name="paramName">The name of the checked parameter.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ThrowIfNegative(int argument, string? paramName)
#if NET462 || NETSTANDARD2_0 || NETSTANDARD2_1
    { if (argument < 0) { throw new ArgumentOutOfRangeException(paramName); } }
#else
        => ArgumentOutOfRangeException.ThrowIfNegative(argument, paramName);
#endif

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument"/> is negative or zero.
    /// </summary>
    /// <param name="argument">The argument to check.</param>
    /// <param name="paramName">The name of the checked parameter.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ThrowIfNegativeOrZero(int argument, string? paramName)
#if NET462 || NETSTANDARD2_0 || NETSTANDARD2_1
    { if (argument < 1) { throw new ArgumentOutOfRangeException(paramName); } }
#else
        => ArgumentOutOfRangeException.ThrowIfNegativeOrZero(argument, paramName);
#endif
}

