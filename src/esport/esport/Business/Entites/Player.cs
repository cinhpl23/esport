namespace esport.Business.Entites
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pseudo {  get; set; }
        public int IdTeam { get; set; }
        public int MatchWin { get; set; }
    }
}
