using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern_2
{
    public abstract class AbstractState
    {
        public abstract void RequestHandle(Context cxt);
    }

    public class ConcreteStateA : AbstractState
    {
        public override void RequestHandle(Context cxt)
        {
            Console.WriteLine("ConcreteStateA - RequestHandle 실행");
        }
    }

    public class ConcreteStateB : AbstractState
    {
        // 상태에서 동작을 실행한 후 바로 다른 상태로 바꾸기도 함.
        // 예를 들어 전원 On 상태에서 끄기 동작을 실행한 후 객체 상태를 전원 Off로 변경 하듯이
        public override void RequestHandle(Context cxt)
        {
            Console.WriteLine("ConcreteStateB - RequestHandle 실행");

            cxt.SetState(new ConcreteStateC());
        }
    }

    public class ConcreteStateC : AbstractState
    {
        public override void RequestHandle(Context cxt)
        {
            Console.WriteLine("ConcreteStateC - RequestHandle 실행");
        }
    }

    public class Context
    {
        // Composition (구성)
        AbstractState _state;

        public void SetState(AbstractState state)
        {
            _state = state;
        }

        // 상태에 의존한 처리 메소드로서 state 객체에 처리를 위함.
        public void Request()
        {
            _state.RequestHandle(this);
        }
    }
}
