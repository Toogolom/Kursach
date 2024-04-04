using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.Interface
{
    public interface IEmailRepository
    {
        public Task SaveEmail(Email email);
    }
}
