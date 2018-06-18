using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LA_Shtokal;

namespace SA.Data
{
    class LexemTable:LA_Shtokal.LexemTable
    {
        public LexemTable()
        {
            Init();
        }

        private int Init()
        {
            this.AddLex("Програма");
            this.AddLex("змінні");
            this.AddLex("початок");
            this.AddLex("кінець");
            this.AddLex("ціле");
            this.AddLex("дійсне");
            this.AddLex("символ");
            this.AddLex("логічне");
            this.AddLex("для");
            this.AddLex("якщо");
            this.AddLex("інакше");
            this.AddLex("читати");
            this.AddLex("писати");
            this.AddLex("або");
            this.AddLex("та");
            this.AddLex(";");
            this.AddLex(":");
            this.AddLex(",");
            this.AddLex("(");
            this.AddLex(")");
            this.AddLex("[");
            this.AddLex("]");
            this.AddLex("{");
            this.AddLex("}");
            this.AddLex("=");
            this.AddLex("+");
            this.AddLex("-");
            this.AddLex("*");
            this.AddLex("/");
            this.AddLex("^");
            this.AddLex("?");
            this.AddLex(">");
            this.AddLex("<");
            this.AddLex(">=");
            this.AddLex("<=");
            this.AddLex("==");
            this.AddLex("!");
            this.AddLex("!=");
            this.AddLex("id");
            int count = this.AddLex("const");
            return count;
        }
    }
}
