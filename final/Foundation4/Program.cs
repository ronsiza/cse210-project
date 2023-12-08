using System;

public class Program
{
    static void Main(string[] args)
    {
        Running runexe = new Running();
        runexe.SetActivityType("Running");
        runexe.SetDate("23-NOV-2023");
        runexe.SetDistance(100);
        runexe.SetSpeed(20);
        runexe.SetPace(13);
        runexe.SetLength(50);

        Cycling cycexe = new Cycling();
        cycexe.SetActivityType("Cycling");
        cycexe.SetDate("23-NOV-2022");
        cycexe.SetLength(30);
        cycexe.SetSpeed(35);
        cycexe.SetDistance(40);

        Swimming swmexe = new Swimming();
        swmexe.SetActivityType("Swimming");
        swmexe.SetDate("23-DEC-2023");
        swmexe.SetLaps(10);
        swmexe.SetDistance(5);
        swmexe.SetLength(38);


        List<Exercise> exercise = new List<Exercise>();
        exercise.Add(runexe);
        exercise.Add(cycexe);
        exercise.Add(swmexe);

        foreach (Exercise exe  in exercise)
        {
            Console.WriteLine(exe.GetSummary());
        }



    }

}