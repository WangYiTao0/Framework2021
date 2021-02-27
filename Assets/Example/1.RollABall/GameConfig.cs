using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WytFramework.FullStack.Example.RollABall
{
    public class GameConfig
    {
        public static IPlayerInput PlayerInput = null;
        public static void Config()
        {
            PlayerInput = new KeyboardPlayerInput();
        }
    }
}
