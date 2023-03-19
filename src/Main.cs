using System;

public class Program {
    public static void Main(String[] args) {
        DungeonGenerator2D dungeon = new DungeonGenerator2D();
        int gridSize = FLAGS.grid_size;
        int roomCount = FLAGS.room_count;
        dungeon.generate(gridSize, roomCount);
        dungeon.display();

    }
}