using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Context
{
    public class CreatePlaneContext : CreateDatabaseIfNotExists<PlaneContext> { }
}