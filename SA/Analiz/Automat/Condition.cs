using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Analiz
{
    class Condition
    {
        public string State { get;private set; }

        public string Lexem { get; private set; }

        public string NextState { get; private set; }

        public string Stack { get; private set; }

        public SP SP { get;private set; }

        public Condition(string currState, string lexem, string nextState, string stack, SP sp)
        {
            State = currState;
            Lexem = lexem;
            NextState = nextState;
            Stack = stack;
            SP = sp;
        }
    }

    
   public struct SP
    {
        public Action Equel { get;private set; }
        public Action NotEquel { get; private set; }


        public SP(Action equel, Action notequel)
        {
            Equel = equel;
            NotEquel = notequel;
        }
        
    }

    public struct Action
    {
       public string State { get;private set; }
       public string Stack { get;private set; }

       public Action(string state, string stack)
        {
            State = state;
            Stack = stack;
        }
    }
}
