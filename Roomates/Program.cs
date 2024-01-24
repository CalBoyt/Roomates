using RoommatesC8.Models;
using RoommatesC8.Repositories;

namespace RoommatesC8
{
    internal class Program
    {
        private const string CONNECTION_STRING = @"server=localhost\SQLExpress;database=Roommates;integrated security=true;TrustServerCertificate=True;";

        static void Main(string[] args)
        {
            RoomRepository roomRepo = new RoomRepository(CONNECTION_STRING);
            RoommateRepository roommateRepo = new RoommateRepository(CONNECTION_STRING);
            ChoreRepository choreRepo = new ChoreRepository(CONNECTION_STRING);
            bool runProgram = true;
            while (runProgram)
            {
                string selection = GetMenuSelection();

                switch (selection)
                {
                    case ("Show all rooms"):
                        List<Room> rooms = roomRepo.GetAll();
                        foreach (Room r in rooms)
                        {
                            Console.WriteLine($"{r.Name} has an Id of {r.Id} and a max occupancy of {r.MaxOccupancy}");
                        }
                        Console.Write("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case ("Search for room"):
                        Console.Write("Room Id: ");
                        int id = int.Parse(Console.ReadLine());

                        Room room = roomRepo.GetById(id);

                        Console.WriteLine($"{room.Id} - {room.Name} Max Occupancy({room.MaxOccupancy})");
                        Console.Write("Press any key to continue");
                        Console.ReadKey();
                        break;

                    case ("Add a room"):
                        Console.Write("Room name: ");
                        string name = Console.ReadLine();

                        Console.Write("Max occupancy: ");
                        int max = int.Parse(Console.ReadLine());

                        Room roomToAdd = new Room()
                        {
                            Name = name,
                            MaxOccupancy = max
                        };

                        roomRepo.Insert(roomToAdd);

                        Console.WriteLine($"{roomToAdd.Name} has been added and assigned an Id of {roomToAdd.Id}");
                        Console.Write("Press any key to continue");
                        Console.ReadKey();
                        break;

                    case ("Update a room"):
                        List<Room> roomOptions = roomRepo.GetAll();
                        foreach (Room r in roomOptions)
                        {
                            Console.WriteLine($"{r.Id} - {r.Name} Max Occupancy({r.MaxOccupancy})");
                        }

                        Console.Write("Which room would you like to update? ");
                        int selectedRoomId = int.Parse(Console.ReadLine());
                        Room selectedRoom = roomOptions.FirstOrDefault(r => r.Id == selectedRoomId);

                        Console.Write("New Name: ");
                        selectedRoom.Name = Console.ReadLine();

                        Console.Write("New Max Occupancy: ");
                        selectedRoom.MaxOccupancy = int.Parse(Console.ReadLine());

                        roomRepo.Update(selectedRoom);

                        Console.WriteLine("Room has been successfully updated");
                        Console.Write("Press any key to continue");
                        Console.ReadKey();
                        break;

                    case ("Delete a room"):
                        List<Room> deleteRmOptions = roomRepo.GetAll();
                        foreach (Room r in deleteRmOptions)
                        {
                            Console.WriteLine($"{r.Id} - {r.Name} Max Occupancy({r.MaxOccupancy})");
                        }
                        Console.Write("Which room would you like to delete? ");
                        int roomToDeleteId = int.Parse(Console.ReadLine());
                        Room roomToDelete = deleteRmOptions.FirstOrDefault(r => r.Id == roomToDeleteId);
                        roomRepo.Delete(roomToDeleteId);

                        Console.WriteLine("Room has been successfully updated");
                        Console.Write("Press any key to continue");
                        Console.ReadKey();
                        break;

                    case ("Show all chores"):
                        List<Chore> chores = choreRepo.GetAll();
                        foreach (Chore c in chores)
                        {
                            Console.WriteLine($"{c.Name} has an Id of {c.Id} ");
                        }
                        Console.Write("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case ("Show all unassigned chores"):
                        List<Chore> unassignedchores = choreRepo.GetAllUnassigned();
                        foreach (Chore c in unassignedchores)
                        {
                            Console.WriteLine($"{c.Name} has yet to be assigned. ");
                        }
                        Console.Write("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case ("Search for chore"):
                        Console.Write("Chore Id: ");
                        int choreid = int.Parse(Console.ReadLine());

                        Chore chore = choreRepo.GetById(choreid);

                        Console.WriteLine($"{chore.Id} - {chore.Name}");
                        Console.Write("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case ("Add a chore"):
                        Console.Write("Chore name: ");
                        string chorename = Console.ReadLine();


                        Chore choreToAdd = new Chore()
                        {
                            Name = chorename
                        };

                        choreRepo.Insert(choreToAdd);

                        Console.WriteLine($"{choreToAdd.Name} has been added and assigned an Id of {choreToAdd.Id}");
                        Console.Write("Press any key to continue");
                        Console.ReadKey();
                        break;

                    case ("Update a chore"):
                        List<Chore> choreOptions = choreRepo.GetAll();
                        foreach (Chore c in choreOptions)
                        {
                            Console.WriteLine($"{c.Id} - {c.Name}");
                        }

                        Console.Write("Which chore would you like to update? ");
                        int selectedChoreId = int.Parse(Console.ReadLine());
                        Chore selectedChore = choreOptions.FirstOrDefault(r => r.Id == selectedChoreId);

                        Console.Write("New Name: ");
                        selectedChore.Name = Console.ReadLine();

                        choreRepo.Update(selectedChore);

                        Console.WriteLine("Chore has been successfully updated");
                        Console.Write("Press any key to continue");
                        Console.ReadKey();
                        break;

                    case ("Delete a chore"):
                        List<Chore> deleteChoreOptions = choreRepo.GetAll();
                        foreach (Chore c in deleteChoreOptions)
                        {
                            Console.WriteLine($"{c.Id} - {c.Name}");
                        }
                        Console.Write("Which chore would you like to delete? ");
                        int choreToDeleteId = int.Parse(Console.ReadLine());
                        Chore choreToDelete = deleteChoreOptions.FirstOrDefault(r => r.Id == choreToDeleteId);
                        roomRepo.Delete(choreToDeleteId);

                        Console.WriteLine("Chore has been successfully updated");
                        Console.Write("Press any key to continue");
                        Console.ReadKey();
                        break;

                    case ("Show all roommates"):
                        List<Roommate> roommates = roommateRepo.GetAll();
                        foreach (Roommate r in roommates)
                        {
                            Console.WriteLine($"{r.FirstName} is a roommate.");
                        }
                        Console.Write("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case ("Show all roommates who share room"):

                        Console.Write("Room Id: ");
                        int roomShareId = int.Parse(Console.ReadLine());
                        List<Roommate> roommatesShare = roommateRepo.GetRoommatesByRoomId(roomShareId);
                        foreach (Roommate r in roommatesShare)
                        {
                            Console.WriteLine($"{r.FirstName} is a roommate.");
                        }
                        Console.Write("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case ("Search for roommate"):
                        Console.Write("Roommate Id: ");
                        int roommateid = int.Parse(Console.ReadLine());

                        Roommate roommate = roommateRepo.GetById(roommateid);

                        Console.WriteLine($"{roommate.FirstName} stays in the {roommate.Room.Name}. They pay ${roommate.RentPortion} in rent.");
                        Console.Write("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case ("Add a roommate"):
                        Console.Write("Roommates first name: ");
                        string firstname = Console.ReadLine();
                        Console.Write("Roommates last name: ");
                        string lastname = Console.ReadLine();

                        Console.Write("move in date: ");
                        DateTime moveDate = DateTime.Parse(Console.ReadLine());

                        Console.Write("Roommates rent: ");
                        int rent = int.Parse(Console.ReadLine());

                        Console.Write("Roommates Room Id ");
                        int roomId = int.Parse(Console.ReadLine());

                        Roommate roommateToAdd = new Roommate()
                        {
                            FirstName = firstname,
                            LastName = lastname,
                            MoveInDate = moveDate,
                            RentPortion = rent,
                            Room = null

                        };

                        roommateRepo.Insert(roommateToAdd, roomId);

                        Console.WriteLine($"{roommateToAdd.FirstName} has been added and assigned an Id of {roommateToAdd.Id}");
                        Console.Write("Press any key to continue");
                        Console.ReadKey();
                        break;

                    case ("Exit"):
                        runProgram = false;
                        break;
                }
            }

        }

        static string GetMenuSelection()
        {
            Console.Clear();

            List<string> options = new List<string>()
            {
                "Show all rooms",
                "Search for room",
                "Update a room",
                "Delete a room",
                "Add a room",
                "Show all chores",
                "Show all unassigned chores",
                "Search for chore",
                "Add a chore",
                "Update a chore",
                "Delete a chore",
                "Show all roommates",
                "Show all roommates who share room",
                "Search for roommate",
                "Add a roommate",
                "Exit"
            };

            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }

            while (true)
            {
                try
                {
                    Console.WriteLine();
                    Console.Write("Select an option > ");

                    string input = Console.ReadLine();
                    int index = int.Parse(input) - 1;
                    return options[index];
                }
                catch (Exception)
                {

                    continue;
                }
            }
        }
    }
}