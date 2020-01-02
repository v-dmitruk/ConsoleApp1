using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Student : IComparable
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public int testScore { get; private set; }
        public string testName { get; private set; }
        public DateTime testDate { get; private set; }

        public Student(string n, string sn)
        {
            Name = n;
            Surname = sn;
        }
        public Student(string n, string sn, int sc)
        {
            Name = n;
            Surname = sn;
            testScore = sc;
        }
        public Student(string n, string sn, int sc, string tn)
        {
            Name = n;
            Surname = sn;
            testScore = sc;
            testName = tn;
        }
        public Student(string n, string sn, int sc, string tn, DateTime td)
        {
            Name = n;
            Surname = sn;
            testScore = sc;
            testName = tn;
            testDate = td;
        }

        public void FixName(string newName)
        {
            this.Name = newName;
        }
        public void FixSurname(string newSurname)
        {
            this.Surname = newSurname;
        }
        public void FixScore(int newScore)
        {
            this.testScore = newScore;
        }
        public void FixTestName(string newTestName)
        {
            this.testName = newTestName;
        }
        public void FixTestDate(DateTime newTestDate)
        {
            this.testDate = newTestDate;
        }

        public int CompareTo(object st)
        {
            if (st != null)
            {
                Student st1 = (Student)st;
                if (this.testScore == st1.testScore)
                {
                    return 0;
                }
                else
                {
                    if (this.testScore > st1.testScore)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            else
            {
                throw new ArgumentException("Empty object");
            }

        }

        public override string ToString()
        {
            return Name + "  " + Surname + " - " + testScore + "\n";
        }
    }
}
