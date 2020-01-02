﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LinqTask
{
    class Film
    {
        public string Name { get; set; }
        public int Year { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {



            var films = new List<Film>
            {
                new Film { Name = "Jaws", Year = 1975 },
                new Film { Name = "Singing in the Rain", Year = 1952 },
                new Film { Name = "Some like it Hot", Year = 1959 },
                new Film { Name = "The Wizard of Oz", Year = 1939 },
                new Film { Name = "It’s a Wonderful Life", Year = 1946 },
                new Film { Name = "American Beauty", Year = 1999 },
                new Film { Name = "High Fidelity", Year = 2000 },
                new Film { Name = "The Usual Suspects", Year = 1995 }
            };

            //Создание многократно используемого делегата для вывода списка на консоль
            Action<Film> print = film => Console.WriteLine($"Name={film.Name}, Year={film.Year}");

            //Вывод на консоль исходного списка
            films.ForEach(print);

            //Создание и вывод отфильтрованного списка
            films.FindAll(film => film.Year < 1960).ForEach(print);

            //Сортировка исходного списка
            films.Sort((f1, f2) => f1.Name.CompareTo(f2.Name));
            //or
            films.OrderBy(film => film.Name);

            {
                // OrderByDescending, Skip, SkipWhile, Take, TakeWhile, Select, Concat
                int[] n = { 1, 3, 5, 6, 3, 6, 7, 8, 45, 3, 7, 6 };

                IEnumerable<int> res;
                res = n.OrderByDescending(g => g).Skip(3);
                res = n.OrderByDescending(g => g).Take(3);
                res = n.Select(g => g * 2);
                // to delete from array number 45
                res = n.TakeWhile(g => g != 45).Concat(n.SkipWhile(s => s != 45).Skip(1));
            }

            {
                //Дана последовательность непустых строк. 
                //Объединить все строки в одну.
                List<string> str = new List<string> { "1qwerty", "cqwertyc", "cqwe", "c" };
                string amount = str.Aggregate<string>((x, y) => x + y);
            }

            {
                //LinqBegin3. Дано целое число L (> 0) и строковая последовательность A.
                //Вывести последнюю строку из A, начинающуюся с цифры и имеющую длину L.
                //Если требуемых строк в последовательности A нет, то вывести строку «Not found».
                //Указание.Для обработки ситуации, связанной с отсутствием требуемых строк, использовать операцию ??.

                int length = 7;
                List<string> str = new List<string> { "1qwerty", "2qwerty", "7qwe" };
                string res = str.LastOrDefault(x => (Char.IsDigit(x[0])) && (x.Length == length)) ?? "Not found";
            }

            {
                //LinqBegin5. Дан символ С и строковая последовательность A.
                //Найти количество элементов A, которые содержат более одного символа и при этом начинаются и оканчиваются символом C.

                char c = 'c';
                List<string> str = new List<string> { "1qwerty", "cqwertyc", "cqwe", "c" };
                int amount = str.Count(x => (x.StartsWith(c.ToString())) && (x.EndsWith(c.ToString())) && (x.Length > 1));
            }

            {
                //LinqBegin6. Дана строковая последовательность.
                //Найти сумму длин всех строк, входящих в данную последовательность.
                //TODO
                List<string> str = new List<string> { "1qwerty", "cqwertyc", "cqwe", "c" };
                int totalLenght = str.Aggregate<string>((x, y) => x + y).Length;
            }

            {
                //LinqBegin11. Дана последовательность непустых строк. 
                //Пполучить строку, состоящую из начальных символов всех строк исходной последовательности.
                //TODO
                List<string> str = new List<string> { "1qwerty", "cqwertyc", "cqwe", "c", "qeq" };
                string result = str.Aggregate<string>((x, y) => x == str[0] ? x[0].ToString() + y[0].ToString() : x + y[0].ToString());
            }

            {
                //LinqBegin30. Дано целое число K (> 0) и целочисленная последовательность A.
                //Найти теоретико-множественную разность двух фрагментов A: первый содержит все четные числа, 
                //а второй — все числа с порядковыми номерами, большими K.
                //В полученной последовательности(не содержащей одинаковых элементов) поменять порядок элементов на обратный.
                int k = 5;
                IEnumerable<int> n = new int[] { 12, 88, 1, 3, 5, 4, 6, 6, 2, 5, 8, 9, 0, 90 };
                var res = n.Where(x => x % 2 == 0).Except(n.Skip(k)).Reverse();
            }

            {
                //LinqBegin22. Дано целое число K (> 0) и строковая последовательность A.
                //Строки последовательности содержат только цифры и заглавные буквы латинского алфавита.
                //Извлечь из A все строки длины K, оканчивающиеся цифрой, отсортировав их по возрастанию.
                //TODO
                int k = 4;
                List<string> str = new List<string> { "1qwerty", "cqwerty2", "cqw2", "c", "qeq5", "1234" };
                var res = str.Where(x => (x.Length == k) && (Char.IsDigit(x[k - 1]))).OrderBy(x => x[k - 1]) ?? null;
            }

            {
                //LinqBegin29. Даны целые числа D и K (K > 0) и целочисленная последовательность A.
                //Найти теоретико - множественное объединение двух фрагментов A: первый содержит все элементы до первого элемента, 
                //большего D(не включая его), а второй — все элементы, начиная с элемента с порядковым номером K.
                //Полученную последовательность(не содержащую одинаковых элементов) отсортировать по убыванию.
                //TODO
                int k = 8;
                int l = 5;
                IEnumerable<int> n = new int[] { 12, 88, 1, 3, 5, 4, 6, 21, 12, 88, 6 };
                var result = (k > l) && (l > 0) ? n.Take(l - 1).Concat(n.Skip(k - 1).Except(n.Take(l - 1))).OrderByDescending(x => x) : null;
            }

            {
                //LinqBegin34. Дана последовательность положительных целых чисел.
                //Обрабатывая только нечетные числа, получить последовательность их строковых представлений и отсортировать ее по возрастанию.
                IEnumerable<int> n = new int[] { 12, 88, 1, 3, 5, 4, 6, 7, 6, 2, 5, 8, 9, 0, 90 };
                var res = n.Where(x => x % 2 != 0).Select(x => x.ToString()).OrderBy(x => x);
            }

            {
                //LinqBegin36. Дана последовательность непустых строк. 
                //Получить последовательность символов, которая определяется следующим образом: 
                //если соответствующая строка исходной последовательности имеет нечетную длину, то в качестве
                //символа берется первый символ этой строки; в противном случае берется последний символ строки.
                //Отсортировать полученные символы по убыванию их кодов.
                //TODO
                List<string> str = new List<string> { "1qwerty", "cqwerty2", "cqw2", "c", "qes", "1234" };
                List<char> result = str.Select(x => x.Length % 2 != 0 ? x[0] : x[x.Length - 1]).OrderByDescending(x => (int)x).ToList<char>();
            }

            {
                //LinqBegin44. Даны целые числа K1 и K2 и целочисленные последовательности A и B.
                //Получить последовательность, содержащую все числа из A, большие K1, и все числа из B, меньшие K2. 
                //Отсортировать полученную последовательность по возрастанию.
                //TODO
                int k1 = 8;
                int k2 = 10;
                IEnumerable<int> a = new int[] { 12, 88, 1, 3, 5, 4, 6, 7, 6, 2, 5, 8, 9, 0, 90 };
                IEnumerable<int> b = new int[] { 7, 1, 12, 88, 1, 3, 5, 4, 6, 21, 12, 88, 6, 9 };
                var res = a.Where(x => x > k1).Concat(b.Where(x => x < k2)).OrderBy(x => x);
            }
            {
                //LinqBegin46. Даны последовательности положительных целых чисел A и B; все числа в каждой последовательности различны.
                //Найти последовательность всех пар чисел, удовлетворяющих следующим условиям: первый элемент пары принадлежит 
                //последовательности A, второй принадлежит B, и оба элемента оканчиваются одной и той же цифрой. 
                //Результирующая последовательность называется внутренним объединением последовательностей A и B по ключу, 
                //определяемому последними цифрами исходных чисел. 
                //Представить найденное объединение в виде последовательности строк, содержащих первый и второй элементы пары, 
                //разделенные дефисом, например, «49 - 129».
                IEnumerable<int> n1 = new int[] { 12, 88, 11, 3, 55, 679, 222, 845, 9245 };
                IEnumerable<int> n2 = new int[] { 123, 888, 551, 443, 69, 222, 780 };
                var res = n1.Join(n2, x => x % 10, y => y % 10, (x, y) => x.ToString() + " - " + y.ToString());
            }
            {
                //LinqBegin48.Даны строковые последовательности A и B; все строки в каждой последовательности различны, 
                //имеют ненулевую длину и содержат только цифры и заглавные буквы латинского алфавита. 
                //Найти внутреннее объединение A и B, каждая пара которого должна содержать строки одинаковой длины.
                //Представить найденное объединение в виде последовательности строк, содержащих первый и второй элементы пары, 
                //разделенные двоеточием, например, «AB: CD». Порядок следования пар должен определяться порядком 
                //первых элементов пар(по возрастанию), а для равных первых элементов — порядком вторых элементов пар(по убыванию).
                //TODO
                List<string> a = new List<string> { "1qwerty", "cqwerty2", "cqw2", "c", "qes", "1234" };
                List<string> b = new List<string> { "2qwerty", "cqwertyc", "cqwe", "aaca", "bek", "ol" };
                List<string> res = a.OrderBy(x => x).Join(b.OrderByDescending(x => x), x => x.Length, x => x.Length, (x, y) => x + ": " + y).ToList<string>();
            }

            {
                //LinqBegin56. Дана целочисленная последовательность A.
                //Сгруппировать элементы последовательности A, оканчивающиеся одной и той же цифрой, и на основе этой группировки 
                //получить последовательность строк вида «D: S», где D — ключ группировки (т.е.некоторая цифра, которой оканчивается 
                //хотя бы одно из чисел последовательности A), а S — сумма всех чисел из A, которые оканчиваются цифрой D.
                //Полученную последовательность упорядочить по возрастанию ключей.
                //Указание.Использовать метод GroupBy.
                IEnumerable<int> n = new int[] { 12, 88, 11, 3, 55, 679, 222, 845, 9245 };
                List<string> res = new List<string>();

                IEnumerable<IGrouping<int, int>> groups = n.GroupBy(x => x % 10).OrderBy(x => x.Key);

                foreach (IGrouping<int, int> group in groups)
                {
                    string listElement = group.Key.ToString();
                    int summaryValue = 0;

                    foreach (int item in group)
                    {
                        summaryValue += item;
                    }

                    listElement = listElement + ": " + summaryValue.ToString();
                    res.Add(listElement);

                }

                {
                    //LinqObj17. Исходная последовательность содержит сведения об абитуриентах. Каждый элемент последовательности
                    //включает следующие поля: < Номер школы > < Год поступления > < Фамилия >
                    //Для каждого года, присутствующего в исходных данных, вывести число различных школ, которые окончили абитуриенты, 
                    //поступившие в этом году (вначале указывать число школ, затем год). 
                    //Сведения о каждом годе выводить на новой строке и упорядочивать по возрастанию числа школ, 
                    //а для совпадающих чисел — по возрастанию номера года.
                    //TODO
                    List<Abiturient> abiturients = new List<Abiturient>
                    {
                        new Abiturient { schoolNumber = 12, startingYear = 1988, lastName = "Kekovich"},
                        new Abiturient { schoolNumber = 15, startingYear = 1995, lastName = "Handricks"},
                        new Abiturient { schoolNumber = 18, startingYear = 1912, lastName = "Sim"},
                        new Abiturient { schoolNumber = 15, startingYear = 1900, lastName = "Biba"},
                        new Abiturient { schoolNumber = 22, startingYear = 1988, lastName = "Boba"},
                        new Abiturient { schoolNumber = 32, startingYear = 1955, lastName = "Gagarin"},
                        new Abiturient { schoolNumber = 42, startingYear = 1955, lastName = "Pilipovich"},
                        new Abiturient { schoolNumber = 12, startingYear = 1988, lastName = "Bale"},
                        new Abiturient { schoolNumber = 15, startingYear = 1995, lastName = "Garret"},
                        new Abiturient { schoolNumber = 12, startingYear = 1995, lastName = "Ronaldo"},
                        new Abiturient { schoolNumber = 12, startingYear = 1995, lastName = "Sasha"},
                        new Abiturient { schoolNumber = 12, startingYear = 1995, lastName = "Rivaldo"},
                        new Abiturient { schoolNumber = 12, startingYear = 1995, lastName = "Champ"}
                    };
                    var abiturientsYearGroups = abiturients.
                        Select(x => new { school = x.schoolNumber, year = x.startingYear }).
                        Distinct().
                        OrderBy(x => x.year).
                        GroupBy(x => x.year).
                        Select(group => new { schoolSumm = group.ToList().Count, startingYear = group.Key }).
                        OrderBy(x => x.schoolSumm).
                        Select(x => x.schoolSumm + " - " + x.startingYear).
                        ToList();
                    abiturientsYearGroups.ForEach(x => { Console.WriteLine(x); });
                    Console.ReadLine();
                }
            }

            string A = "AAAABBBCCDAABBB";
            object B = UniqueInOrder<char>(A);
            Console.ReadLine();
        }

        public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable) where T : IComparable
        {
            List<T> array = new List<T>();
            int i = 0;
            foreach (T el in iterable)
            {
                if (array.Count == 0)
                {
                    array.Add(el);
                    i++;
                }
                else
                {
                    if (el.CompareTo(array[i - 1]) != 0)
                    {
                        array.Add(el);
                        i++;
                    }
                }
            }
            return array as IEnumerable<T>;
        }

    }
    struct Abiturient { internal int schoolNumber; internal int startingYear; internal string lastName; };

}
