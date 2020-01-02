using System;

namespace ConsoleApp1
{
    public class PolynomeEventArgs
    {
        public string Message { get; }
    }

    public class Polynome : IComparable, ICloneable
    {
        //Fields
        private int[] body;
        private int degree;

        //Constructor
        public Polynome()
        {

        }
        public Polynome(int deg)
        {
            this.degree = deg;
            this.body = new int[deg];
        }
        public Polynome(int[] body)
        {
            if (body != null)
            {
                this.body = (int[])body.Clone();
                this.degree = body.Length;
                CheckAndCutFirstElement();
            }
            else
            {
                throw new ArgumentException($"Container is corrupted");
            }
        }

        //Indexer
        public int this[int n]
        {
            get
            {
                return this.body[n];
            }
            set
            {
                if (n == 0 && value == 0 && this.degree > 1)
                {
                    throw new ArgumentException($"You tried to set 1st element to ZERO");
                }
                else
                {
                    this.body[n] = value;
                    CheckAndCutFirstElement();
                }
            }

        }
        public void Ramdomize(int a, int b)
        {
            Random rnd = new Random();
            for (int n = 0; n < this.degree; n++)
            {
                    this.body[n] = (int)rnd.Next(a, b);
            }
            CheckAndCutFirstElement();
        }
        public int Degree()
        {
            return this.degree;
        }

        //Operations override
        public static Polynome operator +(Polynome A, Polynome B)
        {
            Polynome result = new Polynome();
            if (A.CompareTo(B) >= 0)
            {
                Array.Reverse(A.body);
                Array.Reverse(B.body);
                result = (Polynome)A.Clone();
                for (int m = 0;  m < B.degree; m++)
                {
                    result.body[m] = A.body[m] + B.body[m];
                }
                Array.Reverse(A.body);
                Array.Reverse(B.body);
                Array.Reverse(result.body);
            }
            else
            {
                Array.Reverse(A.body);
                Array.Reverse(B.body);
                result = (Polynome)B.Clone();
                for (int m = 0; m < A.degree; m++)
                {
                    result.body[m] = A.body[m] + B.body[m];
                }
                Array.Reverse(A.body);
                Array.Reverse(B.body);
                Array.Reverse(result.body);
            }
            if (A.degree == B.degree)
            {
                result.CheckAndCutFirstElement();
            }
            return result;

        }
        public static Polynome operator -(Polynome A, Polynome B)
        {
            Polynome result = new Polynome();
            if (A.CompareTo(B) >= 0)
            {
                Array.Reverse(A.body);
                Array.Reverse(B.body);
                result = (Polynome)A.Clone();
                for (int m = 0; m < B.degree; m++)
                {
                    result.body[m] = A.body[m] - B.body[m];
                }
                Array.Reverse(A.body);
                Array.Reverse(B.body);
                Array.Reverse(result.body);
            }
            else
            {
                Array.Reverse(A.body);
                Array.Reverse(B.body);
                result = (Polynome)B.Clone();
                for (int m = 0; m < A.degree; m++)
                {
                    result.body[m] = A.body[m] - B.body[m];
                }
                Array.Reverse(A.body);
                Array.Reverse(B.body);
                Array.Reverse(result.body);
            }
            if (A.degree == B.degree)
            {
                result.CheckAndCutFirstElement();
            }
            return result;
        }
        public static Polynome operator *(Polynome A, Polynome B)
        {
            Polynome result = new Polynome(A.Degree()+B.Degree()-1);
            for (int i = 0; i < A.degree; i++)
            {
                for(int j = 0; j < B.degree; j++)
                {
                    result.body[i + j] = result.body[i + j] + A.body[i] * B.body[j];
                }
            }
            return result;
        }
        public static Polynome operator *(int A, Polynome B)
        {
            Polynome result = new Polynome(B.Degree());
                for (int j = 0; j < B.degree; j++)
                {
                    result.body[j] = A * B.body[j];
                }
            return result;
        }
        //public static Polynome operator /(Polynome A, Polynome B)
        //{
        //    if (A.CompareTo(B) >= 0)
        //    {
        //        Polynome result = new Polynome(A.Degree() - B.Degree() + 1);
        //        for (int i = 0; i < A.degree; i++)
        //        {
        //            for (int j = 0; j < B.degree; j++)
        //            {
        //                result.body[i - j] = result.body[i - j] + A.body[i] * B.body[j];
        //            }
        //        }
        //        return result;
        //    }
        //    else
        //    {
        //        Polynome result = new Polynome(B.Degree() - A.Degree() + 1);
        //        for (int i = 0; i < A.degree; i++)
        //        {
        //            for (int j = 0; j < B.degree; j++)
        //            {
        //                result.body[i - j] = result.body[i - j] + A.body[i] * B.body[j];
        //            }
        //        }
        //        return result;
        //    }
        //}

        //Clone

        public object Clone()
        {
            return new Polynome(this.body.Clone() as int[]);
        }
        //View
        public void View()
        {
            if (this != null)
            {
                for (int n = 0; n < (this.degree-1); n++)
                {
                    if (this.body[n] != 0)
                    { Console.Write("(" + this.body[n] + ")" + "x^" + (this.degree - n -1) + "+"); }
                    else
                    { continue; }
                }
                if (this.body[this.degree-1] != 0)
                { Console.Write("(" + this.body[this.degree - 1] + ")" + "= 0"); }
                    
                Console.WriteLine();
            }
            else
            {
                throw new ArgumentException($"Container is corrupted");
            }
            Console.WriteLine("====");
        }
        //Proverka na nulevoi perviy element, no pri etom esli dlina vsego 1, to ne udalyat'
        private void CheckAndCutFirstElement()
        {
            if (this.body[0] == 0 && this.body.Length > 1)
            {
                int[] newbody = new int[this.body.Length - 1];
                for (int i = 1; i < this.body.Length; i++)
                {
                    newbody[i - 1] = this.body[i];
                }
                this.body = newbody;
                CheckAndCutFirstElement();
                this.degree = this.body.Length;
                return;
            }
            else
            {
                return;
            }
        }
        //CompareTo
        public int CompareTo(object A)
        {
            Polynome A1 = A as Polynome;
            if (this.degree == A1.degree)
            {
                return 0;
            }
            else
            {
                if (this.degree > A1.degree)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }

    }
}
