using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensioenSysteem.Domain.Core
{
    public interface IHandle<in TEvent>
    {
        void Handle(TEvent e);
    }
}
