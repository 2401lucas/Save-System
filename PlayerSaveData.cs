public class PlayerSaveData : SaveTemplate
{
    protected override string filePath => "playerSave";

    public float highscore = 0;
    public int currency = 0;

    protected override string[] GetData()
    {
        string[] data = new string[1];
        data[0] = $"{highscore}{DataSplitter}{currency}";
        return data;
    }

    protected override void InterpretData(string[] data)
    {
        if (string.IsNullOrEmpty(data[0]))
            return;

        string[] splitData = data[0].Split(DataSplitter);

        highscore = ParseToFloat(splitData[0]);
        currency = ParseToInt(splitData[1]);
    }
}
