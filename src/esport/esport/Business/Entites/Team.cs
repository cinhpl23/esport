namespace esport.Business.Entites
{
    public class Team
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<Player>? ListPlayer { get; set; }
        public int StatGame { get; set; }
    }
}
