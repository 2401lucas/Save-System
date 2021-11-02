using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveData : SaveTemplate
{
    public override string filePath => "playerSave";

    public float highscore = 0;
    public float currency = 0;

    protected override string[] GetData()
    {
        throw new System.NotImplementedException();
    }

    protected override void InterpretData(string[] data)
    {
        if (string.IsNullOrEmpty(data[0]))
            return;

        string[] splitData = data[0].Split(DataSplitter);

        highscore = ParseToFloat(splitData[0]);
        currency = ParseToFloat(splitData[1]);
    }
}
