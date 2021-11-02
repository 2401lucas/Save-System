using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileManager
{
    public static string[] ReadFromFile(string filePath, string fileEnding = ".txt") {
        if (!File.Exists($"{Application.persistentDataPath}/{filePath}{fileEnding}"))
            return new string[0];
        
        return File.ReadAllLines($"{Application.persistentDataPath}/{filePath}{fileEnding}");
    }
    public static void WriteToFile(string[] content, string filePath, string fileEnding = ".txt") {
        if (!File.Exists($"{Application.persistentDataPath}/{filePath}{fileEnding}"))
            File.Create($"{Application.persistentDataPath}/{filePath}{fileEnding}");

        File.WriteAllLines($"{Application.persistentDataPath}/{filePath}{fileEnding}", content);
    }
    public static void Delete(string filePath, string fileEnding = ".txt")
    {
        if (!File.Exists($"{Application.persistentDataPath}/{filePath}{fileEnding}"))
            return;

        File.Delete($"{Application.persistentDataPath}/{filePath}{fileEnding}");
    }
}
