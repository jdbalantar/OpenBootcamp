using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using LinQSnippets;

namespace LinQSnnipets
{
    public class Snnipets
    {
        public static void BasicLinQ()
        {
            string[] cars = { "Mazda", "VW California", "VW Golf", "Audi A3", "Audi A4", "Fiat Punto", "Seat Ibiza", "Seat Leon" };

            // 1. SELECT * FROM cars

            var carList = from car in cars select car;
            foreach (var car in cars)
                Console.WriteLine(car);

            // 2. SELECT * FROM cars WHERE car is Audi

            var audiList = from audi in cars where audi.Contains("Audi") select audi;
            foreach (var audi in audiList)
                Console.WriteLine(audi);
        }

        //Number examples
        public static void LinqNumbers()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Multiplicamos cada numero por 3
            // Obtenemos todos los numeros menos el 9
            // Ordenamos los numeros de forma ascendente

            var processedNumberList =
                numbers
                    .Select(num => num * 3)     // Multiplica
                    .Where(num => num != 9)     // Todos menos el 9
                    .OrderBy(num => num);       // Ordena los numeros de forma ascendiente
        }

        public static void SearchExamples()
        {
            List<string> textList = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "cfj" };

            // 1. Primero de todos los elementos

            var first = textList.First();

            // 2. Primer elemento que sea la letra "c"
            var cText = textList.First(x => x.Equals("c"));

            // 3. Primer elemento que contenga la "j"
            var jText = textList.First(x => x.Contains("j"));

            // 4. Primer elemento que contenga la "z" o sino, tomar un valor por defecto
            var firstOrDefaultText = textList.FirstOrDefault(X => X.Contains("z")); // Lista vacía "" o un valor con la "z"

            // 5. Ultimo elemento que contenga la "z" o sino, tomar un valor por defecto
            var lastOrDefaultText = textList.LastOrDefault(X => X.Contains("z")); // Lista vacía "" o un valor con la "z"

            // 6. Valores unicos
            var uniqueTexts = textList.Single();
            var uniqueOrDefaultTexts = textList.SingleOrDefault();

