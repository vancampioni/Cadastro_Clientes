using CL.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Manager.Interfaces.Services
{
    public interface IJWTService
    {
        string GerarToken(Usuario usuario);
    }
}
