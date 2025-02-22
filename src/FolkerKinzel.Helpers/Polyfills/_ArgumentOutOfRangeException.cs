namespace FolkerKinzel.Helpers.Polyfills;

/// <summary>
/// Polyfill for <see cref="ArgumentOutOfRangeException"/>.
/// </summary>
[SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
public static class _ArgumentOutOfRangeException
{
    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument"/>
    /// is negative.
    /// </summary>
    /// <param name="argument">The argument to check.</param>
    /// <param name="paramName">The name of the checked parameter.</param>
#if NET8_0_OR_GREATER
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static void ThrowIfNegative(int argument, string? paramName)
#if NET8_0_OR_GREATER
        => ArgumentOutOfRangeException.ThrowIfNegative(argument, paramName);
#else
    { if (argument < 0) { throw new ArgumentOutOfRangeException(paramName); } }
#endif

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument"/>
    /// is negative or zero.
    /// </summary>
    /// <param name="argument">The argument to check.</param>
    /// <param name="paramName">The name of the checked parameter.</param>
#if NET8_0_OR_GREATER
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static void ThrowIfNegativeOrZero(int argument, string? paramName)
#if NET8_0_OR_GREATER
        => ArgumentOutOfRangeException.ThrowIfNegativeOrZero(argument, paramName);
#else
    { if (argument < 1) { throw new ArgumentOutOfRangeException(paramName); } }
#endif
}

