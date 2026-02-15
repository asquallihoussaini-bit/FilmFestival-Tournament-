using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


namespace AhmedSqualliHoussaini
{
    
    public class InternationalFilmFestival 
    {
        public int Year;
        public required string Location ;
        public int NumberOfFilms ;
        private List<Film> _listOfFilmsParticipants = new();
        public List<Film> ListOfFilmsParticipants
        {
            get { return _listOfFilmsParticipants; }
            set { _listOfFilmsParticipants = value; }
        }
        public override string ToString()
        {
            return $"Year: {Year}, Location: {Location}, Number of Films: {NumberOfFilms}";
        }

       public void AddFilms()
     {
            for (int i = 0; i < NumberOfFilms; i++) 
            {
                Console.WriteLine($"--- Details for Film {i + 1} ---");
                
                Film? nouveauFilm = Film.CreateFromConsole();

                if (nouveauFilm != null)
                {
                    _listOfFilmsParticipants.Add(nouveauFilm);
                    Console.WriteLine("Film added successfully!");
                }
            }
        }
    /*"N.B. 
    I chose to implement a manual Bubble Sort here to demonstrate the sorting logic and tie-breakers (Score then Votes)
     without relying on built-in methods like List.Sort() or LINQ.
     While List.Sort() is more efficient O(n log (n)) vs O(n²), I wanted to show the understanding of swap logic."
   */
        public void RankFilms()
                {
                    for (int i = 0; i < ListOfFilmsParticipants.Count-1; i++)
                    {
                        for (int j = 0; j < ListOfFilmsParticipants.Count-1-i; j++)
                        {
                            if (ListOfFilmsParticipants[j ].Score < ListOfFilmsParticipants[j+1].Score ||
                            (ListOfFilmsParticipants[j ].Score == ListOfFilmsParticipants[j+1].Score && 
                                ListOfFilmsParticipants[j ].NbOfVotes < ListOfFilmsParticipants[j+1].NbOfVotes))
                            {
                                var temp = ListOfFilmsParticipants[j];
                                ListOfFilmsParticipants[j] = ListOfFilmsParticipants[j+1];
                                ListOfFilmsParticipants[j+1] = temp;
                            }
                        }
                    }
                }
        public void ConductEvaluationRound(){
                foreach (var film in ListOfFilmsParticipants)
                {   int jNote, pNote, votes;
                    Console.WriteLine($"Evaluating: {film._title}");
                    do{
                    Console.Write("Jury Note (0-100): ");
                    int.TryParse(Console.ReadLine(), out jNote);
                    Console.Write("Public Note (0-100): ");
                    int.TryParse(Console.ReadLine(), out pNote);
                    Console.Write("Number of Votes: ");
                    int.TryParse(Console.ReadLine(), out votes);
                    }while(jNote<0 || jNote>100 || pNote<0 || pNote>100 || votes<0);

                    film.NoteOfJury = jNote;
                    film.NoteOfPublic = pNote;
                    film.NbOfVotes = votes;
                    film.UpdateScore((jNote * 0.7f) + (pNote * 0.3f));
                }}
                
