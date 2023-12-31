namespace Adressbok.Shared.Interfaces;

public interface IFileService
{
    /// <summary>
    /// Save content to a specified filepath.
    /// </summary>
    /// <param name="filePath">Enter the filepath with extension (eg. C:\projects\fileName.json).</param>
    /// <param name="content">Enter your content as a string.</param>
    /// <returns>Returns true if save is successed, else false if save is failed.</returns>
    bool SaveContentToFile(string filePath, string content);

    /// <summary>
    /// Get content as string from a specified filepath.
    /// </summary>
    /// <param name="filePath">Enter the filepath with extension (eg. C:\projects\fileName.json).</param>
    /// <returns>Returns file content as string if file exists, else returns null.</returns>
    string GetContentFromFile(string filePath);
}
