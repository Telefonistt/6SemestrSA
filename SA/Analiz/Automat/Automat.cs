using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Analiz
{
    class Automat
    {
        private List<Condition> conditions;

        public List<Condition> Conditions
        {
            get { return new List<Condition>(conditions); }
            private set { conditions = value; }
        }



        //private SA.Data.LexemTable lextable=null

        public Automat()
        {
            conditions = new List<Condition>();
            Init();
        }
        private void AddState(string currState, string lexem, string nextState, string stack, SP sp)
        {
            conditions.Add(new Condition(currState,lexem,nextState,stack,sp));
        }

        private void Init()
        {
            //GENERAL PROGRAM//////////////////////////////////////////////////////////////////////
            AddState("1", "Програма",    "2", "", new SP(new Action(), new Action("Er", null)));
            AddState("2", "id",          "3", "", new SP(new Action(), new Action("Er", null)));
            AddState("3", "змінні", "4", "", new SP(new Action(), new Action("Er", null)));
            AddState("4", "id", "5", "", new SP(new Action(), new Action("Er", null)));

            AddState("5", ",", "4", "", new SP(new Action(), new Action()));
            AddState("5", ":", "6", "", new SP(new Action(), new Action("Er", null)));

            AddState("6", "ціле", "7", "", new SP(new Action(), new Action()));
            AddState("6", "дійсне", "7", "", new SP(new Action(), new Action()));
            AddState("6", "символ", "7", "", new SP(new Action(), new Action()));
            AddState("6", "логічне", "7", "", new SP(new Action(), new Action("Er", null)));

            AddState("7", "початок", "1-1", "8", new SP(new Action(), new Action()));
            AddState("7", ";", "4", "", new SP(new Action(), new Action("Er", null)));

            AddState("8", "кінець", "", "", new SP(new Action("Ex", null),  new Action()));
            AddState("8", ";", "1-1", "8", new SP(new Action(), new Action("Er", null)));

            //OPERATOR//////////////////////////////////////////////////////////////////////
            AddState("1-1", "читати", "1-2", "", new SP(new Action(), new Action()));
            AddState("1-1", "писати", "1-2", "", new SP(new Action(), new Action()));
            AddState("1-1", "для", "1-5", "", new SP(new Action(), new Action()));
            AddState("1-1", "якщо", "1-14", "", new SP(new Action(), new Action()));
            AddState("1-1", "(", "1-18", "", new SP(new Action(), new Action()));
            AddState("1-1", "id", "1-23", "", new SP(new Action(), new Action("Er", null)));

            AddState("1-2", "(", "1-3", "", new SP(new Action(), new Action("Er", null)));
            AddState("1-3", "id", "1-4", "", new SP(new Action(), new Action("Er", null)));

            AddState("1-4", ")", "", "", new SP(new Action("Ex", null), new Action()));
            AddState("1-4", ",", "1-3", "", new SP(new Action(), new Action("Er", null)));

            AddState("1-5", "(", "1-6", "", new SP(new Action(), new Action("Er", null)));
            AddState("1-6", "id", "1-7", "", new SP(new Action(), new Action("Er", null)));
            AddState("1-7", "=", "2-1", "1-8", new SP(new Action(), new Action("Er", null)));
            AddState("1-8", ";", "3-1", "1-9", new SP(new Action(), new Action("Er", null)));
            AddState("1-9", ";", "1-10", "", new SP(new Action(), new Action("Er", null)));
            AddState("1-10", "id", "1-11", "", new SP(new Action(), new Action("Er", null)));
            AddState("1-11", "=", "2-1", "1-12", new SP(new Action(), new Action("Er", null)));

            AddState("1-12", ")", "1-1", "1-13", new SP(new Action(), new Action("Er", null)));
            AddState("1-13", "", "", "", new SP(new Action(), new Action("Ex", null)));
            AddState("1-14", "(", "3-1", "1-15", new SP(new Action(), new Action("Er", null)));
            AddState("1-15", ")", "1-16", "", new SP(new Action(), new Action("Er", null)));
            AddState("1-16", "{", "1-1", "1-17", new SP(new Action(), new Action("Er", null)));

            AddState("1-17", "}", "", "", new SP(new Action("Ex",null), new Action()));
            AddState("1-17", ";", "1-1", "1-17", new SP(new Action(), new Action("Er", null)));

            AddState("1-18", "id", "1-19", "", new SP(new Action(), new Action("Er", null)));
            AddState("1-19", "=", "3-1", "1-20", new SP(new Action(), new Action("Er", null)));
            AddState("1-20", "?", "2-1", "1-21", new SP(new Action(), new Action("Er", null)));
            AddState("1-21", ":", "2-1", "1-22", new SP(new Action(), new Action("Er", null)));
            AddState("1-22", ")", "", "", new SP(new Action("Ex", null), new Action("Er", null)));
            AddState("1-23", "=", "2-1", "1-24", new SP(new Action(), new Action("Er", null)));
            AddState("1-24", "", "", "", new SP(new Action(), new Action("Ex", null) ));

            //ARUFM VIRAZ////////////////////////////////////////////////////////////////////

            AddState("2-1", "-", "2-2", "", new SP(new Action(), new Action()));
            AddState("2-1", "id", "2-4", "", new SP(new Action(), new Action()));
            AddState("2-1", "const", "2-4", "", new SP(new Action(), new Action()));
            AddState("2-1", "(", "2-1", "2-3", new SP(new Action(), new Action("Er", null)));

            AddState("2-2", "id", "2-4", "", new SP(new Action(), new Action()));
            AddState("2-2", "const", "2-4", "", new SP(new Action(), new Action()));
            AddState("2-2", "(", "2-1", "2-3", new SP(new Action(), new Action("Er", null)));

            AddState("2-3", ")", "2-4", "", new SP(new Action(), new Action("Er", null)));

            AddState("2-4", "+", "2-2", "", new SP(new Action(), new Action()));
            AddState("2-4", "-", "2-2", "", new SP(new Action(), new Action()));
            AddState("2-4", "*", "2-2", "", new SP(new Action(), new Action()));
            AddState("2-4", "/", "2-2", "", new SP(new Action(), new Action()));
            AddState("2-4", "^", "2-2", "", new SP(new Action(), new Action("Ex", null)));

            //LOGIC EXPRESSION/////////////////////////////////////////////////////////////////////
            AddState("3-1", "!", "3-1", "", new SP(new Action(), new Action()));
            AddState("3-1", "[", "3-1", "3-2", new SP(new Action(), new Action("2-1","3-3")));

            AddState("3-2", "]", "3-4", "", new SP(new Action(), new Action("Er", null)));

            AddState("3-3", "<", "2-1", "3-4", new SP(new Action(), new Action()));
            AddState("3-3", ">", "2-1", "3-4", new SP(new Action(), new Action()));
            AddState("3-3", "<=", "2-1", "3-4", new SP(new Action(), new Action()));
            AddState("3-3", ">=", "2-1", "3-4", new SP(new Action(), new Action()));
            AddState("3-3", "==", "2-1", "3-4", new SP(new Action(), new Action()));
            AddState("3-3", "!=", "2-1", "3-4", new SP(new Action(), new Action("Er", null)));

            AddState("3-4", "або", "3-1", "", new SP(new Action(), new Action()));
            AddState("3-4", "та", "3-1", "", new SP(new Action(), new Action("Ex", null)));
        }
    }
}

