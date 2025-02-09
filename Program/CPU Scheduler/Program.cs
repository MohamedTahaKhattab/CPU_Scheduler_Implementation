using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace os_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C: \Users\Mohamed\source\repos\CPU Scheduler\CPU Scheduler\Inputs.txt";
            int method = 0, i = 0;
            double tati_sum = 0, wi_sum = 0, idle_sum = 0;
            schedule_class sch_object = new schedule_class();
            List<process_class> output;
            List<process_class> input;
            input = sch_object.Read_file(path);
            Console.WriteLine("enter schedule method:fcfs=0;;HPF-non=1;;HPF-PRE=2;;SJF-NON=3;;SRTF-PRE=4;;RR=5");
            method = int.Parse(Console.ReadLine());
            switch (method)
            {
                case 0:
                    output = sch_object.fcfs(input);
                    foreach (process_class c in output)
                    {

                        tati_sum += c.TATi(c);
                        wi_sum += c.W(c);
                    }
                    foreach (double idle in sch_object.idle)
                    {
                        idle_sum += idle;
                        i++;
                    }

                    foreach (process_class c in output)
                    {
                        Console.WriteLine("            id = {0}         ", c.id);
                        Console.WriteLine(" ai = {0} ::brust = {1} ::priority = {2}", c.ai, c.initial_brust, c.priorty);
                        Console.WriteLine(" fi = {0} ::TATi = {1} ::Wi = {2} ", c.fi, c.TATi(c), c.W(c));
                        Console.WriteLine("     ****************    ");

                    }
                    Console.WriteLine("CPU_utilization = " + sch_object.CPU_u(sch_object.Ti, idle_sum) + " % ");
                    Console.WriteLine("ATAT = " + sch_object.ATAT(tati_sum, output.Count));
                    Console.WriteLine("AWI = " + sch_object.AWI(wi_sum, output.Count));
                    Console.WriteLine("context switch = " + sch_object.clk);
                    break;
                case 1:
                    output = sch_object.HPF_nonpreemptive(input);
                    foreach (process_class c in output)
                    {

                        tati_sum += c.TATi(c);
                        wi_sum += c.W(c);
                    }
                    foreach (double idle in sch_object.idle)
                    {
                        idle_sum += idle;
                        i++;
                    }

                    foreach (process_class c in output)
                    {
                        Console.WriteLine("            id = {0}         ", c.id);
                        Console.WriteLine(" ai = {0} ::brust = {1} ::priority = {2}", c.ai, c.initial_brust, c.priorty);
                        Console.WriteLine(" fi = {0} ::TATi = {1} ::Wi = {2} ", c.fi, c.TATi(c), c.W(c));
                        Console.WriteLine("     ****************    ");

                    }
                    Console.WriteLine("CPU_utilization = " + sch_object.CPU_u(sch_object.Ti, idle_sum) + " % ");
                    Console.WriteLine("ATAT = " + sch_object.ATAT(tati_sum, output.Count));
                    Console.WriteLine("AWI = " + sch_object.AWI(wi_sum, output.Count));
                    Console.WriteLine("context switch = " + sch_object.clk);
                    break;
                case 2:
                    output = sch_object.HPF_preemptive(input);
                    foreach (process_class c in output)
                    {

                        tati_sum += c.TATi(c);
                        wi_sum += c.W(c);
                    }
                    foreach (double idle in sch_object.idle)
                    {
                        idle_sum += idle;
                        i++;
                    }

                    foreach (process_class c in output)
                    {
                        Console.WriteLine("            id = {0}         ", c.id);
                        Console.WriteLine(" ai = {0} ::brust = {1} ::priority = {2}", c.ai, c.initial_brust, c.priorty);
                        Console.WriteLine(" fi = {0} ::TATi = {1} ::Wi = {2} ", c.fi, c.TATi(c), c.W(c));
                        Console.WriteLine("     ****************    ");

                    }
                    Console.WriteLine("CPU_utilization = " + sch_object.CPU_u(sch_object.Ti, idle_sum) + " % ");
                    Console.WriteLine("ATAT = " + sch_object.ATAT(tati_sum, output.Count));
                    Console.WriteLine("AWI = " + sch_object.AWI(wi_sum, output.Count));
                    Console.WriteLine("context switch = " + sch_object.clk);
                    break;
                case 3:
                    output = sch_object.SJF_nonpreemptive(input);
                    foreach (process_class c in output)
                    {

                        tati_sum += c.TATi(c);
                        wi_sum += c.W(c);
                    }
                    foreach (double idle in sch_object.idle)
                    {
                        idle_sum += idle;
                        i++;
                    }

                    foreach (process_class c in output)
                    {
                        Console.WriteLine("            id = {0}         ", c.id);
                        Console.WriteLine(" ai = {0} ::brust = {1} ::priority = {2}", c.ai, c.initial_brust, c.priorty);
                        Console.WriteLine(" fi = {0} ::TATi = {1} ::Wi = {2} ", c.fi, c.TATi(c), c.W(c));
                        Console.WriteLine("     ****************    ");

                    }
                    Console.WriteLine("CPU_utilization = " + sch_object.CPU_u(sch_object.Ti, idle_sum) + " % ");
                    Console.WriteLine("ATAT = " + sch_object.ATAT(tati_sum, output.Count));
                    Console.WriteLine("AWI = " + sch_object.AWI(wi_sum, output.Count));
                    Console.WriteLine("context switch = " + sch_object.clk);
                    break;
                case 4:
                    output = sch_object.SRTF_preemptive(input);
                    foreach (process_class c in output)
                    {

                        tati_sum += c.TATi(c);
                        wi_sum += c.W(c);
                    }
                    foreach (double idle in sch_object.idle)
                    {
                        idle_sum += idle;
                        i++;
                    }

                    foreach (process_class c in output)
                    {
                        Console.WriteLine("            id = {0}         ", c.id);
                        Console.WriteLine(" ai = {0} ::brust = {1} ::priority = {2}", c.ai, c.initial_brust, c.priorty);
                        Console.WriteLine(" fi = {0} ::TATi = {1} ::Wi = {2} ", c.fi, c.TATi(c), c.W(c));
                        Console.WriteLine("     ****************    ");

                    }
                    Console.WriteLine("CPU_utilization = " + sch_object.CPU_u(sch_object.Ti, idle_sum) + " % ");
                    Console.WriteLine("ATAT = " + sch_object.ATAT(tati_sum, output.Count));
                    Console.WriteLine("AWI = " + sch_object.AWI(wi_sum, output.Count));
                    Console.WriteLine("context switch = " + sch_object.clk);
                    break;
                case 5:
                    Console.WriteLine("enter quantam");
                    double Q = double.Parse(Console.ReadLine());
                    output = sch_object.RR(input, Q);
                    foreach (process_class c in output)
                    {

                        tati_sum += c.TATi(c);
                        wi_sum += c.W(c);
                    }
                    foreach (double idle in sch_object.idle)
                    {
                        idle_sum += idle;
                        i++;
                    }

                    foreach (process_class c in output)
                    {
                        Console.WriteLine("            id = {0}         ", c.id);
                        Console.WriteLine(" ai = {0} ::brust = {1} ::priority = {2}", c.ai, c.initial_brust, c.priorty);
                        Console.WriteLine(" fi = {0} ::TATi = {1} ::Wi = {2} ", c.fi, c.TATi(c), c.W(c));
                        Console.WriteLine("     ****************    ");

                    }
                    Console.WriteLine("CPU_utilization = " + sch_object.CPU_u(sch_object.Ti, idle_sum) + " % ");
                    Console.WriteLine("ATAT = " + sch_object.ATAT(tati_sum, output.Count));
                    Console.WriteLine("AWI = " + sch_object.AWI(wi_sum, output.Count));
                    Console.WriteLine("context switch = " + sch_object.clk);
                    break;
            }





            Console.ReadLine();
        }
    }
}

