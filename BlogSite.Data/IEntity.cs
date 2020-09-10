using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSite.Data
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
