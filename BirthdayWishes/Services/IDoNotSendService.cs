using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayWishes.Services
{
    public interface IDoNotSendService
    {
        Task<List<int>> GetAllDoNotSend();
    }
}
