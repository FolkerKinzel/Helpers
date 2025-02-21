namespace FolkerKinzel.Helpers.Polyfills;

/// <summary>
/// Polyfill for <see cref="ArgumentNullException"/>.
/// </summary>
[SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
public static class _ArgumentNullException
{
    /// <summary>
    /// Throws an <see cref="ArgumentNullException"/> if <paramref name="argument"/> is <c>null</c>.
    /// </summary>
    /// <param name="argument">The argument to check.</param>
    /// <param name="paramName">The name of the checked parameter.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ThrowIfNull([NotNull] object? argument, string? paramName)
#if NET462 || NET5_0 || NETSTANDARD2_0 || NETSTANDARD2_1
    { if (argument is null) { throw new ArgumentNullException(paramName); } }
#else
        => ArgumentNullException.ThrowIfNull(argument, paramName);
#endif
}



