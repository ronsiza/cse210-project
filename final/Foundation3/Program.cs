using System;

public class Program
{
    static void Main(string[] args)
    {
        Lecture lecture = new Lecture();
        lecture.AssignTitle("Lecture");
        lecture.AssignDescription("healthy based");
        lecture.AssignDate("22-April-2023");
        lecture.AssignTime("9:00am");
        lecture.AssignSpeakerName("DR kenobi");

        Reception reception = new Reception();
        reception.AssignTitle("Reception");
        reception.AssignDescription("king's return");
        reception.AssignDate("12-June-2023");
        reception.AssignTime("12:00pm");
        reception.AssignRsvpEmail("busogakingdom@gmail.com");

        OutdoorGathering outdoorGathering = new OutdoorGathering();
        outdoorGathering.AssignTitle("Outdoor Gathering");
        outdoorGathering.AssignDescription("regional marathon");
        outdoorGathering.AssignDate("02-Sept-2023");
        outdoorGathering.AssignTime("08:00am");


        Console.WriteLine(lecture.GenerateLectureMessage());

        Console.WriteLine(reception.GenerateReceptionMessage());
        
        Console.WriteLine(outdoorGathering.GenerateOutdoorMessage());

        
    }

}