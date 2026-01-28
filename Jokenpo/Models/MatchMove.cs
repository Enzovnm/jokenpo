namespace Jokenpo.Models
{
    public class MatchMove
    {
        public int MatchId {get; set;}
        public Match Match {get; set;}

        public int PlayerId {get; set;}
        public  Player Player {get; set;}

        public int MoveId {get; set;}
        public Move Move {get; set;}



    }
}