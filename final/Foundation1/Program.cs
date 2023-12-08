using System;
using System.Collections.Generic;

public class Comment
{
    public string _name;
    public string _text;

    public string  GetName()
    {
        return _name;
    }

    public string  GetText()
    {
        return _text;
    }

}

public class Video
{
    public string _title ;
    public string _author;
    public int _length;

    public List<Comment> _comments = new List<Comment>();


    public string GetTitle()
    {
        return _title;
    }

    public string GetAuthor()
    {
        return _author;
    }

    public int GetLength()
    {
        return _length;
    }

    public string DisplayVideoInformation()
    {
        return $"The title is {_title} by author called {_author} and length is {_length} seconds with {_comments.Count} comments.";
    }

}

class Program
{
    static void Main(string[] args)
    {
        Comment comment1 = new Comment();
        comment1._name = "abel";
        comment1._text = "its amazing";

        Comment comment2 = new Comment();
        comment2._name = "silver";
        comment2._text = "its the best";

        Comment comment3 = new Comment();
        comment3._name = "godfrey";
        comment3._text = "its perfect";

        Video video1 = new Video();
        video1._comments.Add(comment1);
        video1._comments.Add(comment2);
        video1._comments.Add(comment3);
        video1._author = "john";
        video1._title = "no retreat no surrender";
        video1._length = 40;

        Comment comment21 = new Comment();
        comment21._name = "ray";
        comment21._text = "its blur";

        Comment comment22 = new Comment();
        comment22._name = "dasilver";
        comment22._text = "its fair";

        Comment comment23 = new Comment();
        comment23._name = "fred";
        comment23._text = "its bearable";

        Video video2 = new Video();
        video2._comments.Add(comment21);
        video2._comments.Add(comment22);
        video2._comments.Add(comment23);
        video2._author = "wick";
        video2._title = "payback";
        video2._length = 30;
        
        Comment comment31 = new Comment();
        comment31._name = "xu";
        comment31._text = "wang fei";

        Comment comment32 = new Comment();
        comment32._name = "bond";
        comment32._text = "i love it";

        Comment comment33 = new Comment();
        comment33._name = "franco";
        comment33._text = "wonderful";

        Video video3 = new Video();
        video3._comments.Add(comment31);
        video3._comments.Add(comment32);
        video3._comments.Add(comment33);
        video3._author = "suzuki";
        video3._title = "samurai";
        video3._length = 45;

        List<Video> _videoinfo = new List<Video>();
        _videoinfo.Add(video1);
        _videoinfo.Add(video2); 
        _videoinfo.Add(video3);  

        foreach (Video video in _videoinfo)
        {
            Console.WriteLine(video.DisplayVideoInformation());
        }
    }
}