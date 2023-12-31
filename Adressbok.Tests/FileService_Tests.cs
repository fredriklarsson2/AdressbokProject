using Adressbok.Shared.Interfaces;
using Adressbok.Shared.Models;
using Adressbok.Shared.Services;

namespace Adressbok.Tests;

public class FileService_Tests
{
    [Fact]
    public void SaveContentToFileShould_SaveContentToFile_ThenReturnTrue()
    {
        // Arrange
        IFileService fileService = new FileService();
        string filePath = @"C:\source\test\test.txt";
        string content = "Test content";

        // Act
        bool result = fileService.SaveContentToFile(filePath, content);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void SaveContentToFileShould_ReturnFalse_IfFilePathDoesNotExist()
    {
        // Arrange
        IFileService fileService = new FileService();
        string filePath = @$"C:\{Guid.NewGuid()}\test.txt";
        string content = "Test content";

        // Act
        bool result = fileService.SaveContentToFile(filePath, content);

        // Assert
        Assert.False(result);
    }
}
