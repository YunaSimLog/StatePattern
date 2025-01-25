using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();

            // 1. StateA 상태 설정
            context.SetState(new ConcreteStateA());

            // 2. 현재 StateA 상태에 맞는 메소드 실행
            context.Request();

            // 3. StateB 상태 설정
            context.SetState(new ConcreteStateB());

            // 4. StateB 상태에 맞는 메소드 실행 후, StateC로 상태 변경
            context.Request();

            // 5. StateC 상태에 맞는 메소드 실행
            context.Request();
        }
    }
}
