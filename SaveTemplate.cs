using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SaveTemplate
{
    /// <summary>
    /// Marks the seperation of data in a string
    /// </summary>
    protected const char DataSplitter = ';';
    /// <summary>
    /// File Path for Saved Data
    /// </summary>
    public abstract string filePath { get; }
    /// <summary>
    /// Save Data to File
    /// </summary>
    public void Save() => FileManager.WriteToFile(GetData(), filePath);
    /// <summary>
    /// Load Data from File
    /// </summary>
    public void Load() => InterpretData(GetData());
    /// <summary>
    /// 
    /// </summary>
    protected abstract string[] GetData();
    /// <summary>
    /// Interprets the Data from the File, assigning all of the values
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    protected abstract void InterpretData(string[] data);

    protected int ParseToint(string value)
    {
        try
        {
            return int.Parse(value);
        }
        catch (System.Exception)
        {
            Debug.LogError("Data was unable to be parsed");
            return 0;
        }
    }

    protected float ParseToFloat(string value)
    {
        try
        {
            return float.Parse(value);
        }
        catch (System.Exception)
        {
            Debug.LogError("Data was unable to be parsed");
            return 0;
        }
    }

    protected double ParseToDouble(string value)
    {
        try
        {
            return double.Parse(value);
        }
        catch (System.Exception)
        {
            Debug.LogError("Data was unable to be parsed");
            return 0;
        }
    }
}
