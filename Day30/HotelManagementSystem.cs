using System;
using System.Collections.Generic;
using System.Linq;

class Room
{
    public int RoomNumber { get; set; }
    public string RoomType { get; set; }   // Single / Double / Suite
    public double PricePerNight { get; set; }
    public bool IsAvailable { get; set; }
}

class HotelManager
{
    private List<Room> rooms = new List<Room>();

    // Adds room if room number doesn't exist
    public void AddRoom(int roomNumber, string type, double price)
    {
        if (rooms.Any(r => r.RoomNumber == roomNumber))
        {
            Console.WriteLine($"Room {roomNumber} already exists.");
            return;
        }

        rooms.Add(new Room
        {
            RoomNumber = roomNumber,
            RoomType = type,
            PricePerNight = price,
            IsAvailable = true
        });
    }

    // Groups available rooms by type
    public Dictionary<string, List<Room>> GroupRoomsByType()
    {
        Dictionary<string, List<Room>> grouped = new();

        foreach (var room in rooms)
        {
            if (!room.IsAvailable)
                continue;

            if (!grouped.ContainsKey(room.RoomType))
                grouped[room.RoomType] = new List<Room>();

            grouped[room.RoomType].Add(room);
        }
        return grouped;
    }

    // Books room if available, calculates total cost
    public bool BookRoom(int roomNumber, int nights)
    {
        var room = rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);

        if (room == null || !room.IsAvailable)
        {
            Console.WriteLine("Room not available.");
            return false;
        }

        double totalCost = room.PricePerNight * nights;
        room.IsAvailable = false;

        Console.WriteLine($"Room {roomNumber} booked for {nights} nights.");
        Console.WriteLine($"Total cost: ₹{totalCost}");
        return true;
    }

    // Returns available rooms within price range
    public List<Room> GetAvailableRoomsByPriceRange(double min, double max)
    {
        return rooms
            .Where(r => r.IsAvailable && r.PricePerNight >= min && r.PricePerNight <= max)
            .ToList();
    }
}

class HotelManagement
{
    public static void Run()
    {
        HotelManager hotel = new HotelManager();

        // Add rooms
        hotel.AddRoom(101, "Single", 2000);
        hotel.AddRoom(102, "Double", 3500);
        hotel.AddRoom(201, "Suite", 6000);
        hotel.AddRoom(103, "Single", 2200);

        // Display available rooms grouped by type
        Console.WriteLine("\n🏨 Available Rooms Grouped by Type:");
        var groupedRooms = hotel.GroupRoomsByType();

        foreach (var type in groupedRooms)
        {
            Console.WriteLine($"\nRoom Type: {type.Key}");
            foreach (var room in type.Value)
            {
                Console.WriteLine($"Room {room.RoomNumber} - ₹{room.PricePerNight}");
            }
        }

        // Book a room
        Console.WriteLine("\n📘 Booking Room 102:");
        hotel.BookRoom(102, 3);

        // Find rooms within budget
        Console.WriteLine("\n💰 Available Rooms Between ₹2000 and ₹4000:");
        var budgetRooms = hotel.GetAvailableRoomsByPriceRange(2000, 4000);

        foreach (var room in budgetRooms)
        {
            Console.WriteLine($"Room {room.RoomNumber} ({room.RoomType}) - ₹{room.PricePerNight}");
        }
    }
}
