using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace os_project
{
    internal class process_class
    {

        public int id { get; set; }
        public double ai { get; set; }
        public double brust { get; set; }
        public double priorty { get; set; }
        public double fi { get; set; }
        public double initial_brust { get; set; }

        public static int ai_sort(process_class x, process_class y)
        {
            return x.ai.CompareTo(y.ai);
        }
        public static int brust_sort(process_class x, process_class y)
        {
            return x.brust.CompareTo(y.brust);
        }
        public static int priorty_sort(process_class x, process_class y)
        {
            return x.priorty.CompareTo(y.priorty);
        }

        public double TATi(process_class x)
        {
            double TAT;
            TAT = x.fi - x.ai;
            return TAT;
        }

        public double W(process_class x)
        {
            double w;
            w = TATi(x) - x.initial_brust;
            return w;
        }


        Comparison<process_class> aisort = new Comparison<process_class>(ai_sort);
        Comparison<process_class> brustsort = new Comparison<process_class>(brust_sort);
        Comparison<process_class> priortysort = new Comparison<process_class>(priorty_sort);
    }
}
