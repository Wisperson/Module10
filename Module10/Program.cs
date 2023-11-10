using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            House house = new House();
            Team team = new Team();
            house.PrintHome(team.Project);
            team.Work(house.Parts, team.Project);
            house.PrintHome(team.Project);
            team.Work(house.Parts, team.Project);
            house.PrintHome(team.Project);
            team.Work(house.Parts, team.Project);
            house.PrintHome(team.Project);
            team.Work(house.Parts, team.Project);
            house.PrintHome(team.Project);
            team.Work(house.Parts, team.Project);
            house.PrintHome(team.Project);
            team.Work(house.Parts, team.Project);
            house.PrintHome(team.Project);
            team.Work(house.Parts, team.Project);
            house.PrintHome(team.Project);
            team.Work(house.Parts, team.Project);
            house.PrintHome(team.Project);
            team.Work(house.Parts, team.Project);
            house.PrintHome(team.Project);
            team.Work(house.Parts, team.Project);

            Console.ReadKey();
        }
    }

    public interface IWorker
    {
        void Work(List<IPart> parts, List<string> project);
    }

    public interface IPart
    {
        string Name { get; }
    }

    public class Basement : IPart
    {
        public string Name { get; set; }
        public Basement()
        {
            Name = "Basement";
        }
    }

    public class Wall : IPart
    {
        public string Name { get; set; }
        public Wall()
        {
            Name = "Wall";
        }
    }

    public class Window: IPart
    {
        public string Name { get; set; }
        public Window()
        {
            Name = "Window";
        }
    }

    public class Door: IPart
    {
        public string Name { get; set; }
        public Door()
        {
            Name = "Door";
        }
    }

    public class Roof: IPart
    {
        public string Name { get; set; }
        public Roof()
        {
            Name = "Roof";
        }
    }

    public class Builder: IWorker
    {
        public void Work(List<IPart> parts, List<string> project)
        {
            if (project.Contains("DONE"))
            {
                Console.WriteLine("Builder: Nothing left to build");
                return;
            }
            if (!project.Contains("Basement"))
            {
                parts.Add(new Basement());
            }
            else if (project.Count(p => p == "Wall") < 4)
            {
                parts.Add(new Wall());
            }
            else if (!project.Contains("Door"))
            {
                parts.Add(new Door());
            }
            else if (project.Count(p => p == "Window") < 4)
            {
                parts.Add(new Window());
            }
            else if (!project.Contains("Roof"))
            {
                parts.Add(new Roof());
            }
            else
            {
                Console.WriteLine("Builder: Nothing left to build");
            }
        }
    }

    public class TeamLeader: IWorker
    {
        public void Work(List<IPart> parts, List<string> project)
        {
            if (project.Contains("DONE"))
            {
                Console.WriteLine("TeamLeader: Nothing left to do");
                return;
            }
            if (parts.Any(p => p is Basement) &&
                parts.Count(p => p is Wall) == 4 &&
                parts.Any(p => p is Door) &&
                parts.Count(p => p is Window) == 4 &&
                parts.Any(p => p is Roof))
            {
                project.Clear();
                project.Add("DONE");
                return;
            }
            project.Clear();
            foreach (IPart part in parts)
            {
                if (part is Basement)
                {
                    project.Add("Basement");
                }
                else if (part is Wall)
                {
                    project.Add("Wall");
                }
                else if (part is Door)
                {
                    project.Add("Door");
                }
                else if (part is Window)
                {
                    project.Add("Window");
                }
                else if (part is Roof)
                {
                    project.Add("Roof");
                }
            }
        }
    }

    public class House: IPart
    {
        public string Name { get; set; }
        public List<IPart> Parts { get; set; }
        public House()
        {
            Name = "House";
            Parts = new List<IPart>();
        }
        public void PrintHome(List<string> project)
        {
            if (project.Contains("DONE"))
            {
                Console.WriteLine("  _____  ");
                Console.WriteLine(" /     \\ ");
                Console.WriteLine("/       \\");
                Console.WriteLine("| [] [] |");
                Console.WriteLine("| [] [] |");
                Console.WriteLine("|  |-|  |");
                Console.WriteLine("|  | |  |");
                Console.WriteLine("---------");
            }
            else Console.WriteLine("House is not built yet");
        }
    }

    public class Team: IWorker
    {
        public Builder[] Builders { get; set; }
        public TeamLeader TeamLeader { get; set; }
        public List<string> Project {  get; set; }
        public Team()
        {
            Builders = new Builder[2];
            Builders[0] = new Builder();
            Builders[1] = new Builder();
            TeamLeader = new TeamLeader();
            Project = new List<string>();
        }

        public void Work(List<IPart> parts, List<string> project)
        {
            Builders[0].Work(parts, project);
            Builders[1].Work(parts, project);
            TeamLeader.Work(parts, project);
        }
    }
}
