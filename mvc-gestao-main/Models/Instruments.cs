using System.ComponentModel.DataAnnotations;
namespace EmployeesManagement.Models;
public class Instruments : UserActivity {
    public int Id { get; set; }
    [Required] public string TipoInstrumento{ get; set; } = "";
    [Required] public string Instrumento { get; set; } = "";
    public Boolean UsaCordas { get; set; }
}