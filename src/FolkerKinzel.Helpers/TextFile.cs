using System.Text;

namespace FolkerKinzel.Helpers;

/// <summary>
/// Helper class for operations with text files.
/// </summary>
public static class TextFile
{
    /// <summary> Opens a text file for reading. </summary>
    /// <param name="filePath">The file path.</param>
    /// <param name="textEncoding">The text encoding to be used to read the file,
    /// or <c>null</c> for <see cref="Encoding.UTF8" />.</param>
    /// <returns>A <see cref="StreamReader" /> instance for reading the file.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="filePath" /> is <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentException"> <paramref name="filePath" /> is not a valid
    /// file path.</exception>
    /// <exception cref="IOException">I/O error.</exception>
    [ExcludeFromCodeCoverage]
    public static StreamReader OpenRead(string filePath, Encoding? textEncoding)
    {
        try
        {
            return new StreamReader(filePath, textEncoding ?? Encoding.UTF8, true);
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

    /// <summary> Initializes a new <see cref="StreamWriter" /> instance. </summary>
    /// <param name="filePath">The file path.</param>
    /// <param name="textEncoding">The text encoding to be used to write the CSV file
    /// or <c>null</c> for <see cref="Encoding.UTF8" />.</param>
    /// <param name="newLine">The line terminator string to be used, or <c>null</c> for 
    /// <see cref="Environment.NewLine"/>.</param>
    /// <param name="append">If <c>true</c>, the file is opened for appending; otherwise, 
    /// the file will be truncated and overwritten. If the specified file does not exist,
    /// this parameter has no effect, and a new file will be created.
    /// </param>
    /// <returns> The newly created <see cref="StreamWriter" /> instance. </returns>
    /// 
    /// 
    /// <exception cref="ArgumentNullException"> <paramref name="filePath" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException"> <paramref name="filePath" /> is not a valid
    /// file path.</exception>
    /// <exception cref="IOException">I/O-Error</exception>
    [ExcludeFromCodeCoverage]
    public static StreamWriter OpenWrite(string filePath,
                                         Encoding? textEncoding,
                                         string? newLine,
                                         bool append)
    {
        try
        {
            return new StreamWriter(filePath, append, textEncoding ?? Encoding.UTF8) // UTF-8 with BOM
            {
                NewLine = newLine
            };
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