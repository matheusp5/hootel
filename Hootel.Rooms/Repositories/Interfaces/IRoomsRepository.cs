﻿using Hootel.Models;

namespace Hootel.Rooms.Repositories;

public interface IRoomsRepository
{
    Task<List<Room>> Get();
    Task<Room> Get(int id);
    Task Save(Room room);
    Task Delete(Room room);
}