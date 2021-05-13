using System;
using System.Collections.Generic;
namespace AlienGame.Managers
{
    public class StatsAndAchievements
    {
        #region Game Data
        private static DefaultData defaultData = new DefaultData();
        #endregion

        #region Data Mutators
        public float defaultVariableOne { get => defaultData.defaultVariableOne; set { defaultData.defaultVariableOne = value; } }
        public float defaultVariableTwo { get => defaultData.defaultVariableTwo; set { defaultData.defaultVariableTwo = value; } }
        #endregion

        #region Returning Data
        /// <returns>Default Data Object </returns>
        public static DefaultData GetDefaultData() => defaultData;
        #endregion

        #region Loading Data
        /// <summary>
        /// Loads data from DataManager
        /// </summary>
        public static void LoadData<T>(T data)
        {
            if (data is DefaultData)
            {
                defaultData = (DefaultData)(object)data;
            }
        }
        #endregion
    }
}