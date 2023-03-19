using System;

public class DungeonGenerator2D {
    int gridSize;
    int roomCount;
    List<Room> rooms = new List<Room>();
    Random rnd = new Random();

    public void generate(int gridSize, int roomCount) {
        this.gridSize = gridSize;
        this.roomCount = roomCount;
        this.placeRooms();
    }

    public void placeRooms() {
        for (int i = 0; i < this.roomCount; i++) {
            Room newRoom = createRoom();
            while (!isValidRoom(newRoom)) {
                newRoom = createRoom();
            }
            this.rooms.Add(newRoom);
            if (FLAGS.show_steps) {
                display();
                Console.WriteLine();
            }

        }
    }

    public Room createRoom() {
        int yPos = rnd.Next(1, this.gridSize);
        int xPos = rnd.Next(1, this.gridSize);

        int vertSize = rnd.Next(2,10);
        int horSize = rnd.Next(2,10);

        return new Room(Tuple.Create(yPos,xPos), Tuple.Create(vertSize, horSize));        
    }

    public bool isValidRoom(Room room) {
        if (room == null) return false;
        if (room.origin.Item1 - FLAGS.room_buffer< 0 || room.origin.Item2 - FLAGS.room_buffer < 0) return false;
        if (room.origin.Item1 + FLAGS.room_buffer > gridSize || room.origin.Item2 + FLAGS.room_buffer > gridSize) return false;
        if (room.origin.Item1 + room.vector2D.Item1  - FLAGS.room_buffer < 0 || room.origin.Item2 + room.vector2D.Item2 - FLAGS.room_buffer < 0) return false;
        if (room.origin.Item1 + room.vector2D.Item1 + FLAGS.room_buffer > gridSize || room.origin.Item2 + room.vector2D.Item2 + FLAGS.room_buffer > gridSize) return false;
        foreach (Room oldRoom in rooms) {
            if (room.Intersects(oldRoom)) return false;
        } 
        return true;
    }

    public void display() {
        int[,] grid = generateGrid();
        for (int i = 0; i < gridSize; i++) {
            for (int j = 0; j < gridSize; j++) {
                if (grid[i,j] == 1) Console.Write("# ");
                else Console.Write(". ");
            }
        Console.WriteLine();
        }
        
    }

    public int[,] generateGrid() {
        int[,] grid = new int[gridSize, gridSize];
        foreach (Room room in rooms) {
            addRoomToGrid(grid, room);
        }
        return grid;
    }

    public int[,] addRoomToGrid(int[,] grid, Room room) {
        for (int i = room.origin.Item1; i < room.origin.Item1 + room.vector2D.Item1; i++)
            for (int j = room.origin.Item2; j < room.origin.Item2 + room.vector2D.Item2; j++) {
                grid[i,j] = 1;
            }
                
        return grid;
    }
}