            // 7. Obtener {4, 8} - Obtiene los elementos que no estén repetidos (Es como hacer una resta y las que se repitan se cancelan)
            int[] evenNumbers = { 0, 2, 4, 6, 8 };
            int[] otherNumbers = { 0, 2, 6 };
            var myEvenNumbers = evenNumbers.Except(otherNumbers); // {4, 8}
        }

        public static void MultipleSelects()
        {
            // SELECT MANY - Selecciona todos los valores separados por ","
            string[] myOpinions = { "Opinion 1, Text 1", "Opinion 2, Text 2", "Opinion 3, Text 3" };
            var myOpinionSelection = myOpinions.SelectMany(opinion => opinion.Split(","));



            var enterprises = new[]
            {
                new Enterprise()
                {
                    Id = 1,
                    Name = "Enterprise 1",
                    Employees = new[]
                    {
                        new Employee()
                        {
                            Id = 1,
                            Name ="Martin",
                            Email = "martin@gmail.com",
                            Salary = 1000
                        },
                        new Employee()
                        {
                            Id = 2,
                            Name ="David",
                            Email = "david@gmail.com",
                            Salary = 1000
                        },
                        new Employee()
                        {
                            Id = 3,
                            Name ="Felipe",
                            Email = "felipe@gmail.com",
                            Salary = 1000
                        },
                        new Employee()
                        {
                            Id = 4,
                            Name ="Gina",
                            Email = "gina@gmail.com",
                            Salary = 1000
                        },
                    }
                },
                new Enterprise()
                {
                    Id = 1,
                    Name = "Enterprise 1",
                    Employees = new[]
                    {
                        new Employee()
                        {
                            Id = 1,
                            Name ="Martin",
                            Email = "martin@gmail.com",
                            Salary = 1000
                        },
                        new Employee()
                        {
                            Id = 2,
                            Name ="David",
                            Email = "david@gmail.com",
                            Salary = 1000
                        },
                        new Employee()
                        {
                            Id = 3,
                            Name ="Felipe",
                            Email = "felipe@gmail.com",
                            Salary = 1000
                        },
                        new Employee()
                        {
                            Id = 4,
                            Name ="Gina",
                            Email = "gina@gmail.com",
                            Salary = 1000
                        },
                    }
                },
                new Enterprise()
                {
                    Id = 2,
                    Name = "Enterprise 2",
                    Employees = new[]
                    {
                        new Employee()
                        {
                            Id = 5,
                            Name ="Victor",
                            Email = "victor@gmail.com",
                            Salary = 1000
                        },
                        new Employee()
                        {
                            Id = 6,
                            Name ="Yosuan",
                            Email = "yosuan@gmail.com",
                            Salary = 3000
                        },
                        new Employee()
                        {
                            Id = 7,
                            Name ="Carlos",
                            Email = "carlos@gmail.com",
                            Salary = 1000
                        },
                        new Employee()
                        {
                            Id = 8,
                            Name ="Fabian",
                            Email = "fabian@gmail.com",
                            Salary = 1000
                        },
                    }
                }
            };

            // Obtener todos los empleados de todas las empresas
            var employeeList = enterprises.SelectMany(enterprise => enterprise.Employees);

            // Saber si tenemos una lista vacia - // Devuelve true si hay empresas, sino, false
            bool hasEnterprises = enterprises.Any();

            // Saber si tenemos una lista vacia - // Devuelve true si hay empleados en las empresas, sino, false
            bool hasEmployees = enterprises.Any(enterprise => enterprise.Employees.Any());

            // Que todaslas empresas tenga empleados con un sueldo mayor o igual a 1000
            bool hasEmployeeWithSalaryMoreThanOrEqual1000 =
                enterprises.Any(enterprise =>
                    enterprise.Employees.Any(employee => employee.Salary >= 1000));

        }

        public static void LinqCollections()
        {
            var firstList = new List<string>() { "a", "b", "c" };
            var secondList = new List<string>() { "a", "c", "d" };

            // INNER JOIN - Todos los elementos que son compartidos en ambas listas o tablas 
            var commonResult = from element in firstList
                               join secondElement in secondList
                               on element equals secondElement
                               select new { element, secondElement };


            // Esto es lo mismo que lo de arriba, pero sin LINQ
            var commonResult2 = firstList.Join(
                secondList,
                element => element,
                secondElement => secondElement,
                (element, secondElement) => new { element, secondElement }
            );

            // OUTER JOIN - LEFT
            // Toma lo que es comun en ambas listas y lo guarda en una lista temporal (temporalList)
            // Elimina de la primera lista (firstList) todos los elementos que sean iguales a la lista temporal (temporalList)
            // Con esto se elimina de la primera lista los objetos en comun con la segunda y se guarda la primera lista
            var leftOuterJoin = from element in firstList
                                join secondElement in secondList
                                on element equals (secondElement)
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where element != temporalElement
                                select new { Element = element };

            var leftOuterJoin2 = from element in firstList
                                 from secondElement in secondList.Where(s => s == element).DefaultIfEmpty()
                                 select new { Element = element, SecondElement = secondElement };

            // OUTER JOIN - RIGHT
            // Lo mismo de lo de arriba, pero obteniendo la segunda lista
            var rightOuterJoin = from secondElement in secondList
                                 join element in firstList
                                on secondElement equals (element)
                                into temporalList
                                 from temporalElement in temporalList.DefaultIfEmpty()
                                 where secondElement != temporalElement
                                 select new { SecondElement = secondList };

            // UNION
            // var unionList = leftOuterJoin.Union(rightOuterJoin);
        }

        public static void SkipTakeLinq()
        {
            var myList = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Saltarse los dos primeros elemntos
            var skipTwoFirstValues = myList.Skip(2); // { 3, 4, 5, 6, 7, 8, 9, 10 }

            // Saltarse los dos ultimos elemntos
            var skipLastTwoValues = myList.SkipLast(2); // { 1, 2, 3, 4, 5, 6, 7, 8 }

            // Saltarse los elemntos menores que 
            var skipWhileSmallerThan4 = myList.SkipWhile(x => x < 4); // {4, 5, 6, 7, 8 }

            // Obtiene los primeros elementos
            var takeFirstTwoValues = myList.Take(2); // {1, 2}

            // Obtiene los dos ultimos elementos
            var takeLastTwoValues = myList.Take(2); // {9, 10}

            // Obtiene los elementos menores que 4
            var takeWhileSmallerThan4 = myList.TakeWhile(x => x < 4); // { 1, 2, 3}
        }

        // Paging with Skip & Take - Saltarse los primeros elementos y obtener los siguientes 10
        public IEnumerable<T> GetPage<T>(IEnumerable<T> collection, int pageNumber, int resultsPage)
        {
            int startIndex = (pageNumber - 1) * resultsPage;
            return collection.Skip(startIndex).Take(resultsPage);
        }

        // Variables - Uso de variables locales "let"
        // Obtener todos los numeros de la lista de numeros siempre y cuando
        // su valor cuadrado esté por encima de la media
        public static void LinqVariables()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var aboveAverage = from number in numbers
                               let average = numbers.Average()
                               let nSquared = Math.Pow(number, 2)
                               where nSquared > average
                               select number;

            Console.WriteLine($"Average: {numbers.Average()}");

            foreach (int number in aboveAverage)
                Console.WriteLine($"Query: Number: {number} Square: {Math.Pow(number, 2)}");
        }

        // ZIP
        // Intercalar valores
        // Resultado:
        // { "1 = one", "2 = two", "3 = three", "4 = four", "5 = five"}
        // Ambas colecciones deben tener la misma cantidad de posiciones
        public static void ZipLinq()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            string[] stringNumbers = { "One", "Two", "Three", "Four", "Five" };

            IEnumerable<string> zipNumbers = numbers.Zip(stringNumbers, (number, word) => number + " = " + word);

        }

        // Repeat & Range
        public static void repeatRangeLinq()
        {
            // Generar valores del 1 - 1000 -> RANGE
            IEnumerable<int> first1000 = Enumerable.Range(0, 1000);

            // Repetir un valor N cantidad de veces
            IEnumerable<string> fiveXs = Enumerable.Repeat("X", 5); // IEnumerable de strings de de X -> { "X", "X", "X", "X", "X" }
        }

        public static void studentsLinq()
        {
            var classRoom = new[]
            {
                new Student
                {
                    Id = 1,
                    Name = "Heidy",
                    Grade = 90,
                    Certified = true
                },
                new Student
                {
                    Id = 2,
                    Name = "Leidy",
                    Grade = 40,
                    Certified = false
                },
                new Student
                {
                    Id = 3,
                    Name = "Alex",
                    Grade = 10,
                    Certified = false
                },
                new Student
                {
                    Id = 4,
                    Name = "Juan",
                    Grade = 43,
                    Certified = false
                },
                new Student
                {
                    Id = 5,
                    Name = "Ana",
                    Grade = 96,
                    Certified = true
                }
            };

            // Obtener estudiantes certificados
            var certifiedStudents = from student in classRoom
                                    where student.Certified == true
                                    select student;

            // Obtener estudiantes no certificados
            var notCertifiedStudents = from student in classRoom
                                       where student.Certified == false
                                       select student;

            // Obtener estudiantes con nota mayor a 50 y esté certificado
            var aproveStudentsName = from student in classRoom
                                     where student.Grade >= 50 && student.Certified == true
                                     select student.Name;
        }

        // ALL
        // Que todos los elementos cumplan un requerimiento
        public static void AllLinq()
        {
            var numbers = new List<int>() { 1, 2, 3, 4, 5 };

            bool allAreSmallerThan10 = numbers.All(x => x < 10); // true
            bool alAreBiggerOrEqualThan2 = numbers.All(x => x >= 2); // false

            var emptyList = new List<int>();
            bool allNumbersAreGreaterThan0 = numbers.All(x => x >= 0); // true - Cuando una lista está vacía su valor por defecto es cero
        }

        // Aggregate
        // Un agregado es una secuencia acumulativa de funciones
        public static void aggregateQueries()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Sumar todos los numeros
            int sum = numbers.Aggregate((prevSum, current) => prevSum + current);

            // prevSum 0, 1 => 1
            // prevSum 1, 2 => 3
            // prevSum 3, 4 => 7

            string[] words = { "Hello,", "my", "name", "is", "David" }; // Hello my name is David
            string greeting = words.Aggregate((prevGreeting, current) => prevGreeting + current);

            // "", "Hello," => Hello,
            // "Hello, ", "my => Hello, my
            // "Hello, my ", "name" => "Hello, my name"
            // "Hello, my name", "is" => "Hello, my name is"
            // "Hello, my name is", "David" => "Hello, my name is David"
        }

        // Disctint
        public static void distinctValues()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1 };
            IEnumerable<int> distictValues = numbers.Distinct(); // Obtengo los numeros pero sin repetirse
        }

        // GroupBy
        public static void groupByExamples()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Obtener solo los numeros pares y generar dos grupos
            var grouped = numbers.GroupBy(x => x % 2 == 0);

            // Vamos a tener dos grupos
            // 1. El grupo que no cumple la condicion dada  (Numeros impares)
            // 2. Y luego, el grupo que sí                  (Numeros pares)

            foreach (var group in grouped)
            {
                foreach (var value in group)
                {
                    Console.WriteLine(value); // 1, 3, 5, 7, 9 ... 2, 4, 6, 8 ->
                }
            }

            // Another example
            var classRoom = new[]
                {
                new Student
                {
                    Id = 1,
                    Name = "Heidy",
                    Grade = 90,
                    Certified = true
                },
                new Student
                {
                    Id = 2,
                    Name = "Leidy",
                    Grade = 40,
                    Certified = false
                },
                new Student
                {
                    Id = 3,
                    Name = "Alex",
                    Grade = 10,
                    Certified = false
                },
                new Student
                {
                    Id = 4,
                    Name = "Juan",
                    Grade = 43,
                    Certified = false
                },
                new Student
                {
                    Id = 5,
                    Name = "Ana",
                    Grade = 96,
                    Certified = true
                }
            };

            // Grupo de estudiantes certificados y con nota de 50 o superior
            var approvedQuery = classRoom.GroupBy(student => student.Certified == true && student.Grade >= 50);

            // Obtenemos dos grupos
            // 1. Los no certificados
            // 2. Los certificados

            foreach (var group in approvedQuery)
            {
                Console.WriteLine($" ------------ {group.Key} ------------ ");
                foreach (var student in group)
                {
                    Console.WriteLine(student.Name);
                }
            }
        }

        public static void relationsLinq()
        {
            List<Post> posts = new List<Post>()
            {
                new Post()
                {
                    Id = 1,
                    Title = "Mi primer post",
                    Content = "Mi primer contenido",
                    Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id = 1,
                            Created = DateTime.Now,
                            Title = "Mi primer comentario",
                            Content = "Mi contenido"
                        },
                        new Comment()
                        {
                            Id = 2,
                            Created = DateTime.Now,
                            Title = "Mi segundo comentario",
                            Content = "Mi otro contenido"
                        }
                    }
                },
                new Post()
                {
                    Id = 2,
                    Title = "Mi segundo post",
                    Content = "Mi segundo contenido",
                    Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id = 3,
                            Created = DateTime.Now,
                            Title = "Mi tercer comentario",
                            Content = "Mi nuevo contenido"
                        },
                        new Comment()
                        {
                            Id = 4,
                            Created = DateTime.Now,
                            Title = "Mi cuarto comentario",
                            Content = "Mi otro contenido xD"
                        }
                    }
                }
            };

            // Devuelve el ID del Post junto a sus comentarios
            var commentsContent = posts.SelectMany(post => 
                post.Comments, 
                    (post, comment) => new { PostId = post.Id, CommentContent = comment.Content });


        }



    }
}
