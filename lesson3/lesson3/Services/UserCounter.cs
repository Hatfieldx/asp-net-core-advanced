using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace lesson3.Services
{
    public class UserCounter
    {
        static int _count;
        private readonly HttpContext _context;

//        public int GetCount()
//        {
//            ISession s
////return _context.Session.GetT
//        }

        public UserCounter(HttpContext context)
        {
            _context = context;
        }
    }
}
