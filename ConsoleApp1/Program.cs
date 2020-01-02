using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ConsoleApp1 
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Hello world");



                BinaryTree<Student, int> StudentTree = new BinaryTree<Student, int>();
                Student st1 = new Student ("Vasiliy", "Kekovich", 10);
                List<Student> students = new List<Student>();
                students.Add(st1);
                Random rnd = new Random();
                for (int i = 0; i < 100; i++)
                {
                    int sc = rnd.Next(0, 40);
                    string nm = rnd.Next(0, 100).ToString();
                    string snm = rnd.Next().ToString();
                    Student st = new Student(nm, snm, sc);
                    students.Add(st);
                }


            ////Unit for shifted array testing
            {
                //ShiftedArray<Student> example = new ShiftedArray<Student>(students.ToArray());
                //foreach (Student st in example)
                //{
                //    Console.WriteLine(st.Surname);
                //}
                

                //ShiftedArray<Student> example2 = new ShiftedArray<Student>(students.ToArray(), -3);
                //foreach (Student st in example2)
                //{
                //    Console.WriteLine(st.Surname);
                //}
                //try
                //{
                //    Console.WriteLine(example2[12].Surname);
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}
                //try
                //{
                //    Console.WriteLine(example2[3].Surname);
                //    Console.WriteLine(example2[4].Surname);
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}
                //ShiftedArray<Student> example3 = example.Union(example2);
                //try
                //{
                //    Console.WriteLine(example3[3].Surname);
                //    Console.WriteLine(example3[21].Surname);
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}

                //example3.Add(st1);
                //Console.WriteLine(example3[22].Surname);
                //try
                //{
                //    example3.Delete(22);
                //    example3.SetNewStart(1);
                //    example3.Delete(22);
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}
                //try
                //{
                //    Console.WriteLine(example3[20].Surname);
                //    Console.WriteLine(example3[21].Surname);
                //    example3.Add(st1);
                //    Console.WriteLine(example3[22].Surname);
                //    Console.WriteLine(example3[0].Surname);
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}


            }
            

            ////Unit for Binary Tree testing
            {
                foreach (Student el in students)
                {
                    //Console.WriteLine(el.Name + " " + el.Surname + " - " + el.testScore);

                    try
                    {
                        StudentTree.AddNode(el, el.testScore, null, null);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
                Console.WriteLine("===============");

                ////ToString, Find, DeleteNode Testing
                {
                    //    //try
                    //    //{
                    //    //    Console.WriteLine(StudentTree.FindByKey(10, null, null).ToString());
                    //    //}
                    //    //catch (Exception ex)
                    //    //{
                    //    //    Console.WriteLine(ex.Message);
                    //    //}
                    //    //Console.WriteLine("===============");
                    //    //StudentTree.ViewTree(StudentTree.rootNode);
                    //    //try
                    //    //{
                    //    //    Console.WriteLine(StudentTree.FindByKey(15, null, null).ToString());
                    //    //}
                    //    //catch (Exception ex)
                    //    //{
                    //    //    Console.WriteLine(ex.Message);
                    //    //}
                    //    //try
                    //    //{
                    //    //    StudentTree.TreelikePrint(10);
                    //    //}
                    //    //catch (Exception ex)
                    //    //{
                    //    //    Console.WriteLine(ex.Message);
                    //    //}
                    //    //Console.WriteLine("===============");
                    //    //try
                    //    //{
                    //    //    StudentTree.DeleteNode(StudentTree.FindByKey(15, null, null));
                    //    //}
                    //    //catch (Exception ex)
                    //    //{
                    //    //    Console.WriteLine(ex.Message);
                    //    //}
                    //    //try
                    //    //{
                    //    //    Console.WriteLine(StudentTree.FindByKey(15, null, null).ToString());
                    //    //}
                    //    //catch (Exception ex)
                    //    //{
                    //    //    Console.WriteLine(ex.Message);
                    //    //}


                    //    //try
                    //    //{
                    //    //    Console.WriteLine(StudentTree.FindByKey(34, null, null).ToString());
                    //    //}
                    //    //catch (Exception ex)
                    //    //{
                    //    //    Console.WriteLine(ex.Message);
                    //    //}
                    //    //Console.WriteLine("===============");
                    //    //StudentTree.ViewTree(StudentTree.rootNode);
                    //    //try
                    //    //{
                    //    //    StudentTree.TreelikePrint(10);
                    //    //}
                    //    //catch (Exception ex)
                    //    //{
                    //    //    Console.WriteLine(ex.Message);
                    //    //}
                    //    //Console.WriteLine("===============");
                    //    //try
                    //    //{
                    //    //    StudentTree.TreelikePrint(33);
                    //    //}
                    //    //catch (Exception ex)
                    //    //{
                    //    //    Console.WriteLine(ex.Message);
                    //    //}
                }

                ////Treelike Print Testing and Ordering Testing
                {
                    //    //List<Node<Student, int>> leaves = new List<Node<Student, int>>();
                    //    //StudentTree.ForwardOrder(StudentTree.rootNode, leaves);
                    //    //foreach (Node<Student, int> el in leaves)
                    //    //{
                    //    //    Console.Write(el.key + " ");
                    //    //}
                    //    //Console.WriteLine();
                    //    //Console.WriteLine("===============");
                    //    //leaves.Clear();
                    //    //StudentTree.ReverseOrder(StudentTree.rootNode, leaves);
                    //    //foreach (Node<Student, int> el in leaves)
                    //    //{
                    //    //    Console.Write(el.key + " ");
                    //    //}
                    //    //Console.WriteLine();
                    //    //Console.WriteLine("===============");
                    //    //leaves.Clear();
                    //    //StudentTree.ForwardReverseOrder(StudentTree.rootNode, leaves);
                    //    //foreach (Node<Student, int> el in leaves)
                    //    //{
                    //    //    Console.Write(el.key + " ");
                    //    //}
                    //    //Console.WriteLine();
                    //    //Console.WriteLine("===============");
                    //    //leaves.Clear();
                    //    //StudentTree.PreReverseOrder(StudentTree.rootNode, leaves);
                    //    //foreach (Node<Student, int> el in leaves)
                    //    //{
                    //    //    Console.Write(el.key + " ");
                    //    //}
                    //    //Console.WriteLine();
                    //    //Console.WriteLine("===============");
                    //    //try
                    //    //{
                    //    //    StudentTree.DeleteNode(StudentTree.FindByKey(15, null, null));
                    //    //}
                    //    //catch (Exception ex)
                    //    //{
                    //    //    Console.WriteLine(ex.Message);
                    //    //}
                    //    //Console.WriteLine("===============");
                    //    //leaves.Clear();
                    //    //StudentTree.ForwardOrder(StudentTree.rootNode, leaves);
                    //    //foreach (Node<Student, int> el in leaves)
                    //    //{
                    //    //    Console.Write(el.key + " ");
                    //    //}
                    //    //Console.WriteLine();
                    //    //Console.WriteLine("===============");
                    //    //leaves.Clear();
                    //    //StudentTree.ReverseOrder(StudentTree.rootNode, leaves);
                    //    //foreach (Node<Student, int> el in leaves)
                    //    //{
                    //    //    Console.Write(el.key + " ");
                    //    //}
                    //    //Console.WriteLine();
                    //    //Console.WriteLine("===============");
                    //    //leaves.Clear();
                    //    //StudentTree.ForwardReverseOrder(StudentTree.rootNode, leaves);
                    //    //foreach (Node<Student, int> el in leaves)
                    //    //{
                    //    //    Console.Write(el.key + " ");
                    //    //}
                    //    //Console.WriteLine();
                    //    //Console.WriteLine("===============");
                    //    //leaves.Clear();
                    //    //StudentTree.PreReverseOrder(StudentTree.rootNode, leaves);
                    //    //foreach (Node<Student, int> el in leaves)
                    //    //{
                    //    //    Console.Write(el.key + " ");
                    //    //}
                    //    //Console.WriteLine();
                    //    //Console.WriteLine("===============");


                    //    //try
                    //    //{
                    //    //    StudentTree.TreelikePrint(StudentTree.rootNode.key);
                    //    //}
                    //    //catch (Exception ex)
                    //    //{
                    //    //    Console.WriteLine(ex.Message);
                    //    //}
                }
                
                ////BalanceTesting
                {
                    //Console.WriteLine("===============");
                    //List<Node<Student, int>> leaves2 = new List<Node<Student, int>>();
                    //StudentTree.ForwardReverseOrder(StudentTree.rootNode, leaves2);
                    //foreach (Node<Student, int> el in leaves2)
                    //{
                    //    StudentTree.BalanceTree(el);
                    //}
                    //Console.WriteLine("===============");
                    //try
                    //{
                    //    StudentTree.TreelikePrint(StudentTree.rootNode.key);
                    //}
                    //catch (Exception ex)
                    //{
                    //    Console.WriteLine(ex.Message);
                    //}
                    //Console.WriteLine("===============");
                    //StudentTree.rootNode.FixHeight(StudentTree.rootNode);
                    //Console.WriteLine(StudentTree.rootNode + " " + StudentTree.rootNode.LeftNode.height + " " + StudentTree.rootNode.RightNode.height);
                    //Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));


                    //List<Node<Student, int>> leaves1 = new List<Node<Student, int>>();
                    //StudentTree.ForwardReverseOrder(StudentTree.rootNode, leaves1);
                    //Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
                    //foreach (Node<Student, int> el in leaves1)
                    //{
                    //    StudentTree.BalanceTree(el);
                    //}
                    //Console.WriteLine("===============");
                    //Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
                    //Console.WriteLine(StudentTree.rootNode + " " + StudentTree.rootNode.LeftNode.height + " " + StudentTree.rootNode.RightNode.height);


                    //List<Node<Student, int>> leaves3 = new List<Node<Student, int>>();
                    //StudentTree.ReverseOrder(StudentTree.rootNode, leaves3);
                    //Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
                    //foreach (Node<Student, int> el in leaves3)
                    //{
                    //    StudentTree.BalanceTree(el);
                    //}
                    //Console.WriteLine("===============");
                    //Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
                    //Console.WriteLine(StudentTree.rootNode + " " + StudentTree.rootNode.LeftNode.height + " " + StudentTree.rootNode.RightNode.height);
                }

                ////EVENTS TESTING
                {
                //    try
                //    {
                //        StudentTree.DeletingNode += BinaryTreeDeletingNode;
                //        StudentTree.DeleteNode(StudentTree.FindByKey(15, null, null));
                //        StudentTree.DeletingNode -= BinaryTreeDeletingNode;
                //    }
                //    catch (Exception ex)
                //    {
                //        Console.WriteLine(ex.Message);
                //    }
                //    Console.WriteLine("===============");

                //    try
                //    {
                //        var printer = new ConsolePrint<Student, int>(StudentTree);
                //        StudentTree.DeleteNode(StudentTree.FindByKey(12, null, null));
                //        StudentTree.DeletingNode -= printer.bTDeletingNode;
                //    }
                //    catch (Exception ex)
                //    {
                //        Console.WriteLine(ex.Message);
                //    }
                //    Console.WriteLine("===============");


                //    try
                //    {
                //        var printer1 = new ConsolePrint<Student, int>();
                //        StudentTree.DeletingNode += printer1.bTDeletingNode;
                //        StudentTree.DeleteNode(StudentTree.FindByKey(20, null, null));
                //        StudentTree.DeletingNode -= printer1.bTDeletingNode;
                //    }
                //    catch (Exception ex)
                //    {
                //        Console.WriteLine(ex.Message);
                //    }
                //    Console.WriteLine("===============");


                //    try
                //    {
                //        var printer1 = new ConsolePrint<Student, int>();
                //        StudentTree.DeletingNode += printer1.bTDeletingNode;
                //        StudentTree.DeleteNode(StudentTree.FindByKey(25, null, null));
                //        StudentTree.DeletingNode -= printer1.bTDeletingNode;
                //    }
                //    catch (Exception ex)
                //    {
                //        Console.WriteLine(ex.Message);
                //    }
                //    Console.WriteLine("===============");
                }
            }
            

            ////Unit for Polynome testing
            {
                //int[] k = { 1, 2, 3, 1, 4, 5, 2, 5, 3 };
                //Polynome P1 = new Polynome(k);
                //P1.View();

                //Polynome P2 = new Polynome(5);
                //P2.Ramdomize(-9, 9);
                //P2.View();

                //Polynome P3 = P1 + P2;
                //P3.View();

                //P3 = P2 + P1;
                //P3.View();

                //int[] zer = { 0, 0, 2, 0, 4};
                //Polynome P4 = new Polynome(zer);
                //P4.View();

                //Polynome P5 = P1 * P4;
                //P5.View();

                //P5 = P4 * P1;
                //P5.View();
            }


            ////Unit for Matrix testing
            {
                //int[,] k1 = { { 1, 2, 3 }, { 4, 5, 6 } };
                //Matrix A = new Matrix(5, 5);
                //A.Ramdomize(0, 9);
                //A.View();
                //try
                //{
                //    Console.WriteLine(A.Determinant());
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine($"Exception: {ex.Message}");
                //}
                //Matrix KEK = new Matrix(10, 10);
                //KEK.Ramdomize(0, 10);
                //KEK.View();
                //Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
                //try
                //{
                //    Console.WriteLine(KEK.Determinant());
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine($"Exception: {ex.Message}");
                //}
                //Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
                //Console.WriteLine(A.CompareTo(KEK));
                //Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
                //Matrix B = new Matrix(k);
                //B.View();
                //Matrix C = new Matrix(2, 3);
                //C.Ramdomize();
                //C.View();
                //try
                //{
                //    Console.WriteLine(C.Determinant());
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine($"Exception: {ex.Message}");
                //}
                //Matrix K = new Matrix(3, 2);
                //K.Ramdomize();
                //K.View();
                //try
                //{
                //    Matrix D = B + C;
                //    D.View();
                //    D = (Matrix)C.Clone();
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine($"Exception: {ex.Message}");
                //}
                //try
                //{
                //    Matrix D = A + B;
                //    D.View();
                //    D = (Matrix)B.Clone();
                //    D.View();
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine($"Exception: {ex.Message}");
                //}
                //try
                //{
                //    Matrix D1 = C * K;
                //    D1.View();
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine($"Exception: {ex.Message}");
                //}
            }

            Console.ReadKey();
            Console.ReadLine();
            return;

        }

        private static void BinaryTreeDeletingNode<T, U>(object sender, BinaryTreeEventArgs<T, U> e) where U : IComparable
        {
            var printer = new ConsolePrint<T, U>();
            printer.Print($"Node {sender.ToString()} was deleted " + e);
        }
    }
}
