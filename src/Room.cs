public class Room {
    public Tuple<int, int> origin; // Top left corner position of the room
    public Tuple<int, int> sizeVector; // (Vertical Size, Horizontal Size)
    public Tuple<int, int> vertex; // vertex indicating the middle a room.

    public Room(Tuple<int, int> origin, Tuple<int, int> sizeVector) {
        this.origin = origin;
        this.sizeVector = sizeVector;
        this.vertex = calculateVertex();
    }

    public bool Intersects(Room room) {
        return !((this.origin.Item2 >= (room.origin.Item2 + room.sizeVector.Item2 + FLAGS.room_buffer)) || ((this.origin.Item2 + this.sizeVector.Item2 + FLAGS.room_buffer) <= room.origin.Item2)
            || (this.origin.Item1 >= (room.origin.Item1 + room.sizeVector.Item1 + FLAGS.room_buffer)) || ((this.origin.Item1 + this.sizeVector.Item1 + FLAGS.room_buffer) <= room.origin.Item1));
    }

    private Tuple<int, int> calculateVertex() {
        int horPos = this.origin.Item1 + (this.sizeVector.Item1 / 2);
        int verPos = this.origin.Item2 + (this.sizeVector.Item2 / 2);
        return Tuple.Create(horPos, verPos);
    }
}