        public static void Main(string[] args)
        {
            /*Alternative solution
             using System.Linq;
            var topFilms = festival.ListOfFilmsParticipants
                .OrderByDescending(film => film.Score)
                .ThenByDescending(film => film.NbOfVotes)
                .Take(10)
                .ToList();
                and inside the InternationalFilmFestival class
                public void EvaluateAllFilms()
                    {
                        foreach (var film in _listOfFilmsParticipants)
                        {
                            Console.WriteLine($"Evaluating {film._title}...");
                             ......The Logic.......
                            film.UpdateScore(CalculatedScore);
                        }
                    }
                    N.B:I didn't use this solution bcs Idk if it's allowed to use Linq in this project and also I wanted to show the logic of sorting the films without using any library, but if it's allowed I think it's a better solution and more efficient than the one I used.
            */
            Console.WriteLine("-----International Film Festival Application-----");
            Console.WriteLine("Festival Details:");
            Console.WriteLine("Year:");
            var year = int.TryParse(Console.ReadLine(), out int y) ? y : 0;
            Console.WriteLine("Location:");
            var location = Console.ReadLine() ?? "Some City";
            var festival = new InternationalFilmFestival { Year = year, Location = location };
            Console.WriteLine($"Bienvenue au festival international du film {festival.Year} à {festival.Location}!");
            Console.WriteLine("Enter The Number of Films Participating:");
            festival.NumberOfFilms = int.TryParse(Console.ReadLine(), out int num) ? num : 0;
            festival.ListOfFilmsParticipants = new List<Film>();
            festival.AddFilms();
            
            Console.WriteLine("----------------Selection Phase!----------------");
            Console.WriteLine("----------------Films Participating:----------------");
            if (festival.ListOfFilmsParticipants.Count == 0)
            {
                Console.WriteLine("No films qualified for the festival.");
            }
            else
            { for(int i=0; i<festival.ListOfFilmsParticipants.Count; i++)
                { Console.WriteLine($"Film {i+1}:");
                    Console.WriteLine(festival.ListOfFilmsParticipants[i]);
                }
            }
            Console.WriteLine("----------------Selection Phase Completed!----------------");
            Console.WriteLine("----------------Eleminatory Phase!----------------");
            
            /*Well I didn't know which one to choose since you asked for "Ajouter les méthodes convenables pour répondre au test suivant dans le p.p.". But I thought that creating a method inside the InternationalFilmFestival class to conduct the evaluation is easier and better for code organization and readability.
             Console.WriteLine("Only 10 films can proceed to the next round.");
            
            if(festival.ListOfFilmsParticipants.Count >10){

            for (int i =0; i< festival.ListOfFilmsParticipants.Count;i++)
            {   int NoteOfJury;
                int NoteOfPublic;
                int NbOfVotes;
                float Score;
                 Console.WriteLine($"Film {i+1}:");
                Console.WriteLine(festival.ListOfFilmsParticipants[i]);
                Console.WriteLine("The Jury is evaluating the film...");
                int.TryParse(Console.ReadLine(), out NoteOfJury);
                Console.WriteLine("The Public is evaluating the film...");
                int.TryParse(Console.ReadLine(), out NoteOfPublic);
                Console.WriteLine("The number of votes is:");
                int.TryParse(Console.ReadLine(), out NbOfVotes);
                Score = (NoteOfJury*0.7f + NoteOfPublic*0.3f) ;
                Console.WriteLine($"The score of the film {i+1} is: {Score}");
                Console.WriteLine("-----------------------------------");
                festival.ListOfFilmsParticipants[i].UpdateScore(Score);
                var currentFilm = festival.ListOfFilmsParticipants[i];
                currentFilm.NoteOfJury = NoteOfJury;
                currentFilm.NoteOfPublic = NoteOfPublic;
                currentFilm.NbOfVotes = NbOfVotes;
                currentFilm.UpdateScore(Score);
            }*/
            /*~~~~~~~~ Failed Trial :( ~~~~~~~~
            List<int> CutoffScores = new List<int> ();
            
            foreach (var cutoff in CutoffScores)
              { 
                while (festival.ListOfFilmsParticipants.Count > 1){
                if (festival.ListOfFilmsParticipants.Count %2 ==0)
                {
                    CutoffScores.Add(festival.ListOfFilmsParticipants.Count /2);
                }
                else
                {
                    CutoffScores.Add(festival.ListOfFilmsParticipants.Count /2 + 1);
                }
                Console.WriteLine($"\n--- Starting Phase: Top {cutoff} ---");
                Console.WriteLine($"Only {cutoff} films can proceed to the next round.");
                festival.ConductEvaluationRound();
                Console.WriteLine("The films qualified for the next round are:");
                festival.RankFilms();
                for (int i = festival.ListOfFilmsParticipants.Count - 1; i >= cutoff; i--){festival.ListOfFilmsParticipants.RemoveAt(i);}
                for(int i=0; i<cutoff && i< festival.ListOfFilmsParticipants.Count; i++)  Console.WriteLine($"Film {i+1} with score: {festival.ListOfFilmsParticipants[i].Score}.");
                Console.WriteLine($"---------------- Phase Top {cutoff} Completed!----------------");
                }
            }*/
            int PhaseCount = 1; 
            while (festival.ListOfFilmsParticipants.Count > 1){
                
                int currentCount = festival.ListOfFilmsParticipants.Count;
                int Qualified = currentCount % 2 == 0 ? currentCount / 2 : currentCount / 2 + 1;
                Console.WriteLine($"\n--- Starting Phase {PhaseCount}: Top {Qualified} ---");
                Console.WriteLine($"Only {Qualified} films can proceed to the next round.");
                festival.ConductEvaluationRound();
                Console.WriteLine("The films qualified for the next round are:");
                festival.RankFilms();
                for (int i = festival.ListOfFilmsParticipants.Count - 1; i >= Qualified; i--){festival.ListOfFilmsParticipants.RemoveAt(i);}
                for(int i=0; i<Qualified && i< festival.ListOfFilmsParticipants.Count; i++)  Console.WriteLine($"Film {i+1} with score: {festival.ListOfFilmsParticipants[i].Score}.");
                Console.WriteLine($"---------------- Phase Top {Qualified} Completed!----------------");
                PhaseCount++;
                }
            /* festival.ConductEvaluationRound();
            Console.WriteLine("The films qualified for the next round are:");
            festival.RankFilms();
            for (int i = festival.ListOfFilmsParticipants.Count - 1; i >= 10; i--){festival.ListOfFilmsParticipants.RemoveAt(i);}
            for(int i=0; i<10 && i< festival.ListOfFilmsParticipants.Count; i++)  
            Console.WriteLine($"Film {i+1} with score: {festival.ListOfFilmsParticipants[i].Score}.");
                Console.WriteLine("---------------- 1st Eleminatory Phase Completed!----------------");
                Console.WriteLine("----------------2nd Eleminatory Phase!----------------");}
                Console.WriteLine("Only 5 films can proceed to the next round.");
                for (int i =0; i< festival.ListOfFilmsParticipants.Count;i++)
            {   int NoteOfJury;
                int NoteOfPublic;
                int NbOfVotes;
                float Score;
                
                 Console.WriteLine($"Film {i+1}:");
                Console.WriteLine(festival.ListOf  FilmsParticipants[i]);
                Console.WriteLine("The Jury is evaluating the film...");
                int.TryParse(Console.ReadLine(), out NoteOfJury);
                Console.WriteLine("The Public is evaluating the film...");
                int.TryParse(Console.ReadLine(), out NoteOfPublic);
                Console.WriteLine("The number of votes is:");
                int.TryParse(Console.ReadLine(), out NbOfVotes);
                Score = (NoteOfJury*0.7f + NoteOfPublic*0.3f) ;
                Console.WriteLine($"The score of the film {i+1} is: {Score}");
                Console.WriteLine("-----------------------------------");
                festival.ListOfFilmsParticipants[i].UpdateScore(Score);
                var currentFilm = festival.ListOfFilmsParticipants[i];
                currentFilm.NoteOfJury = NoteOfJury;
                currentFilm.NoteOfPublic = NoteOfPublic;
                currentFilm.NbOfVotes = NbOfVotes;
                currentFilm.UpdateScore(Score);
            }
            festival.ConductEvaluationRound();
            Console.WriteLine("The films qualified for the next round are:");
            festival.RankFilms();
                for (int i = festival.ListOfFilmsParticipants.Count - 1; i >= 5; i--){festival.ListOfFilmsParticipants.RemoveAt(i);}
                for(int i=0; i<5 && i< festival.ListOfFilmsParticipants.Count; i++)  Console.WriteLine($"Film {i+1} with score: {festival.ListOfFilmsParticipants[i].Score}.");
                Console.WriteLine("---------------- Eleminatory Phase Completed!----------------");}
            */
                Console.WriteLine("----------------Final Phase: #The Golden Palm#!----------------");
                Console.WriteLine("The winner film is:");
                
                    Console.WriteLine($"The winning film is Film {festival.ListOfFilmsParticipants[0]._title} with score: {festival.ListOfFilmsParticipants[0].Score}.");
                    Console.WriteLine("Details of the winning film:");
                    Console.WriteLine(festival.ListOfFilmsParticipants[0]);
                    Console.WriteLine($"Number of Votes: {festival.ListOfFilmsParticipants[0].NbOfVotes}");
                    Console.WriteLine($"Note of Jury: {festival.ListOfFilmsParticipants[0].NoteOfJury}");
                    Console.WriteLine($"Note of Public: {festival.ListOfFilmsParticipants[0].NoteOfPublic}");
                    Console.WriteLine("Congratulations to the winning team!");
                
                Console.WriteLine("----------------Final Phase Completed!----------------");


       
    }}
    public class Film
    { // As mentionned in the subject, the film class contains all the details of the film and also the score and the number of votes to be able to sort them in the next phase
    private float _score;
    private int _noteOfJury;
    private int _noteOfPublic;   
    private int _nbOfVotes;
    public ReleaseTeam ReleaseTeam;
    private string? Title ;
    private string? Director;

