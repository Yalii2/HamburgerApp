using HamburgerApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerApp.Core.Entities.Abstract
{
    public interface IBaseEntity
    {
        public Status Status { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? DeletedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
    }
}
