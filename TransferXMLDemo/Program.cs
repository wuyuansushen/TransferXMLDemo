using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;

namespace TransferXMLDemo
{
    class Student
    {
        public string First { get; set; }
        public string Last { get; set; }
        public int ID { get; set; }
        public List<int> Scores { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>()
            {
            new Student() {First="Svetlana", Last="Omelchenko", ID=111, Scores = new List<int>{97, 92, 81, 60}},
            new Student() {First="Claire", Last="O’Donnell", ID=112, Scores = new List<int>{75, 84, 91, 39}},
            new Student() {First="Sven", Last="Mortensen", ID=113, Scores = new List<int>{88, 94, 65, 91}}
            };

            //Equivalent query syntax

            //Query syntax
            var studentsToXML = new XElement("Class",
                from student in students
                let scores=string.Join(",",student.Scores)
                select new XElement("student",
                new XElement("First",student.First),
                new XElement("Last",student.Last),
                new XElement("Scores",scores))
                );
            studentsToXML.Save("./../../../studentsQuerySyntax.xml");

            //Method syntax
            var studentsToXMLMethodSyntax = new XElement("Class",
                students.Select(student => {
                    var scores = string.Join(",", student.Scores);
                    return new XElement("student",
                        new XElement("First", student.First),
                        new XElement("Last", student.Last),
                        new XElement("Scores",scores)
                        );
                    })
                );
            studentsToXMLMethodSyntax.Save("./../../../studentsMethodSyntax.xml");
        }
    }
}
