using System.Collections.Generic;
using netCoreCourse.Models;

namespace netCoreCourse.Data
{
    public class MockNetRepo : INetRepo
    {
        public void createCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public void deleteCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> getAllCommands()
        {
            var commands = new List<Command>
            {
                new Command{Id = 0, HowTo = "Boil an egg", Line ="Boil water", Platform ="Kettle and Pan"},
                new Command{Id = 1, HowTo = "Cut bread", Line ="Get a knfie", Platform ="knife and chopping board"},
                new Command{Id = 2, HowTo = "Make cup of tea", Line ="Place tea bag in cup", Platform ="Kettle and cup"}
            };

            return commands;
        }

        public Command getCommandById(int id)
        {
            return new Command{Id = 0, HowTo = "Boil an egg", Line ="Boil water", Platform =" Kettle and Pan"};
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void updateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}