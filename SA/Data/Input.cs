using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LA_Shtokal;

namespace SA.Data
{
    class Input
    {
        private readonly LexAnalizShtokal _lAnaliz;
        

        public List<RezultTable> RezultTable
        {
            get { return _lAnaliz.RezultTable; }
        }
        public List<IdentifiersTable> IdTable
        {
            get { return _lAnaliz.IdentifiersTable; }
        }
        public List<ConstTable> ConstTable
        {
            get { return _lAnaliz.ConstTable; }
        }
        public Error Err
        {
            get { return _lAnaliz.Error; }
        }

        private readonly LexemTable _lexemTable;

        public Input(string code)
        {
            _lAnaliz = new LexAnalizShtokal(code);
            _lexemTable = new LexemTable();
        }
    }
}
