using System.Text;

namespace FolkerKinzel.Helpers;

/// <summary>
/// Helper class for <see cref="Stream"/> operations.
/// </summary>
public static class StreamHelper
{
    /// <summary> Initializes a <see cref="StreamReader" /> instance. </summary>
    /// <param name="filePath">The file path.</param>
    /// <param name="textEncoding">The text encoding to be used to read the CSV file
    /// or <c>null</c> for <see cref="Encoding.UTF8" />.</param>
    /// <returns>The newly created <see cref="StreamReader" /> instance.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="filePath" /> is <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentException"> <paramref name="filePath" /> is not a valid
    /// file path.</exception>
    /// <exception cref="IOException">Error accessing the disk.</exception>
    [ExcludeFromCodeCoverage]
    public static StreamReader InitStreamReader(string filePath, Encoding? textEncoding)
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
    /// <returns> The newly created <see cref="StreamWriter" /> instance. </returns>
    /// <exception cref="ArgumentNullException"> <paramref name="filePath" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException"> <paramref name="filePath" /> is not a valid
    /// file path.</exception>
    /// <exception cref="IOException">I/O-Error</exception>
    [ExcludeFromCodeCoverage]
    public static StreamWriter InitStreamWriter(string filePath,
                                                  Encoding? textEncoding,
                                                  string? newLine)
    {
        try
        {
            return new StreamWriter(filePath, false, textEncoding ?? Encoding.UTF8) // UTF-8 with BOM
            {
                NewLine = newLine ?? Environment.NewLine
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