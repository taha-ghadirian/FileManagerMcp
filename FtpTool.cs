using System.ComponentModel;
using FluentFTP;
using ModelContextProtocol.Server;

namespace FtpManagerMcp;

[McpServerToolType]
public class FtpTool
{
    [McpServerTool, Description("Return list of files in the given directory.")]
    public string ListFiles(
        [Description("The directory to list files from.")] string directory = "/",
        [Description("Whether to list files recursively.")] bool recursive = false)
    {
        using var client = new FtpClient(Login.host, Login.username, Login.password, Login.port);
        client.Connect();

        if (!client.DirectoryExists(directory))
        {
            return $"Error: Directory '{directory}' does not exist";
        }

        var items = client.GetListing(directory, recursive ? FtpListOption.Recursive : FtpListOption.AllFiles);
        var fileList = items.Select(item => $"{item.Type},{item.FullName},{item.Size},{item.Modified}").ToList();

        client.Disconnect();
        return "Type,Name,Size,Modified\n" + string.Join("\n", fileList);
    }

    [McpServerTool, Description("Download a file from the given directory.")]
    public string DownloadFile(
        [Description("The file path to download. Example: '/path/to/file.txt'")] string filePath,
        [Description("The local path to download the file to, example: 'downloads/file.txt'")] string localPath = ".")
    {
        using var client = new FtpClient(Login.host, Login.username, Login.password, Login.port);
        client.Connect();

        if (!client.FileExists(filePath))
        {
            return $"Error: File '{filePath}' does not exist.";
        }

        var directory = Path.GetDirectoryName(localPath) ?? ".";
        if (!client.DirectoryExists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        if (File.Exists(localPath))
        {
            return $"Error: Local file '{localPath}' already exists, can't overwrite it.";
        }

        client.DownloadFile(filePath, localPath);

        client.Disconnect();
        return $"Downloaded {filePath} to {localPath}";
    }

    [McpServerTool, Description("Upload a file to the given directory.")]
    public string UploadFile(
        [Description("The file path to upload. Example: 'downloads/file.txt'")] string filePath,
        [Description("The remote path to upload the file to. Example: '/path/to/file.txt'")] string remotePath = "/")
    {
        using var client = new FtpClient(Login.host, Login.username, Login.password, Login.port);
        client.Connect();
        
        if (!File.Exists(filePath))
        {
            return $"Error: Local file '{filePath}' does not exist";
        }

        if (!client.DirectoryExists(Path.GetDirectoryName(remotePath)))
        {
            return $"Error: Remote directory '{Path.GetDirectoryName(remotePath)}' does not exist";
        }

        if (client.FileExists(remotePath))
        {
            return $"Error: Remote file '{remotePath}' already exists";
        }

        client.UploadFile(filePath, remotePath);

        client.Disconnect();
        return $"Uploaded {filePath} to {remotePath}";
    }

    [McpServerTool, Description("Delete a file from the given directory.")]
    public string DeleteFile(
        [Description("The file path to delete. Example: '/path/to/file.txt'")] string filePath)
    {
        using var client = new FtpClient(Login.host, Login.username, Login.password, Login.port);
        client.Connect();

        client.DeleteFile(filePath);

        client.Disconnect();
        return $"Deleted {filePath}";
    }

    [McpServerTool, Description("Delete multiple files from the given paths.")]
    public string DeleteFiles(
        [Description("The file paths to delete, separated by commas. Example: '/path/file1.txt,/path/file2.txt'")] string filePaths)
    {
        using var client = new FtpClient(Login.host, Login.username, Login.password, Login.port);
        client.Connect();

        var paths = filePaths.Split(',').Select(p => p.Trim()).ToList();
        var deleted = new List<string>();
        var failed = new List<string>();

        foreach (var path in paths)
        {
            try
            {
                client.DeleteFile(path);
                deleted.Add(path);
            }
            catch (Exception)
            {
                failed.Add(path);
            }
        }

        client.Disconnect();

        var result = $"Deleted {deleted.Count} files: {string.Join(", ", deleted)}";
        if (failed.Count != 0)
        {
            result += $"\nFailed to delete {failed.Count} files: {string.Join(", ", failed)}";
        }
        return result;
    }

    [McpServerTool, Description("Create a directory in the given path.")]
    public string CreateDirectory(
        [Description("The path to create the directory in. Example: '/path/to/directory'")] string path)
    {
        using var client = new FtpClient(Login.host, Login.username, Login.password, Login.port);
        client.Connect();

        if (client.DirectoryExists(path))
        {
            return $"Error: Directory '{path}' already exists.";
        }

        client.CreateDirectory(path);

        client.Disconnect();
        return $"Created directory {path}";
    }

    [McpServerTool, Description("Delete a directory from the given path.")]
    public string DeleteDirectory(
        [Description("The path to delete the directory from. Example: '/path/to/directory'")] string path)
    {
        using var client = new FtpClient(Login.host, Login.username, Login.password, Login.port);
        client.Connect();

        client.DeleteDirectory(path);

        client.Disconnect();
        return $"Deleted directory {path}";
    }
} 