    private int Genre;
    public List<Actor> Actors { get; set; } = new();
    public int NbOfVotes
    { 
        get { return _nbOfVotes; } 
        set { _nbOfVotes = value; } 
    }

    public int NoteOfJury
    { 
        get { return _noteOfJury; } 
        set { _noteOfJury = value; } 
    }
    public int NoteOfPublic
    { 
        get { return _noteOfPublic; } 
        set { _noteOfPublic = value; } 
    }
    public float Score
    { 
        get { return _score; } 
        set { _score = value; } 
    }
   public void UpdateScore(float newScore)
    {
        _score = newScore;
    }
    
     public string? _title
    {  get { return Title; } 
        set { Title = value; } }

    public string? _Director
    {get { return Director; } 
        set { Director = value; }}
    public ReleaseTeam _releaseTeam
    { get { return ReleaseTeam; } 
        set { ReleaseTeam = value; } }
    public int _genre
    {get { return Genre; } 
        set { Genre = value; } }

    public static Film? CreateFromConsole(){
    Console.WriteLine("\n--- Release Team Details ---");
    Console.Write("Number of staff members: ");
    int.TryParse(Console.ReadLine(), out int NumberOfMembers );
    
    Console.Write("Lead Member First Name: ");
    string MembersName = Console.ReadLine() ?? "";
    
    Console.Write("Lead Member Last Name: ");
    string MembersFamilyName = Console.ReadLine() ?? "";
    ReleaseTeam team = new ReleaseTeam(NumberOfMembers , MembersName, MembersFamilyName);
    Console.WriteLine("\n--- Enter Film Details ---");
    Console.Write("Title: ");
    string t = Console.ReadLine() ?? "";
    
    Console.Write("Director: ");
    string d = Console.ReadLine() ?? "";
    
    Console.Write("Genre:/n 1)Action /n 2)Comedy /n 3)Drama /n 4)Horror /n 5)Other \n Enter the number corresponding to the genre: ");
    int  g =0;
    while (!int.TryParse(Console.ReadLine(), out g) || g < 1 || g > 5)
    {
        Console.Write("Invalid input. Please enter a number between 1 and 5 for the genre: ");
    }

    List<Actor> filmActors = new List<Actor>();
    Console.Write("How many actors to enter? (Minimum 20): ");
    if (!int.TryParse(Console.ReadLine(), out int actorCount) || actorCount < 20)
    {
        Console.WriteLine("Error: Festival rules require at least 20 actors.");
        return null;
    }

    for (int i = 0; i < actorCount; i++)
    {
        Console.WriteLine($"\nActor {i + 1}:");
        Console.Write("First Name: "); string aName = Console.ReadLine() ?? "";
        Console.Write("Last Name: "); string aFamily = Console.ReadLine() ?? "";
        Console.Write("Role: /n 1)Main Role /n 2)Secondary Role /n 3)Supporting Role /n 4)Silhouette Role /n 5)Background Role \n Enter the number corresponding to the role: "); 
        int aRole = 0 ;
        while (!int.TryParse(Console.ReadLine(), out aRole) || aRole < 1 || aRole > 5)
        {
            Console.Write("Invalid input. Please enter a number between 1 and 5 for the role: ");
        }
        
        // Passing the team reference to the actor as per your Actor class constructor
        filmActors.Add(new Actor(aName, aFamily, aRole));
    }
    return new Film(t, d, team, g, filmActors);
    }
    
