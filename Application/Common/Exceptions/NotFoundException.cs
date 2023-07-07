using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Application.Common.Exceptions;

public class NotFoundException : Exception
{ 
    public NotFoundException(string objectName, object keyName) : base($"Entity \"{objectName}\" ({keyName} not found.") { }
}
