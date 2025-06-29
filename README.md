# CPU Scheduler Implementation
This is the first project of the Operating Systems course at the Egyptian Chinese University

## Overview

This project implements six fundamental CPU scheduling algorithms in C# as part of the Operating Systems coursework at the Egyptian Chinese University. The application provides a comprehensive simulation environment for comparing different scheduling strategies and analyzing their performance characteristics.

## Features

The implementation includes the following scheduling algorithms:

**First-Come, First-Served (FCFS)** - Processes are executed in the order of their arrival time, providing a baseline non-preemptive scheduling approach.

**Highest Priority First Non-Preemptive (HPF-NON)** - Selects processes based on priority values without interrupting running processes.

**Highest Priority First Preemptive (HPF-PRE)** - Implements priority-based scheduling with the ability to preempt lower-priority processes when higher-priority ones arrive.

**Shortest Job First Non-Preemptive (SJF-NON)** - Schedules processes based on their burst time duration without preemption capabilities.

**Shortest Remaining Time First Preemptive (SRTF-PRE)** - A preemptive version of SJF that can interrupt processes when shorter jobs arrive.

**Round Robin (RR)** - Implements time-sharing with configurable quantum values for fair process distribution.

## Performance Metrics

The application calculates and displays comprehensive performance statistics for each scheduling algorithm:

**Turnaround Time (TAT)** - The total time from process arrival to completion, calculated as finish time minus arrival time.

**Waiting Time (W)** - The time processes spend waiting in the ready queue, derived from turnaround time minus burst time.

**CPU Utilization** - The percentage of time the CPU remains active, accounting for idle periods in the scheduling timeline.

**Average Turnaround Time (ATAT)** - The mean turnaround time across all processes in the simulation.

**Average Waiting Time (AWI)** - The mean waiting time for all processes in the system.

**Context Switches** - The number of process switches that occur during execution, indicating scheduling overhead.

## Input Format

The system reads process information from a text file with the following structure:

```
6
2 1.2 5 10
3 2.5 4 6
2 2 7 4
1 1 3.5 8
5 12 1.3 15
0 0.2 10 2
```

The first line specifies the number of processes, followed by one line per process containing process ID, arrival time, burst time, and priority value respectively.

## System Requirements

The application targets the .NET Framework 4.7.2 and requires Visual Studio 2017 or later for compilation and execution. The project structure follows standard Visual Studio conventions with separate class files for process management and scheduling logic.

## Usage Instructions

Navigate to the project directory and compile the solution using Visual Studio or the command line tools. Execute the resulting binary and select the desired scheduling algorithm by entering the corresponding number when prompted. For Round Robin scheduling, provide an additional quantum value when requested. The system will process the input file and display detailed results including individual process statistics and overall performance metrics.

## Technical Implementation

The codebase consists of three primary components: the Process class manages individual process attributes and calculations, the Schedule class implements all six scheduling algorithms with their respective logic, and the Program class provides the user interface and orchestrates the scheduling simulation.

The implementation handles edge cases such as process arrival times that exceed the current system time, resulting in CPU idle periods that are tracked and included in utilization calculations. Context switching counts are maintained throughout the simulation to provide insights into scheduling overhead.

## Educational Value

This implementation serves as a practical demonstration of fundamental operating system concepts, allowing students to observe how different scheduling strategies affect system performance under various workload conditions. The comparative analysis capabilities enable comprehensive study of trade-offs between algorithms in terms of fairness, efficiency, and responsiveness.

## File Structure

```
CPU Scheduler/
├── Program.cs          # Main application entry point and user interface
├── process.cs          # Process class definition and utility methods
├── schedule.cs         # Scheduling algorithm implementations
├── Inputs.txt          # Sample process data for testing
└── CPU Scheduler.csproj # Project configuration file
```

## Contributing

This project was developed as an academic exercise for Operating Systems coursework. The implementation provides a solid foundation for understanding CPU scheduling concepts and can be extended with additional algorithms or enhanced visualization capabilities.
