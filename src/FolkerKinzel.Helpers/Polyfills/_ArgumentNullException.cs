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
#if NET6_0_OR_GREATER
        => ArgumentNullException.ThrowIfNull(argument, paramName);
#else
    { if (argument is null) { throw new ArgumentNullException(paramName); } }
#endif
}



