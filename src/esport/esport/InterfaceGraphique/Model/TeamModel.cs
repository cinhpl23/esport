namespace esport.InterfaceGraphique.Models
{
    public class TeamModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int ListPlayer { get; set; }
        public int StatGame { get; set; }
    }

}
