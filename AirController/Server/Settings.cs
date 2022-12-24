using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirController.Server
{
    class Settings
    {
        // Константы
        public enum Ports {
            CONNECTION = 17103,
            DETECTION_SERVER = 17104,
            DETECTION_CLIENT = 17105,
            KEYBOARD = 17106,
            MOUSE = 17107
        }

        public const string DETECTION_KEY = "hzaXh4yc";
        public const string CONNECTION_KEY = "6Kd3iGbf";

        // Иные значения
        public static string ClientIp = "";
        public static bool Connected = false;
    }
}
