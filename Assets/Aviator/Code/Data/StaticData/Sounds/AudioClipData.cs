using System;
using Aviator.Code.Data.Enums;
using UnityEngine;

namespace Aviator.Code.Data.StaticData.Sounds
{
    [Serializable]
    public class AudioClipData
    {
        public AudioClip Clip;
        public SoundId Id;
    }
}