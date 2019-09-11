using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class Constant
{
    public static class Animation
    {
        public static class Srot
        {
            public const string SrotButton = "isSrot";
            public const string SrotBar = "StopTrigger";
        }
    }

    public static class Srot
    {
        public const int SpriteHeight = 210;
        public const int ScrollSpeed_1 = 30;
        public const int ScrollSpeed_2 = 10;
        public const int ScrollSpeed_3 = 5;
    }

    public static class GameMain
    {
        public const float DefaultPower = 2.5f;
        public const float NextDelayTime = 2.0f;
    }
}
