namespace Firebase.Dinosaurs
{
    using System;
    using System.Threading.Tasks;

    using Firebase.Database;
    using Firebase.Database.Query;

    public class Program
    {
        public static void Main(string[] args)
        {
            new Program().Run().Wait();
        }

        private async Task Run()
        {
            // Since the dinosaur-facts repo no longer works, populate your own one with sample data
            // in "sample.json"
            var firebase = new FirebaseClient("https://dinosaur-d384d-default-rtdb.europe-west1.firebasedatabase.app/");

            var dinos = await firebase
              .Child("dinosaurs")
              .OrderByKey()
              .StartAt("pterodactyl")
              .LimitToFirst(2)
              .OnceAsync<Dinosaur>();

            foreach (var dino in dinos)
            {
                Console.WriteLine($"{dino.Key} is {dino.Object.Height}m high.");
            }
        }
    }
}
