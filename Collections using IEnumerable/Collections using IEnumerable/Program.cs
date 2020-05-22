using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections_using_IEnumerable
{
    class Student
    {
        public int Id { get; set; }

        public String name { get; set; }
        public String blood_group { get; set; }
        public String hometown { get; set; }
    }
    class collection :IEnumerable
    {
        List<Student> stu = new List<Student>();
         public void Add(Student st)
        {
            stu.Add(st);
        }
        public int count
        {
            get
            {
                return stu.Count;
            }
        }
        public Student this[int index]
        {
            get
            {
                return stu[index];
            }
        }
        public IEnumerator GetEnumerator()
        {
            //return stu.GetEnumerator();
            return new collectionenumerator(this);
        }
    }
   class collectionenumerator : IEnumerator

    {
        collection co;
        public int currentindex=-1;
        Student currentstudent;
        public collectionenumerator(collection c)
        {
            co = c;
        }
        public object Current
        {
            get
            {
             return currentstudent;
            }
        }
        public bool MoveNext()
        {
            if (++currentindex >= co.count)
            {
                return false;
            }
            else
                currentstudent = co[currentindex];
            return true;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            collection coll = new collection();

            coll.Add(new Student() { Id = 101, name = "Karthik", blood_group = "APositive", hometown = "chennai" });
            coll.Add(new Student() { Id = 102, name = "jessi", blood_group = "ANegative", hometown = "Kanchipuram" });
            coll.Add(new Student() { Id = 103, name = "varun", blood_group = "BPositive", hometown = "coimbatore" });
            coll.Add(new Student() { Id = 104, name = "nithya", blood_group = "OPositive", hometown = "Madurai" });
            coll.Add(new Student() { Id = 105, name = "sai", blood_group = "A1BNegative", hometown = "chennai" });
           

            foreach(Student student in coll)
            {
                Console.WriteLine(student.Id + " "+ student.name + " " + student.blood_group +" " +student.hometown);
            }

        }
    }
}
