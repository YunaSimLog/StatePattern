using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    class Context
    {
        private State m_State = null;

        public Context(State state)
        {
            this.TransitionTo(state);
        }

        // 상태 객체를 변경
        public void TransitionTo(State state)
        {
            Console.WriteLine($"Context: Transition to {state.GetType().Name}");
            this.m_State = state;
            this.m_State.SetContext(this);
        }

        public void Request1()
        {
            this.m_State.Handle1();
        }

        public void Request2()
        {
            this.m_State.Handle2();
        }
    }

    abstract class State
    {
        protected Context m_Context;

        public void SetContext(Context context)
        {
            m_Context = context;
        }

        public abstract void Handle1();

        public abstract void Handle2();
    }

    class ConcreteStateA : State
    {
        public override void Handle1()
        {
            Console.WriteLine("ConcreteStateA Handle1 request");
            m_Context.TransitionTo(new ConcreteStateB());
        }
        public override void Handle2()
        {
            Console.WriteLine("ConcreteStateA Handle2 request");
        }
    }

    class ConcreteStateB : State
    {
        public override void Handle1()
        {
            Console.WriteLine("ConcreteStateB Handle1 request");
        }

        public override void Handle2()
        {
            Console.WriteLine("ConcreteStateB Handle2 request");
            m_Context.TransitionTo(new ConcreteStateA());
        }
    }
}
