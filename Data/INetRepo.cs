using System.Collections.Generic;
using netCoreCourse.Dtos;
using netCoreCourse.Models;

namespace netCoreCourse.Data
{
    public interface INetRepo
    {
        bool SaveChanges();
        IEnumerable<Command> getAllCommands();
        Command getCommandById(int id);

        void createCommand(Command cmd);

        void updateCommand(Command cmd);

        void deleteCommand(Command cmd);
    }
}
