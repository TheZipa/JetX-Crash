using UnityEngine;

namespace Aviator.Code.Data.StaticData
{
    [CreateAssetMenu(fileName = "Aviator Settings Config", menuName = "Static Data/Aviator Settings Config")]
    public class AviatorSettingsConfig : ScriptableObject
    {
        public double StartCoins;
        public int HistoryBarLength;
        public int MaxHistoryCount;
        [Space(10)] 
        public Gradient HistoryPointMultiplierGradient;
        public float StartGameTimerDelay;
        [Space(10)] 
        public float[] MultiplierSectors;
    }
}