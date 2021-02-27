using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WytFramework.FullStack.Example.RollABall
{
    public interface IPlayerInput
    {
        event Action<PlayerInputData> OnInput;
        void Update();
    }
}
