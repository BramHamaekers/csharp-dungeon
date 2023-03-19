public class Room {
    public Tuple<int, int> origin;
    public Tuple<int, int> vector2D; // (Vertical Size, Horizontal Size)

    public Room(Tuple<int, int> origin, Tuple<int, int> vector2D) {
        this.origin = origin;
        this.vector2D = vector2D;
    }

    public bool Intersects(Room room) {
        return !((this.origin.Item2 >= (room.origin.Item2 + room.vector2D.Item2 + FLAGS.room_buffer)) || ((this.origin.Item2 + this.vector2D.Item2 + FLAGS.room_buffer) <= room.origin.Item2)
            || (this.origin.Item1 >= (room.origin.Item1 + room.vector2D.Item1 + FLAGS.room_buffer)) || ((this.origin.Item1 + this.vector2D.Item1 + FLAGS.room_buffer) <= room.origin.Item1));
    }
}

