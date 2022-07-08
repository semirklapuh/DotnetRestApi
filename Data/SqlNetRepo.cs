using System;
using System.Collections.Generic;
using System.Linq;
using netCoreCourse.Dtos;
using netCoreCourse.Models;

namespace netCoreCourse.Data
{
    public class SqlNetRepo : INetRepo
    {
        private readonly NetCoreCourseContext _contex;

        public SqlNetRepo(NetCoreCourseContext context)
        {
            _contex = context;
        }

        public void createCommand(Command cmd)
        {
            if (cmd == null)
            throw new ArgumentNullException(nameof(cmd));

            _contex.Commands.Add(cmd);
            SaveChanges();

        }

        public void deleteCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _contex.Commands.Remove(cmd);
            SaveChanges();
        }

        public IEnumerable<Command> getAllCommands()
        {
            return _contex.Commands.ToList();
        }

        public Command getCommandById(int id)
        {
            return _contex.Commands.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool SaveChanges()
        {
            return (_contex.SaveChanges() >= 0);
        }

        public void updateCommand(Command cmd)
        {
           //Nothing ??
        }
    }
}