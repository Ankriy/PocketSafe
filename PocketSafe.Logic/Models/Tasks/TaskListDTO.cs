using System.Collections.Generic;

namespace PocketSafe.Logic.Models.Tasks
{
    public class TaskListDTO
    {
        public List<TaskDTO> Tasks { get; set; }

        public int TotalCount { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
