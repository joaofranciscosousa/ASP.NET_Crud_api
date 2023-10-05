using SistemaDeTarefas.Enums;

namespace SistemaDeTarefas.Models
{
    public class JobsModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public StatusJob Status { get; set; }
        public int? UserId { get; set; }

        public virtual UserModel? User { get; set; }
    }
}
