using System.IO;

public class FileHandler
{
    public virtual void WriteToFile(string filePath, byte[] content)
    {
        File.WriteAllBytes(filePath, content);
    }

    public virtual byte[] ReadFromFile(string filePath)
    {
        return File.ReadAllBytes(filePath);
    }
}
