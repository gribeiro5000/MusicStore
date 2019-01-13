using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Repository
{
    public class BaseRepository
    {
        protected string _connectionString { get { return @"data source=C:\Users\gribe\Documents\coisas Gabriel\databases\chinook.db"; } }
    }
}