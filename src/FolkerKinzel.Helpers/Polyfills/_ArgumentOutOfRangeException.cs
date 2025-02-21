namespace FolkerKinzel.Helpers.Polyfills;

[SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
public static class _ArgumentOutOfRangeException
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ThrowIfNegative(int argument, string? paramName)
#if NET462 || NETSTANDARD2_0 || NETSTANDARD2_1
    { if (argument < 0) { throw new ArgumentOutOfRangeException(paramName); } }
#else
        => ArgumentOutOfRangeException.ThrowIfNegative(argument, paramName);
#endif

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ThrowIfNegativeOrZero(int argument, string? paramName)
#if NET462 || NETSTANDARD2_0 || NETSTANDARD2_1
    { if (argument < 1) { throw new ArgumentOutOfRangeException(paramName); } }
#else
        => ArgumentOutOfRangeException.ThrowIfNegativeOrZero(argument, paramName);
#endif
}

