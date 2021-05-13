using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace AlienGame.Managers
{
    public class DataManager
    {
        #region File Paths
        private const string defaultFilePath = "/default.txt";
        #endregion

        #region File Management
        private static void DeleteFile(string filePath)
        {
            if (File.Exists(Application.persistentDataPath + filePath))
            {
                File.Delete(Application.persistentDataPath + filePath);
            }
        }
        private static void WriteToFile(string filePath, string stringToWrite)
        {
            StreamWriter sw = new StreamWriter(Application.persistentDataPath + filePath, false);

            sw.Write(stringToWrite);

            sw.Close();
        }

        public static string[] ReadFromFile(string filePath) => File.ReadAllLines(Application.persistentDataPath + filePath);
        #endregion

        #region Public Methods
        /// <summary>
        /// Saves data to files
        /// </summary>
        public static void SaveData()
        {
            //WriteToFile(defaultFilePath, StatsAndAchievements.GetDefaultData)
        }
        /// <summary>
        /// Resets Data by deleting files for testing purposes 
        /// </summary>
        public static void ResetData()
        {
            //DeleteFile(defaultFilePath);
        }
        /// <summary>
        /// Loads all data from files
        /// Needs to be called on Awake in GameManager
        /// </summary>
        public static void LoadAllData()
        {
            if (File.Exists(Application.persistentDataPath + defaultFilePath))
            {
                var lines = ReadFromFile(defaultFilePath);

                //Iterates thru all of the lines in the file
                for (var i = 0; i < lines.Length; i++)
                {
                    //If the line is empty, break out of the loop
                    if (lines[i] == "")
                        break;

                    //Splits the line 
                    var splitLine = lines[i].Split(';');

                    //Parse The Data
                    StatsAndAchievements.LoadData(new DefaultData(int.Parse(splitLine[0]), int.Parse(splitLine[1])));
                }
            }
            else
            {
                StatsAndAchievements.LoadData(new DefaultData(""));
            }
        }
        #endregion
    }
    #region Structs
    public struct DefaultData
    {
        public float defaultVariableOne;
        public float defaultVariableTwo;

        //Contructor
        public DefaultData(float defaultVariableOne, float defaultVariableTwo)
        {
            this.defaultVariableOne = defaultVariableOne;
            this.defaultVariableTwo = defaultVariableTwo;
        }

        /// <summary>
        /// Used to create a new DefaultData object with default Values
        /// </summary>
        /// <param name="tempString"> </param>
        public DefaultData(string tempString)
        {
            this.defaultVariableOne = 0;
            this.defaultVariableTwo = 0;
        }
        /// <summary>
        /// Save info used for writing to files
        /// </summary>
        /// <returns>String</returns>
        public string GetSaveInfo() => $"{defaultVariableOne};{defaultVariableTwo}";
    }

    #endregion
}