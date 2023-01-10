using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasljedivanjeIpolimorfizam
{
    class Dessert
    {
        string name;
        double weight;
        int calories;
        public string Name { get => name; set => name = value; }
        public double Weight { get => weight; set => weight = value; }
        public int Calories { get => calories; set => calories = value; }
        public virtual string getDesertType()
        {
            return "Desert";
        }
        public override string ToString()
        {
            string text = "Desert " + Name + " ima " + Weight + "g težina s " + Calories + " kalorija.";
            return text;
        }
        public Dessert(string N, double W, int C)
        {
            Name = N;
            Weight = W;
            Calories = C;
        }
        public Dessert()
        {
        }
    }
    class Cake : Dessert
    {
        bool containsGluten;
        string cakeType;
        public bool ContainsGluten { get => containsGluten; set => containsGluten = value; }
        public string CakeType { get => cakeType; set => cakeType = value; }

        public override string getDesertType()
        {
            return "Cake";
        }
        public override string ToString()
        {
            string text = "Desert " + Name + " je " + CakeType + " vrsta i ";
            if (ContainsGluten)
            {
                text += "im";
            }
            else
            {
                text += "nem";
            }

            text += "a gluten, ima " + Weight + "g težina s " + Calories + " kalorija.";
            return text;
        }
        public Cake(string N, double W, int C, bool CG, string CT)
        {
            Name = N;
            Weight = W;
            Calories = C;
            ContainsGluten = CG;
            CakeType = CT;
        }
    }
    class IceCream : Dessert
    {
        string flavor;
        string color;
        public string Flavor { get => flavor; set => flavor = value; }
        public string Color { get => color; set => color = value; }

        public override string getDesertType()
        {
            return "Ice Cream";
        }
        public override string ToString()
        {
            string text = "Desert " + Name + " je " + Color + " boje i ima okus " + Flavor + ", ima " + Weight + "g težina s " + Calories + " kalorija.";
            return text;
        }
        public IceCream(string N, double W, int C, string F, string CR)
        {
            Name = N;
            Weight = W;
            Calories = C;
            Flavor = F;
            Color = CR;
        }
    }
    class Person
    {
        string name;
        string surname;
        int age;
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public int Age { get => age; set => age = value; }
        public Person(string N, string M, int A)
        {
            name = N;
            Surname = M;
            Age = A;
        }
        public Person()
        {
        }
        public override string ToString()
        {
            return "Person " + Name + " " + Surname + " ima " + Age + ".";
        }
        public override bool Equals(object obj)
        {
            return obj is Person person &&
                   Name == person.Name &&
                   Surname == person.Surname &&
                   Age == person.Age;
        }
    }
    class Student : Person
    {
        string studentId;
        int academicYear;

        public string StudentId { get => studentId; set => studentId = value; }
        public int AcademicYear { get => academicYear; set => academicYear = value; }
        public override string ToString()
        {
            return "Person " + Name + " " + Surname + " ima " + Age + " s id-om " + StudentId + " i razred je " + AcademicYear + ".";
        }
        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   //base.Equals(obj) &&
                   StudentId == student.StudentId;
        }
        public Student(string N, string S, int A, string SI, int AY)
        {
            Name = N;
            Surname = S;
            Age = A;
            StudentId = SI;
            AcademicYear = AY;
        }
        public Student()
        {
        }
    }
    class Teacher : Person
    {
        string email, subject;
        double salary;

        public string Email { get => email; set => email = value; }
        public string Subject { get => subject; set => subject = value; }
        public double Salary { get => salary; set => salary = value; }
        public override string ToString()
        {
            return "Person " + Name + " " + Surname + " ima " + Age + " s e-mailom " + Email + " uči " + Subject + " i ima plača " + Salary + ".";
        }
        public override bool Equals(object obj)
        {
            return obj is Teacher teacher &&
                   //base.Equals(obj) &&
                   Email == teacher.Email;
        }
        public Teacher(string N, string S, int A, string E, string SU, double SA)
        {
            Name = N;
            Surname = S;
            Age = A;
            Email = E;
            Subject = SU;
            Salary = SA;
        }
        public Teacher()
        {
        }
        void increaseSalary(int percent)
        {
            this.salary += (this.salary * (percent/100));
        }
        static void increaseSalaryStatic(int percent, Teacher teach)
        {
            teach.salary += (teach.salary * (percent / 100));
        }
    }
    class CompetitionEntry
    {
        Teacher teach;
        Dessert desse;
        Student[] stund;
        int[]  score;
        internal Teacher Teach { get => teach; set => teach = value; }
        internal Dessert Desse { get => desse; set => desse = value; }
        internal Student[] Stund { get => stund; set => stund = value; }
        public int[] Score { get => score; set => score = value; }

        public bool addRating(Student S, int s)
        {
            bool check = false;
            if (Score[0] != 0) {
                Stund[0] = S;
                Score[0] = s;
                check = true;
            }
            else if (Score[1] != 0 && Stund[0] != S)
            {
                Stund[1] = S;
                Score[1] = s;
                check = true;
            }
            if (Score[2] != 0 && Stund[0] != S && Stund[1] != S) {
                Stund[2] = S;
                Score[2] = s;
                check = true;
            }
            return check;
        }
        public int getRating()
        {
            int amt=0,scoreR=0;
            for(int i = 0; i<=2; i++)
            {
                if (Score[i]!=0)
                {
                    amt++;
                    scoreR += Score[i];
                }
            }
            return scoreR / amt;
        }
        public CompetitionEntry(Teacher T, Dessert D)
        {
            Teach = T;
            Desse = D;
        }
    }
    class UniMasterChef
    {
        CompetitionEntry[] compE;
        internal CompetitionEntry[] CompE { get => compE; set => compE = value; }

        public void addEntry(CompetitionEntry comp)
        {
            CompE[0] = comp;
        }
            public string getBestDessert()
        {
            string best = CompE[0].Desse.Name;
            int scr = CompE[0].getRating();
            for (int i = 1; i <= CompE.Length - 1; i++)
            {
                if (CompE[i].getRating() >= scr) {
                    best = CompE[i].Desse.Name;
                    scr = CompE[i].getRating();
                }
            }
            return best;
        }
        public static Person[] getInvolvedPeople(CompetitionEntry co)
        {
            Person[] st = { };
            st[0] = co.Teach;
            for (int i = 1; i <= co.Stund.Length + 1; i++)
            {
                st[i] = co.Stund[i];
            }
            return st;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dessert genericDessert = new Dessert("Chocolate Mousse", 120, 300);
            Cake cake = new Cake("Raspberry chocolate cake #3", 350.5, 400, false, "birthday");
            Teacher t1 = new Teacher("Dario", "Tušek", 42, "dario.tusek@fer.hr", "OOP", 10000);
            Teacher t2 = new Teacher("Doris", "Bezmalinović", 43, "doris.bezmalinovic@fer.hr","OOP", 10000);
            Student s1 = new Student("Janko", "Horvat", 18, "0036312123", (short)1);
            Student s2 = new Student("Ana", "Kovač", 19, "0036387656", (short)2);
            Student s3 = new Student("Ivana", "Stanić", 19, "0036392357", (short)1);
            UniMasterChef competition = new UniMasterChef();
            CompetitionEntry e1 = new CompetitionEntry(t1, genericDessert);
            competition.addEntry(e1);
            Console.WriteLine("Entry 1 rating: " + e1.getRating());
            e1.addRating(s1, 4);
            e1.addRating(s2, 5);
            Console.WriteLine("Entry 1 rating: " + e1.getRating());
            CompetitionEntry e2 = new CompetitionEntry(t2, cake);
            e2.addRating(s1, 4);
            e2.addRating(s3, 5);
            e2.addRating(s2, 5);
            competition.addEntry(e2);
            Console.WriteLine("Entry 2 rating: " + e2.getRating());
            Console.WriteLine("Best dessert is: " + competition.getBestDessert());
            Person[] e2persons = UniMasterChef.getInvolvedPeople(e2);

            for (int i = 0; i <= e2persons.Length-1; i++)
            {
                Console.WriteLine(e2persons[i].ToString());
            }

            Console.ReadKey();
        }
    }
}
