﻿using System;
using Common.Repositories;

namespace Common
{
    public interface IUnitOfWork : IDisposable
    {
        IBetRepository Bet { get; }
        ILobbyRepository Lobby { get; }
        IUserRepository User { get; }

        int Complete();
    }
}
