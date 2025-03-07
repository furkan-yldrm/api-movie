using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movie.application.Features.CQRS.Commands.CategoryCommands
{
    public class RemoveCategoryCommand
    {
        private int id;

        public RemoveCategoryCommand(int id)
        {
            this.id = id;
        }

        public int CategoryId { get; set; }
    }
}
