using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LA_Shtokal;

namespace SA.Analiz
{
    class Analiz
    {
        private readonly Data.Input _inpData;

        private readonly List<RezultTable> rezultTable;

        int counter = 0;
        private readonly Automat _automat;
        private readonly Data.LexemTable lexems;

        private string curr;
        private string _currState
        {
            get { return curr; }
            set
            {
                
                try
                {
                    Console.Write(value + " " + rezultTable[counter + 1].lexem);
                    Console.WriteLine(" " + _stack.Peek());
                }
                catch
                {
                    Console.WriteLine();
                }
                curr = value;
            }
        }
        private Stack<string> _stack { get; set; }

        public string Error { get; private set; }
        private bool Exit { get; set; }



        public Analiz(string code)
        {
            
            _inpData = new Data.Input(code);
            rezultTable = new List<RezultTable>(_inpData.RezultTable);
            _automat = new Automat(); _stack = new Stack<string>();
            _stack = new Stack<string>();
            _currState = "1";
            
            lexems = new Data.LexemTable();
            Exit = false;
            

            try
            {
                Error = _inpData.Err.Message;
            }
            catch
            {
                Error = null;
            }


            if(Error==null)
            Move();
        }

        private void Move()
        {
            
            bool incCounter = true;
            int lengthRezTable = rezultTable.Count;
            while(!Exit&&counter<lengthRezTable)
            {
                //находим все строки автомата с с состоянием _currState
                var currCondition= _automat.Conditions.FindAll(s => s.State == _currState);

                foreach(Condition condition in currCondition)
                {
                    //код лексемы в строке condition автомата
                    int LexCodeInCondition = lexems.FirstOrDefault(s => s.Value == condition.Lexem).Key;
                    //если лексема из ТаблицыРезультатов=лексема из Автомата
                    if (rezultTable[counter].code==LexCodeInCondition)
                    {
                        Equel(condition);
                        break;
                    }
                    else
                    {

                        if(condition.SP.NotEquel.State!=null)
                        {
                            if(condition.SP.NotEquel.State=="Er")
                            {
                                Error = "Error "+rezultTable[counter].lexem +" "+ rezultTable[counter].row;
                                return;
                            }
                            else
                            {
                                if (condition.SP.NotEquel.State == "Ex")
                                {
                                    if (_stack.Count == 0) Exit = true;
                                    else
                                    {
                                        _currState = _stack.Pop();

                                    }

                                    
                                }
                                else
                                {
                                    _currState = condition.SP.NotEquel.State;
                                    _stack.Push(condition.SP.NotEquel.Stack);
                                }
                                incCounter = false;
                                break;
                            }
                        }
                    }
                    ///////////////////////////вот тут
                }
                if (incCounter == false) incCounter = true; else counter++;


            }

            if(Exit!=true)
            {
                Error = "Error " + rezultTable[counter-1].lexem + " " + rezultTable[counter-1].row;
            }

        }

        private void Equel(Condition condition)
        {
            if (condition.NextState != "")
            {
                if (condition.Stack != "")
                    _stack.Push(condition.Stack);
                _currState = condition.NextState;
                //Console.WriteLine(condition.Lexem + " "+condition.State);

                
            }
            else
            {
                if(condition.SP.Equel.State=="Ex")
                {
                        if(_stack.Count==0) Exit = true; else _currState = _stack.Pop();
                }
                else
                {
                    Error = "Ошибка автомата " + condition.State;
                }
            }
        }

    }
}
