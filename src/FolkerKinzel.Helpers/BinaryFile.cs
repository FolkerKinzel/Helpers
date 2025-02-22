namespace FolkerKinzel.Helpers;

/// <summary>
/// Helper class for operations with binary files.
/// </summary>
public static class BinaryFile
{
    /// <summary>
    /// Loads a binary file.
    /// </summary>
    /// <param name="filePath">The file path.</param>
    /// <returns>The content of the binary file as byte array.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="filePath" /> is <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentException"> <paramref name="filePath" /> is not a valid
    /// file path.</exception>
    /// <exception cref="IOException">I/O error.</exception>
    [ExcludeFromCodeCoverage]
    public static byte[] Load(string filePath)
    {
        try
        {
            return File.ReadAllBytes(filePath);
        }
        catch (ArgumentNullException)
        {
            throw new ArgumentNullException(nameof(filePath));
        }
        catch (ArgumentException e)
        {
            throw new ArgumentException(e.Message, nameof(filePath), e);
        }
        catch (UnauthorizedAccessException e)
        {
            throw new IOException(e.Message, e);
        }
        catch (NotSupportedException e)
        {
            throw new ArgumentException(e.Message, nameof(filePath), e);
        }
        catch (System.Security.SecurityException e)
        {
            throw new IOException(e.Message, e);
        }
        catch (PathTooLongException e)
        {
            throw new ArgumentException(e.Message, nameof(filePath), e);
        }
        catch (Exception e)
        {
            throw new IOException(e.Message, e);
        }
    }

    /// <summary>
    /// Saves a byte array to a file.
    /// </summary>
    /// <param name="filePath">The file path.</param>
    /// <param name="bytes">The byte array to save.</param>
    /// <exception cref="ArgumentNullException"> <paramref name="filePath" /> or 
    /// <paramref name="bytes"/> is <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentException"> <paramref name="filePath" /> is not a valid
    /// file path.</exception>
    /// <exception cref="IOException">I/O error.</exception>
    [ExcludeFromCodeCoverage]
    public static void Save(string filePath, byte[] bytes)
    {
        try
        {
            File.WriteAllBytes(filePath, bytes);
        }
        catch (ArgumentNullException)
        {
            throw new ArgumentNullException(nameof(filePath));
        }
        catch (ArgumentException e)
        {
            throw new ArgumentException(e.Message, nameof(filePath), e);
        }
        catch (UnauthorizedAccessException e)
        {
            throw new IOException(e.Message, e);
        }
        catch (NotSupportedException e)
        {
            throw new ArgumentException(e.Message, nameof(filePath), e);
        }
        catch (System.Security.SecurityException e)
        {
            throw new IOException(e.Message, e);
        }
        catch (PathTooLongException e)
        {
            throw new ArgumentException(e.Message, nameof(filePath), e);
        }
        catch (Exception e)
        {
            throw new IOException(e.Message, e);
        }
    }

    /// <summary>
    /// Opens a file.
    /// </summary>
    /// <param name="filePath">The file path.</param>
    /// <param name="mode">The file mode.</param>
    /// <param name="access">The file access.</param>
    /// <param name="share">The file share mode.</param>
    /// <returns>A newly created <see cref="FileStream"/>.</returns>
    /// 
    /// <exception cref="ArgumentNullException"> <paramref name="filePath" /> is <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentException"> <paramref name="filePath" /> is not a valid
    /// file path.</exception>
    /// <exception cref="IOException">I/O error.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="mode"/> contains an 
    /// invalid value.</exception>
    [ExcludeFromCodeCoverage]
    public static FileStream Open(string filePath,
                                  FileMode mode,
                                  FileAccess access,
                                  FileShare share)
    {
        try
        {
            return new FileStream(filePath, mode, access, share);
        }
        catch(ArgumentOutOfRangeException)
        {
            throw;
        }
        catch (ArgumentNullException)
        {
            throw new ArgumentNullException(nameof(filePath));
        }
        catch (ArgumentException e)
        {
            throw new ArgumentException(e.Message, nameof(filePath), e);
        }
        catch (UnauthorizedAccessException e)
        {
            throw new IOException(e.Message, e);
        }
        catch (NotSupportedException e)
        {
            throw new ArgumentException(e.Message, nameof(filePath), e);
        }
        catch (System.Security.SecurityException e)
        {
            throw new IOException(e.Message, e);
        }
        catch (PathTooLongException e)
        {
            throw new ArgumentException(e.Message, nameof(filePath), e);
        }
        catch (Exception e)
        {
            throw new IOException(e.Message, e);
        }
    }
}