using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RepositoryModel
{
    public class PlaneRepositoryModel
    {
        [Key]
        public int PlaneID { get; set; }
    }
}