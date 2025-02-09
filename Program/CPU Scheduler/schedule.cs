using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace os_project
{
    internal class schedule_class:process_class
    {
        Comparison<process_class> aisort = new Comparison<process_class>(ai_sort);
        Comparison<process_class> brustsort = new Comparison<process_class>(brust_sort);
        Comparison<process_class> priortysort = new Comparison<process_class>(priorty_sort);
       public double Ti = 0;
        public int clk = 0;
      public List<double>idle= new List<double>();
        public List<process_class> fcfs(List<process_class> process )
        {
            
            int z = 0;
            process.Sort(aisort);
            clk = -1;
            foreach (process_class c in process)
            {
                clk++;
                c.initial_brust = c.brust;
            }
            for (int i = 0; i < process.Count; i++)
            {
               
               // process[i].wi=process[i].brust;
                if (process[i].ai > Ti)
                {
                    idle.Add(process[i].ai - Ti);
                    z=idle.Count-1;
                    Ti += idle[z];
                }
                Ti += process[i].brust;
                process[i].fi = Ti;
            }
            return process;
        }
        public List<process_class> HPF_nonpreemptive(List<process_class> process)
        {
            int f=0,i=0;
            process = new List<process_class>(process);
            List<process_class> RQ = new List<process_class>();
            List<process_class> sch = new List<process_class>();
            process.Sort(aisort);
            clk = 0;
            foreach (process_class c in process)
            {
                c.initial_brust = c.brust;
            }
            while (process.Count > 0)
            {
               // process[0].wi=process[0].brust;
                if (process[0].ai > Ti && RQ.Count > 0)
                {
                    while (RQ.Count > 0 && process[0].ai > Ti)
                    {
                        clk++;
                        sch.Add(RQ[0]);
                        f = sch.Count - 1;
                        Ti += sch[f].brust;// timerبنجدد ال 
                        sch[f].fi = Ti;
                        RQ.RemoveAt(0);

                    }
                
                }
                else if (process[0].ai > Ti && RQ.Count <= 0)
                {
                    idle.Add(process[0].ai - Ti);
                    Ti += idle[i++];
                }
                else if (process[0].ai <= Ti && sch.Count <= 0)
                {
                    //clk++;
                    sch.Add(process[0]);
                    f = sch.Count - 1;
                    Ti += sch[f].brust;
                   // sch[f].wi += sch[f].brust;
                    sch[f].fi = Ti;
                    process.RemoveAt(0);
                }
                else if (process[0].ai <= Ti)
                {
                    RQ.Add(process[0]);
                    RQ.Sort(priortysort);
                    RQ.Reverse();
                    process.RemoveAt(0);

                }
            }

            if (process.Count <= 0)
            {
                while (RQ.Count > 0)
                {
                    clk ++;
                    sch.Add(RQ[0]);
                    f = sch.Count - 1;
                    Ti += sch[f].brust;
                    sch[f].fi = Ti;
                    RQ.Remove(RQ[0]);

                }
            }

            return sch;
        }
        public List<process_class> HPF_preemptive(List<process_class> process) 
        {
            int f = 0, i = 0;
            clk=0;
            process = new List<process_class>(process);
            List<process_class> RQ = new List<process_class>();
            List<process_class> sch = new List<process_class>();
     //   double[] brust = new double[100];
        process.Sort(aisort);

            foreach (process_class c in process)
            {
                c.initial_brust = c.brust;
            }
            while (process.Count > 0)
            {
              // process[0].wi = process[0].brust;
                if (process[0].ai > Ti && RQ.Count > 0)
                {
                    while (RQ.Count > 0 && process[0].ai > Ti)
                    {
                        clk++;
                        sch.Add(RQ[0]);
                        f = sch.Count - 1;
                     //  sch[f].wi += sch[f].brust;
                        Ti += sch[f].brust;
                        sch[f].fi = Ti;
                        RQ.RemoveAt(0);

                    }
                    // lol = 0;
                }
                else if (process[0].ai > Ti && RQ.Count <= 0)
                {
                    idle.Add(process[0].ai - Ti);
                    Ti += idle[i++];
                }
                else if (process[0].ai <= Ti && sch.Count <= 0)
                {
                    sch.Add(process[0]);
                    f = sch.Count - 1;
                    Ti += sch[f].brust;
               //    sch[f].wi = sch[f].brust;
                    sch[f].fi = Ti;
                    process.RemoveAt(0);
                }
                else if (process[0].ai <= Ti && process[0].priorty > sch[f].priorty)
                {
                    clk++;
            //   sch[f].wi = sch[f].brust;
                    sch[f].brust = Ti - process[0].ai;
                    Ti -= sch[f].brust;
                    sch[f].fi = Ti;
                    RQ.Add(sch[f]);
                    RQ.Sort(priortysort);
                    RQ.Reverse();
                    sch.Add(process[0]);
                    f = sch.Count - 1;
              //      sch[f].wi = sch[f].brust;
                    Ti += sch[f].brust;
                    sch[f].fi = Ti;
                    process.RemoveAt(0);
                }
                else if (process[0].ai <= Ti && process[0].priorty < sch[f].priorty)
                {
               //   process[0].wi = process[0].brust;
                    RQ.Add(process[0]);
                    RQ.Sort(priortysort);
                    RQ.Reverse();
                    process.RemoveAt(0);

                }

            }
            if (process.Count <= 0)
            {
                while (RQ.Count > 0)
                {
                    clk++;
                    sch.Add(RQ[0]);
                    f = sch.Count - 1;
                //  sch[f].wi = sch[f].brust;
                    Ti += sch[f].brust;//احنا بنجدد ال 
                    sch[f].fi = Ti;
                    RQ.Remove(RQ[0]);

                }
            }
            return sch;
        }
        public List<process_class> SJF_nonpreemptive(List<process_class> process) 
        {
            int f = 0, i = 0;
            process = new List<process_class>(process);
            List<process_class> RQ = new List<process_class>();
            List<process_class> sch = new List<process_class>();
            process.Sort(aisort);
            clk = 0;

            foreach (process_class c in process)
            {
                c.initial_brust = c.brust;
            }
            while (process.Count > 0)
            {
                if (process[0].ai > Ti && RQ.Count > 0)
                {
                    while (RQ.Count > 0 && process[0].ai > Ti)
                    {
                        clk++;
                        sch.Add(RQ[0]);
                        f = sch.Count - 1;
                        Ti += sch[f].brust;//احنا بنجدد ال 
                        sch[f].fi = Ti;
                        RQ.RemoveAt(0);

                    }
                    // lol = 0;
                }
                else if (process[0].ai > Ti && RQ.Count <= 0)
                {
                    idle.Add(process[0].ai - Ti);
                    Ti += idle[i++];
                }
                else if (process[0].ai <= Ti && sch.Count <= 0)
                {
                   
                    sch.Add(process[0]);
                    f = sch.Count - 1;
                    Ti += sch[f].brust;
                    sch[f].initial_brust += sch[f].brust;
                    sch[f].fi = Ti;

                    process.RemoveAt(0);
                }
                else if (process[0].ai <= Ti)
                {
                    RQ.Add(process[0]);
                    RQ.Sort(brustsort);
                    process.RemoveAt(0);

                }
            }

            if (process.Count <= 0)
            {
                while (RQ.Count > 0)
                {
                    clk++;
                    sch.Add(RQ[0]);
                    f = sch.Count - 1;
                    Ti += sch[f].brust;//احنا بنجدد ال 
                    sch[f].fi = Ti;
                    RQ.Remove(RQ[0]);

                }
            }
            return sch;
        }
        public List<process_class> SRTF_preemptive(List<process_class> process)
        {
            int f = 0, i = 0;
            clk=0;
            process = new List<process_class>(process);
            List<process_class> RQ = new List<process_class>();
            List<process_class> sch = new List<process_class>();
            process.Sort(aisort);
            foreach(process_class c in process)
            {
                c.initial_brust = c.brust;
            }
            while (process.Count > 0)
            {
                if (process[0].ai > Ti && RQ.Count > 0)
                {
                    while (RQ.Count > 0 && process[0].ai > Ti)
                    {
                        clk++;
                        sch.Add(RQ[0]);
                        f = sch.Count - 1;
                       // sch[f].wi = sch[f].brust;
                        Ti += sch[f].brust;//احنا بنجدد ال
                        sch[f].fi = Ti;
                        RQ.RemoveAt(0);

                    }
                    // lol = 0;
                }
                else if (process[0].ai > Ti && RQ.Count <= 0)
                {
                    idle.Add(process[0].ai - Ti);
                    Ti += idle[i++];
                }
                else if (process[0].ai <= Ti && sch.Count <= 0)
                {
                    sch.Add(process[0]);
                    f = sch.Count - 1;
                    Ti += sch[f].brust;
                    //sch[f].wi = sch[f].brust;
                    sch[f].fi = Ti;

                    process.RemoveAt(0);
                }
                else if (process[0].ai <= Ti && process[0].brust < sch[f].brust)
                {
                    clk++;
                  // sch[f].wi +=  (Ti - process[0].ai);
                    sch[f].brust = Ti - process[0].ai;
                    Ti -= sch[f].brust;
                    sch[f].fi = Ti;
                    RQ.Add(sch[f]);
                    RQ.Sort(brustsort);
                    sch.Add(process[0]);
                    f = sch.Count - 1;
                    //sch[f].wi = sch[f].brust;
                    Ti += sch[f].brust;
                    sch[f].fi = Ti;
                    process.RemoveAt(0);
                }
                else if (process[0].ai <= Ti && process[0].brust > sch[f].brust)
                {
                    RQ.Add(process[0]);
                    RQ.Sort(brustsort);
                    process.RemoveAt(0);

                }
            }

            if (process.Count <= 0)
            {
                while (RQ.Count > 0)
                {
                    clk++;
                    sch.Add(RQ[0]);
                    f = sch.Count - 1;
                    Ti += sch[f].brust;//احنا بنجدد ال 
                    sch[f].fi = Ti;
                    RQ.Remove(RQ[0]);

                }
            }

            return sch;
        }
        public List<process_class> RR(List<process_class> process,double qu)
        {
            int f = 0, i = 0;
            clk = 0;
            process= new List<process_class>(process);
            List<process_class> RQ = new List<process_class>();
            List<process_class> sch = new List<process_class>();
          
            process.Sort(aisort);
            foreach (process_class c in process)
            {
                c.initial_brust = c.brust;
            }

            do
            {
                
                if (process.Count == 0 && RQ.Count != 0)
                {
                    if (RQ[0].brust < qu)
                    {
                       clk++;
                        Ti += RQ[0].brust;                   
                        RQ[0].brust = 0;
                        sch.Add(RQ[0]);
                        f = sch.Count - 1;
                        sch[f].fi = Ti;
                        RQ.RemoveAt(0);
                    }
                    else
                    {
                        clk++;
                        sch.Add(RQ[0]);
                        RQ.RemoveAt(0);
                        f = sch.Count - 1;
                        sch[f].brust -= qu;
                        Ti += qu;
                        if (sch[f].brust == 0)
                        {
                            sch[f].fi = Ti;
                        }
                        else
                        {
                            RQ.Add(sch[f]);
                        }
                    }
                }
                else
                {
                    if (RQ.Count == 0 && process[0].ai > Ti)  // Case 1     (Idle)
                    {
                        idle.Add(process[0].ai - Ti);
                        Ti += idle[i++];
                    }
                    else if (RQ.Count != 0 && process[0].ai > Ti) // Case 2 (There are no processes that can be used to enter the processor and the RQ is not empty)
                    {
                        if (RQ[0].brust < qu)
                        {
                            clk++;
                            Ti += RQ[0].brust;
                            RQ[0].brust = 0;
                            sch.Add(RQ[0]);
                            f = sch.Count - 1;
                            sch[f].fi = Ti;
                            RQ.RemoveAt(0);
                        }
                        else
                        {
                            clk++;
                            sch.Add(RQ[0]);
                            RQ.RemoveAt(0);
                            f = sch.Count - 1;
                            sch[f].brust -= qu;
                            Ti += qu;
                            if (sch[f].brust == 0)
                            {
                                sch[f].fi = Ti;
                            }
                            else
                            {
                                RQ.Add(sch[f]);
                            }
                        }
                    }

                    else if (process[0].ai <= Ti) // Case 3 (There are processes that can be used to enter the processor)
                    {
                        if (process[0].brust < qu)
                        {
                            //clk++;
                            Ti += process[0].brust;
                            process[0].brust = 0;
                            sch.Add(process[0]);
                            f = sch.Count - 1;
                            sch[f].fi = Ti;
                            process.RemoveAt(0);
                        }
                        else
                        {
                            clk++;
                            sch.Add(process[0]);
                            f = sch.Count - 1;
                            sch[f].brust -= qu;
                            Ti += qu;
                            if (sch[f].brust == 0)
                            {
                                sch[f].fi = Ti;
                            }
                            else
                            {
                                RQ.Add(sch[f]);
                            }
                            process.RemoveAt(0);
                        }
                    }
                }
            } while (process.Count != 0 || RQ.Count != 0); // Case 4  (RQ & process is not empty)

            return sch;
        }

        public double ATAT(double ATAT,int no) 
        {
            double atat=ATAT/no;
            return atat;
        }
        public double AWI(double AWI, int no)
        {
            double awi = AWI / no;
            return awi;
        }
        public double CPU_u(double ti, double idle)
        {
            double cpu_u = ((ti-idle) /ti)*100;
            return cpu_u;
        }
        //public int Context_switch(int clk)
        //{
        //    return clk;
        //}
        public List<process_class> Read_file(string path)
        {
            StreamReader sr = new StreamReader(path);
            string str1 = sr.ReadLine();
            int NumberOfProcesses = int.Parse(str1);
            string[] Line = new string[NumberOfProcesses];
            List<process_class> process = new List<process_class>(NumberOfProcesses);
            //{
            //    new process_class() { id = 1, ai = 0, brust = 5, priorty = 2 },
            //    new process_class() { id = 2, ai = 1, brust = 7, priorty = 3 },
            //    new process_class() { id = 3, ai = 2, brust = 3, priorty = 6 },
            //    new process_class() { id = 4, ai = 3, brust = 4, priorty = 4 },
            //    new process_class() { id = 4, ai = 3, brust = 4, priorty = 4 },
            //};

            for (int i = 0; i < NumberOfProcesses; i++)
            {
                Line[i] = sr.ReadLine();
                string[] Values = Line[i].Split(' ');
                //new process_class() { id = int.Parse(Values[0]), ai = double.Parse(Values[1]), brust = double.Parse(Values[2]), priorty = double.Parse(Values[3]) };
                //process[i].Add();
                process.Add(new process_class
                {
                    id = int.Parse(Values[0]),
                    ai = double.Parse(Values[1]),
                    brust = double.Parse(Values[2]),
                    priorty = double.Parse(Values[3])
                });
            }
            return process;

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////

        }
    
    }


}