     public Film(string? Title, string? Director, ReleaseTeam team, int Genre, List<Actor> Actors)
    {
        this.Title = Title;
        this.Director = Director;
        this.ReleaseTeam = team;
        this.Genre = Genre;
        this.Actors = Actors;

        _nbOfVotes = 0;
        _noteOfJury = 0;
        _noteOfPublic = 0;
        _score = 0.0f;
    }
   
    public override string ToString()
    {
        return $"Title: {Title}, Director: {Director}, Release Team: {ReleaseTeam}, Genre: {Genre}, Number of Actors: {Actors.Count}, Release Team, Score: {Score}, Number of Votes: {NbOfVotes}, Note of Jury: {NoteOfJury}, Note of Public: {NoteOfPublic}";
    }
}
public class  ReleaseTeam
{
       private int NumberOfMembers ;
        private string? MembersName ;
        private string? MembersFamilyName;
        public ReleaseTeam(int NumberOfMembers, string? MembersName, string? MembersFamilyName)
        {
            this.NumberOfMembers = NumberOfMembers;
            this.MembersName = MembersName;
            this.MembersFamilyName = MembersFamilyName;
        }
        public int _numberOfMembers 
        { 
            get { return NumberOfMembers; } 
            set { NumberOfMembers = value; } 
        }
        public string? _membersName
        { 
            get { return MembersName; } 
            set { MembersName = value; } 
        }
        public string? _membersFamilyName
        { 
            get { return MembersFamilyName; } 
            set { MembersFamilyName = value; } 
        }
        public override string ToString()
        {
            return $"Number of Members: {NumberOfMembers}, Members Name: {MembersName}, Members Family Name: {MembersFamilyName}";  
        }
    }
    public class Actor 
    {
        private string? ActorName;
        private string? ActorFamilyName ;
        private int Role;

        public Actor( string? ActorName, string? ActorFamilyName, int Role)
        {
            this.ActorName = ActorName;
            this.ActorFamilyName = ActorFamilyName;
            this.Role = Role;
        }
        public string? _actorName
        { 
            get { return ActorName; } 
            set { ActorName = value; } 
        }
        public string? _actorFamilyName
        { 
            get { return ActorFamilyName; } 
            set { ActorFamilyName = value; } 
        }
        public int _role
        { 
            get { return Role; } 
            set { Role = value; } 
        }
        public override string ToString()
        {
            return $"Actor Name: {ActorName}, Actor Family Name: {ActorFamilyName}, Role: {Role}";
        }
    }

}
/* N.B. on Nullability: 
   I used 'string?' for fields like Title and Director to comply with C# Nullable Reference Types. 
   However, in the CreateFromConsole() method, I used the null-coalescing operator (?? "") 
   to ensure that even if the user enters nothing, the program receives an empty string 
   rather than a null value, preventing potential NullReferenceExceptions during sorting.
   The other more professional way would be to use "required string" for such fields, 
   but I wanted to keep it simple for console input scenarios.
*/